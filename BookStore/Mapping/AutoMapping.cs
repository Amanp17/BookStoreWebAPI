using AutoMapper;
using BookStore.Models;
using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //General
            CreateMap<BooksModel,BookStoreContext>().ReverseMap();
        }
    }
}
