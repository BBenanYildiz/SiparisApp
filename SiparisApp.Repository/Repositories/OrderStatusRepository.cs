using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Repositories;

namespace SiparisApp.Repository.Repositories
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        private readonly IMapper _mapper;
        public OrderStatusRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
