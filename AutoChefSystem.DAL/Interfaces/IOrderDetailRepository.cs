using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.DAL.Entities;
using AutoChefSystem.DAL.Infrastructures;

namespace AutoChefSystem.DAL.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
    }
}
