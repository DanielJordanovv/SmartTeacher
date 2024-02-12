using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartTeacher.Data.Models;
using System.Reflection;

namespace SmartTeacher.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] implementationTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type implementationType in implementationTypes)
            {
                Type? interfaceType = implementationType
                    .GetInterface($"I{implementationType.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException(
                        $"No interface is provided for the service with name: {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }
        }

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            //using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            //IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            //UserManager<Teacher> userManager =
            //    serviceProvider.GetRequiredService<UserManager<Teacher>>();
            //RoleManager<IdentityRole<Guid>> roleManager =
            //    serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            //Task.Run(async () =>
            //{
            //    if (await roleManager.RoleExistsAsync("Administrator"))
            //    {
            //        return;
            //    }
            //    IdentityRole<Guid> role =
            //        new IdentityRole<Guid>("Administrator");
            //    await roleManager.CreateAsync(role);
            //    Teacher adminUser =
            //        await userManager.FindByEmailAsync(email);
            //    await userManager.AddToRoleAsync(adminUser, "Administrator");
            //})
            //.GetAwaiter()
            //.GetResult();

            return app;
        }
    }
}