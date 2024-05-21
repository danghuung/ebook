using AutoMapper;
using MyEBook.Models.DTOs;
using MyEBook.Models.Entities;

namespace MyEBook.Commons.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
