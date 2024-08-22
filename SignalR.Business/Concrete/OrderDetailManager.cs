using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDal _ordeRdal;

        public OrderDetailManager(IOrderDal ordeRdal)
        {
            _ordeRdal = ordeRdal;
        }

        public void TAdd(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public OrderDetail TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
