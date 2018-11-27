using AutoMapper;
using AutoMapper.Configuration;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });
            return configuration.CreateMapper();
        }

    }
}
