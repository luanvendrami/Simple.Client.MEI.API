using AutoMapper;
using Domain.Dto;
using Domain.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuting
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientInputDto,ClientRequestModel>();
            CreateMap<FetchClientInputDto, ClientRequestModel>();
        }
    }
}
