using AutoMapper;
using CoolLibrary.DAL;

namespace CoolLibrary.BLL.Service.Abstract
{
    public class AbstractService
    {
        protected readonly DataContext _dataContext;
        protected readonly IMapper _mapper;
        public AbstractService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
    }
}
