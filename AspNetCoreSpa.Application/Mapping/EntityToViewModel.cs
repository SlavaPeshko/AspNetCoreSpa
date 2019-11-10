using AspNetCoreSpa.Application.Models;
using AspNetCoreSpa.Domain.Enities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Mapping
{
    public class EntityToViewModel : Profile
    {
        public EntityToViewModel()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, Post>();
        }
    }
}
