using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.Services;
using UsersDirectoryMVC.Application.ViewModels.Assignment;
using UsersDirectoryMVC.Application.ViewModels.Customer;
using UsersDirectoryMVC.Application.ViewModels.Employer;

namespace UsersDirectoryMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployerService, EmployerService>();
            services.AddTransient<IAssignmentService, AssignmentService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
 
            services.AddTransient<IValidator<NewCustomerVm>, NewCustomerValidation>();
            services.AddTransient<IValidator<NewEmployerVm>, NewEmployerValidation>();
            services.AddTransient<IValidator<NewAssignmentVm>, NewAssignmentValidation>();
            return services;
        }
    }
}
