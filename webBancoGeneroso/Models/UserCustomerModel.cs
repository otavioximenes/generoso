using Microsoft.AspNetCore.Identity; 
using System;
using System.ComponentModel.DataAnnotations;
using MySql.Data.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace webBancoGeneroso.Models
{ 
    public class UserCustomerModel : IdentityUser
    {
        public string PhotoIdPath { get; set; } 
    }
}
