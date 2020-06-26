﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApiLogging.Data
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
