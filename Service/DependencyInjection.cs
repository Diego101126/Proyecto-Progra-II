using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISvCategory, SvCategory>();
            services.AddScoped<ISvProduct, SvProduct>();
            services.AddScoped<ISvClient, SvClient>();
            services.AddScoped<ISvPurchase, SvPurchase>();
            services.AddScoped<ISvPurchaseDetail, SvPurchaseDetail>();
            

            //El proyecto Services está exponiendo el servicio SvUser por medio de la interfaz IUser, al retornar los servicios que se registren
            //en este método, cuándo en el Program llame a AddServices, el Program conocerá todas las interfaces y servicios aquí configurados en el contenedor
            //de dependencias

            return services;//retornamos todos los servicios configurados para el resto de la aplicación
        }

        
        }
    
}
