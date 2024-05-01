using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionApp1.PlatformFunctionsStartup))]

namespace FunctionApp1
{
    public class PlatformFunctionsStartup : FunctionsStartup
    {
        public PlatformFunctionsStartup()
        {
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddAuthorization();
        }
    }
}
