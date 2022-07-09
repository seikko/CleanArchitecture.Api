using Application.Features.Cart.Commands.Request;
using Application.Features.Cart.Commands.Response;
using Application.Features.Product.Commands.Request;
using Application.Features.Product.Commands.Response;
using Application.Features.Product.Queries.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<UpdateProductCommandRequest, Product>();
            CreateMap<CreateCartCommandRequest, Product>();
            CreateMap<Product, CreateCartCommandRequest>();
            CreateMap<UpdateProductCommandRequest, UpdateProductCommandResponse>();
            CreateMap<CreateCartCommandResponse, Cart>();

            CreateMap<Product, UpdateProductCommandResponse>(); 


        }
    }
}
