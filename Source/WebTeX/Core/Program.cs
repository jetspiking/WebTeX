using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebTeX.Core
{
    public class Program
    {
        public static void Main(String[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();
            WebApplication? app = builder.Build();
            RequestHandler requestHandler = new(app);
        }
    }
}
