﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storedProc.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("conStr")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserImg> UserImgs { get; set; }
    }
}
