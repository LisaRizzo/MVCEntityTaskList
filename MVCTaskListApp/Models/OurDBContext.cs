﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCTaskListApp.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}