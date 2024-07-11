using System.BusinessRules;
using System.Provider;

namespace CrudBlazor.Injecter
{
    public static class Injecter
    {

        public static void Inject(IServiceCollection Services)
        {
            InjecterDefault(Services);
            InjecterBusinessRules(Services);
            InjecterProvider(Services);
        }

        public static void InjecterDefault(IServiceCollection Services)
        {
            Services.AddScoped<ApplicationDbContext>();
        }

        public static void InjecterBusinessRules(IServiceCollection Services)
        {
            Services.AddScoped<ProductBusinessRules>();

        }

        public static void InjecterProvider(IServiceCollection Services)
        {
            Services.AddScoped<DefaultProvider>();
        }
    }
}
