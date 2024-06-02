using SisRestaurant.Core.AppServices;
using SisRestaurant.Core.AppServices.Base;
using System.Reflection;

namespace SisRestaurant.Api.Configuration
{
    public static class DependencyInjectionConfigs
    {
        public static WebApplicationBuilder AddDependencyInjectionConfigs(this WebApplicationBuilder builder)
        {
            var baseClass = typeof(BaseAppService);
            var assembly = Assembly.GetAssembly(baseClass);

            if(assembly is not null)
                foreach (var type in assembly.GetTypes().Where(a => a.IsSubclassOf(baseClass)))
                    builder.Services.AddScoped(type);            

            return builder;
        }
    }
}
