using Data;
using house.ApplicationServices.Services;
using house.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHouse.Macros;

namespace TestHouse
{
    public class TestBase : IDisposable
    {
        protected IServiceProvider serviceProvider { get; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IHouseServices, HouseServices>();
            services.AddDbContext<HouseDbContext>(
                x =>
                {
                    x.UseInMemoryDatabase("TEST");
                    x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });
            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacro);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach(var macro in macros)
            {
                services.AddTransient(macro);
            }
        }

        public void Dispose()
        {
            
        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        protected T Macro<T>() where T : IMacro
        {
            return serviceProvider.GetService<T>();
        }
    }
}
