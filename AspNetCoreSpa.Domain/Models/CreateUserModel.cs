﻿namespace AspNetCoreSpa.Domain.Models
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryRegioneCode { get; set; }
    }
}
