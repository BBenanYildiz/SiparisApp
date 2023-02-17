using AutoMapper;
using SiparisApp.Core.DTOs;
using SiparisApp.Core.Model;
using SiparisApp.Core.Model.ResponseModel;
using SiparisApp.Core.Repositories;
using SiparisApp.Core.Services;
using SiparisApp.Core.UnitOfWorks;
using SiparisApp.Service.Services;
using System.Net;
using System.Text;

namespace SiparisApp.Service.Services
{
    public class OrderStatusService : GenericService<OrderStatus>, IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;
        public OrderStatusService(IGenericRepository<OrderStatus> repository,
            IUnitOfWork unitOfWork,
            IOrderStatusRepository orderStatusRepository,
            IMapper mapper) : base(repository, unitOfWork)
        {
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
        }
    }
}
