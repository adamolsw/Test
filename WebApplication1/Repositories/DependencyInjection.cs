using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
