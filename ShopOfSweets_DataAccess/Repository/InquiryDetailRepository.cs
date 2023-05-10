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
    public class InquiryDetailRepository : Repository<InquiryDetail>, IInquiryDetailRepository
    {
        private readonly ApplicationDbContext _db;

        public InquiryDetailRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(InquiryDetail obj)
        {
           _db.InquiryDetail.Update(obj);
        }
    }
}
