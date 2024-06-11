using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.Models;

public static class DependencyInjection
{
    public static IServiceCollection AddEntities(this IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseInMemoryDatabase("MyDd");

        

        });//Acá añadimos el contexto a nuestro proyecto y le decimos como va a trabajar, en este caso en Memoria y La Base de datos se llamará MyDb



        services.AddScoped<MyDbContext>();
        //El proyecto DataAccess está exponiendo el contexto MyDbContext
        //en este método, cuándo en el Program llame a AddDataAccess, el Program conocerá todas las interfaces, servicios o clases aquí configuradas
        //En este caso solo configuramos el context de la base de datos

        return services;

       

    }




}



