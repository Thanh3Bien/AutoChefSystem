﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }
    }
}
