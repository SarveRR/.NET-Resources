using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Infrastructure.Repositories;

namespace UsersDirectoryMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IAssignmentRepository, AssignmentRepository>();
            services.AddTransient<IEmployerRepository, EmployerRepository>();
            return services;
        }
    }
}
