using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Swarmer.Front
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
                .UseUrls("http://192.168.1.31:5002/")
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
