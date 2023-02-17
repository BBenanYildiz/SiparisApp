using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Repositories;

namespace SiparisApp.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly IMapper _mapper;
        public OrderRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
