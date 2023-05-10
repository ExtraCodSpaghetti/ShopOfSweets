﻿using Microsoft.AspNetCore.Mvc;
using ShopOfSweets_Models;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ShopOfSweets_Utility;
using ShopOfSweets_DataAccess;
using ShopOfSweets_DataAccess.Repository;
using ShopOfSweets_DataAccess.Repository.IRepository;
using ShopOfSweets_Models.ViewModels;

namespace ShopOfSweets.ApplicationTypeController 
{
    [Authorize(Roles = WC.AdminRole)]
    public class InquiryController : Controller
    {
       private readonly IInquiryDetailRepository _inqDRepo;
       private readonly IInquiryHeaderRepository _inqHRepo;
        [BindProperty]
        public InquiryVM InquiryVM { get; set; }

        public InquiryController(IInquiryDetailRepository inqDRepo, IInquiryHeaderRepository inqHRepo)
        {
            _inqHRepo = inqHRepo;
            _inqDRepo = inqDRepo;
        }
        public IActionResult Index ()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            InquiryVM = new InquiryVM()
            {
                InquiryHeader = _inqHRepo.FirstOrDefault(u => u.Id == id),
                InquiryDetail = _inqDRepo.GetAll(u => u.InquiryHeaderId == id, includeProperties: "Product")
            };
            return View(InquiryVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>(); 
            InquiryVM.InquiryDetail = _inqDRepo.GetAll(u => u.InquiryHeaderId == InquiryVM.InquiryHeader.Id); 

            foreach(var detail in InquiryVM.InquiryDetail)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    ProductId = detail.ProductId,
                };
                shoppingCartList.Add(shoppingCart);
            }
            HttpContext.Session.Clear();
            HttpContext.Session.Set(WC.SessionCart, shoppingCartList);
            HttpContext.Session.Set(WC.SessionInquiryId, InquiryVM.InquiryHeader.Id);

            return RedirectToAction("Index","Cart");
        }


        [HttpPost]
        public IActionResult Delete()
        {
            InquiryHeader inquiryHeader = _inqHRepo.FirstOrDefault(u => u.Id == InquiryVM.InquiryHeader.Id); // aktualne znaczenie InquiryHeader
            IEnumerable<InquiryDetail> inquiryDetails = _inqDRepo.GetAll(u => u.InquiryHeaderId == InquiryVM.InquiryHeader.Id);

            _inqDRepo.RemoveRange(inquiryDetails);
            _inqHRepo.Remove(inquiryHeader);
            _inqHRepo.Save();
            TempData[WC.Success] = "Action completed successfully";
            return RedirectToAction(nameof(Index));
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetInquiryList ()
        {
            return Json(new { data = _inqHRepo.GetAll() });
        }
        #endregion
    }
}
