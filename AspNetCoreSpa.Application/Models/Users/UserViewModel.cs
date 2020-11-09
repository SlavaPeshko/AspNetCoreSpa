using System;
using System.Collections.Generic;
using System.Security.Claims;
using AspNetCoreSpa.Application.Models.Addresses;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Domain.Entities;

namespace AspNetCoreSpa.Application.Models.Users
{
    public class UserViewModel : ClaimsPrincipal
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public AddressViewModel Address { get; set; }
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
                Gender = (int) user.Gender
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
                Gender = user.Gender
            };

            if (user.Address != null)
                userViewModel.Address = new AddressViewModel
                {
                    Id = user.Address.Id,
                    Address1 = user.Address.Address1,
                    Address2 = user.Address.Address2,
                    City = user.Address.City,
                    Postcode = user.Address.Postcode,
                    CountryId = user.Address.CountryId,
                    CountryName = user.Address.CountryName
                };

            if (user.ImageDto != null)
                userViewModel.Image = new ImageViewModel
                {
                    Id = user.ImageDto.Id,
                    Name = user.ImageDto.Name,
                    Path = user.ImageDto.Path
                };

            return userViewModel;
        }
    }
}