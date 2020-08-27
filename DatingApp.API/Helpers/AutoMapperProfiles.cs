using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using System;
using System.Linq;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Mapping for UserForDetailedDto from User
            CreateMap<User, UserForDetailedDto>().ForMember(
                dest => dest.PhotoUrl, 
                opt => opt.MapFrom(
                    src => src.Photos.FirstOrDefault(p => p.IsMain).Url
                )
            ).ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(
                    src => src.DateOfBirth.CalculateAge()
                )
            );

            // Mapping for UserForListDto from User
            CreateMap<User, UserForListDto>().ForMember(
                dest => dest.PhotoUrl,
                opt => opt.MapFrom(
                    src => src.Photos.FirstOrDefault(p => p.IsMain).Url
                )
            ).ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(
                    src => src.DateOfBirth.CalculateAge()
                )
            );

            // Mapping for PhotoForDetailedDto from Photo
            CreateMap<Photo, PhotoForDetailedDto>();
        }
    }
}
