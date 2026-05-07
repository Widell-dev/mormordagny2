using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Purchases;
using Core.Interfaces;
using AutoMapper;

namespace api.Controllers
{
    public class SuppliersController(IGenericRepository<Supplier> repo, IMapper map):ApiBaseController
    {
        
    }
}