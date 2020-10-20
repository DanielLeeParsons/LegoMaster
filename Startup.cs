using LegoMaster.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(LegoMaster.Startup))]

namespace LegoMaster
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
           
            builder.Services.AddDbContext<pc305Context>(
              
               );
        }
    }
}
