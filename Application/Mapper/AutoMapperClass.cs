using AutoMapper;
using DTO_s;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class AutoMapperClass:Profile
    {
        public AutoMapperClass()
        {
            CreateMap<CreatBookDto, Book>().ReverseMap();
        }
    }
}