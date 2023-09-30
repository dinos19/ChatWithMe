﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregate
{
    [Table("User")]
    public class User
    {
        public User(string username, string password, int userType)
        {
            Username = username;
            Password = password;
            UserType = userType;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public int UserType { get; private set; } // UserRoleEnum : 0 admin, 1 user
    }
}