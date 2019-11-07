using System.Web;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreSpa.Domain.Enities.Enum;
using AspNetCoreSpa.Application.Models;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreSpa.Application.Helpers
{
    public class AccountContext
    {
        //public bool IsAuthorized()
        //{
        //    return GetCurrentUser != null;
        //}

        //public bool IsInRole(RoleEnum role)
        //{
        //    return GetCurrentUser.IsInRole(role.ToString("G"));
        //}

        //public int AccountId => GetCurrentUser.Id;

        //private UserViewModel GetCurrentUser
        //{
        //    get
        //    {
        //        HttpContext context = CallContext.LogicalGetData("CurrentContextKey") as HttpContext;
        //        var model = user as UserViewModel;
        //        return model;
        //    }
        //}
    }
}
