using System;
using System.Collections.Generic;
using System.Security.Claims;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Application.Models
{
    public class UserViewModel : ClaimsPrincipal
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public CountryViewModel Country { get; set; }
        public ImageViewModel Image { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    public static class UserViewModelExtensionMethods
    {
        public static UserViewModel ToViewModel(this User user)
        {
            if (user == null) return null;

            return new UserViewModel
            {
                Email = user.Email,
                Phone = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender.ToString("G"),
            };
        }

        public static UserViewModel ToViewModel(this UserDto user)
        {
            if (user == null) return null;
            
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Phone = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender.ToString("G"),
            };

            if (user.CountryDto != null)
            {
                userViewModel.Country = new CountryViewModel
                {
                    Id = user.CountryDto.Id,
                    Name = user.CountryDto.Name,
                    RegioneCode = user.CountryDto.RegionCode
                };
            }

            if (user.ImageDto != null)
            {
                userViewModel.Image = new ImageViewModel
                {
                    Id = user.ImageDto.Id,
                    Name = user.ImageDto.Name,
                    Path = user.ImageDto.Path
                };
            }

            return userViewModel;
        }
    }
}
