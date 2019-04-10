using AutoMapper;
using JMAInsurance.Application.Service.Applicants;
using JMAInsurance.Application.Service.Products;
using JMAInsurance.Models.Dto;
using JMAInsurance.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JMAInsurance.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IProductsService _productsService;
        public ProductsController(IApplicantService applicantService, IProductsService productsService)
        {
            _applicantService = applicantService;
            _productsService = productsService;
        }
        // GET: Products
        public ActionResult ProductInfo()
        {
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
            var tracker = (Guid)Session["Tracker"];

            var products = new ProductsVM();
            var existingProducts = _applicantService.GetApplicantsByTraker(tracker)?.Products.FirstOrDefault();
            if (existingProducts != null)
            {
                //products = Mapper.Map<ProductsVM>(existingProducts);
                products.Collision = existingProducts.Collision;
                products.Comprehensive = existingProducts.Comprehensive;
                products.DriverRewards = existingProducts.DriverRewards;
                products.Liability = existingProducts.Liability;
                products.LoanPayoff = existingProducts.LoanPayoff;
                products.PropertyDamage = existingProducts.PropertyDamage;
                products.Rental = existingProducts.Rental;
                products.RoadSideAssistance = existingProducts.RoadSideAssistance;
            }

            return View(products);
        }

        [HttpPost]
        public ActionResult ProductInfo(ProductsVM vm)
        {
            if (Session["Tracker"] == null)
            {
                return RedirectToAction("ApplicantInfo", "Applicant");
            }
            var tracker = (Guid)Session["Tracker"];

            if (ModelState.IsValid)
            {
                var applicant = _applicantService.GetApplicantsByTraker(tracker);

                var existingProducts = applicant.Products.FirstOrDefault();
                if (existingProducts != null)
                {
                  Mapper.Map(vm, existingProducts);
                    _productsService.Update(Mapper.Map(vm, existingProducts));
                }
                else
                {
                    var newProducts = Mapper.Map<ProductsDto>(vm);
                    applicant.Products.Add(newProducts);
                }
                return RedirectToAction("Final", "Home");
            }
            return View();
        }
    }
}
