﻿using DbModels.ViewModels;
using ProjectBase.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository
{
    public interface IProductRepo : IRepository<Product>
    {
    }
}
