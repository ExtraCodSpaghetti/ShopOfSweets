using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOfSweets_DataAccess.Repository.IRepository;
using ShopOfSweets_Models;
using ShopOfSweets_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOfSweets_DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(OrderDetail obj)
        {
           _db.OrderDetail.Update(obj);
        }
    }
}
