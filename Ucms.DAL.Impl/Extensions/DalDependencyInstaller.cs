using Microsoft.Extensions.DependencyInjection;
using Ucms.DAL.Abstract.Repository;
using Ucms.DAL.Abstract.Repository.Base;
using Ucms.DAL.Impl.Repository;
using Ucms.DAL.Impl.Repository.Base;

namespace Ucms.DAL.Impl.Extensions;

public static class DalDependencyInstaller
{
    public static void InstallRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
   
}
