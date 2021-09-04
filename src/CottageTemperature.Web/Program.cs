using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CottageTemperature.Web
{
    /// <summary>
    ///     Application entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method.
        /// </summary>
        /// <param name="args"> Application arguments. </param>
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args)
                .Build()
                .RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}