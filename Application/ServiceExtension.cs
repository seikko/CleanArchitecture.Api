using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Application.Behaviours;
using MediatR;
using Application.Features.Cart.Commands.Request;

namespace Application
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCartCommandRequest).GetTypeInfo().Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


        }
    }
}
