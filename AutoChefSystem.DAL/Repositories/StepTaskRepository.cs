﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Repositories
{
    public class StepTaskRepository : GenericRepository<StepTask>, IStepTaskRepository
    {
        public StepTaskRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }
    }
}
