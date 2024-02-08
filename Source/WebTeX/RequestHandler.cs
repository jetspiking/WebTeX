using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTeX.Core;
using WebTeX.Pages;

namespace WebTeX
{
    public class RequestHandler
    {
        public RequestHandler(WebApplication? app)
        {
            const String configuration = "Configuration.json";
            Console.WriteLine("Searching for configuration file: "+Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration));
            WebTeXArgs? webTeXArgs = JsonManager.DeserializeFromFile<WebTeXArgs>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration));
            if (webTeXArgs == null)
            {
                Console.WriteLine($"{configuration} not found!");
                Console.ReadKey();
                return;
            }
            JITTeX jITTeX = new(webTeXArgs);

           
            app.Urls.Add("http://localhost:"+webTeXArgs.WebsitePort);
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapGet("/{documentName}", async (HttpContext httpContext, String documentName) =>
            {
                TeXPage? page = null;
                Boolean isSuccess;

                switch (documentName)
                {
                    case "Index":
                        page = new IndexPage(jITTeX, documentName);
                        break;
                    case "Demo":
                        page = new DemoPage(jITTeX, documentName);
                        break;
                    default:
                        return;
                }

                isSuccess = await page.HandleRequest();
                if (!isSuccess)
                {
                    page = new DemoErrorPage(jITTeX, documentName);
                    await page.HandleRequest();
                }
                
                string? pdfFilePath = jITTeX.CompileTeXFile(documentName);
                FileStream? fileStream = new FileStream(pdfFilePath, FileMode.Open, FileAccess.Read);
                httpContext.Response.ContentType = "application/pdf";
                await fileStream.CopyToAsync(httpContext.Response.Body);
                fileStream.Close();
            });

            app.Run();
        }
    }
}
