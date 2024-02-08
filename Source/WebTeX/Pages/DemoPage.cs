using Newtonsoft.Json;
using System.Net;
using WebTeX.Core;

namespace WebTeX.Pages
{
    public class DemoPage : TeXPage
    {
        public DemoPage(JITTeX jITTeX, String template) : base(jITTeX, template)
        {
            
        }

        protected override async Task<TemplateInstruction?> GetEldynJson()
        {
            String url = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    String responseBody = await response.Content.ReadAsStringAsync();

                    dynamic data = JsonConvert.DeserializeObject(responseBody);
                    String title = data.title;
                    String imageUrl = data.url;
                    String explanation = data.explanation;

                    MemoryStream imageStream = new MemoryStream();
                    client.GetStreamAsync(imageUrl).Result.CopyTo(imageStream);

                    String imagePath = Path.Combine(this._jITTeX.Configuration.RootDirectoryPath, this._jITTeX.Configuration.TeXServeDirectoryName, "apod.jpg");
                    FileStream file = new FileStream(imagePath, FileMode.Create, System.IO.FileAccess.ReadWrite);
                    imageStream.WriteTo(file);
                    file.Close();

                    return new DemoPageJson(title, explanation, imageUrl, "apod.jpg", _jITTeX.Configuration.WebsiteUrl).GetInstruction();
                }
            }
            catch (Exception e)
            {
                // Something went wrong upon retrieving the result from APOD.
                return new DemoPageJson("Oops", "Something went wrong when retrieving the image from the Astronomy Picture of the Day API. Request count for DEMO\\_KEY might be exceeded.", "https://api.nasa.gov/", "example-image.png", _jITTeX.Configuration.WebsiteUrl).GetInstruction();
            }
        }
    }
}
