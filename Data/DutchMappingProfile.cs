using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .AfterMap((o, oi) => oi.orderId = o.Id)
                .ReverseMap();
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();


        }
    }
}
