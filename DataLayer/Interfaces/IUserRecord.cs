﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserRecord
    {
        public string? UserName { get; set; }
        public int UserID { get; set; }
    }
}
