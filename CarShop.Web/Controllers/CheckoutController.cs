using CarShop.Data;
using CarShop.Model;
using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Web.Controllers
{
    public class CheckoutController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IOrderService orderService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly IDistrictService districtService;
        public CheckoutController(IProductService productService, ICategoryService categoryService, IOrderService orderService,
          ICountryService countryService, ICityService cityService, IDistrictService districtService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.orderService = orderService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.districtService = districtService;
        }
        public ActionResult GetCities(Guid? countryId)
        {
            //using (var db = new ApplicationDbContext())
            //{
            var db = cityService.GetAll();
                var cities = db.Where(c => c.CountryId == countryId).OrderBy(o => o.Name).Select(x => new { x.Id, x.Name }).ToList();
                return Json(cities);
            //}
        }
        public ActionResult GetDistricts(Guid? cityId)
        {
            //using (var db = new ApplicationDbContext())
            //{
            var db = districtService.GetAll();
                var districts = db.Where(c => c.CityId == cityId).OrderBy(o => o.Name).Select(x => new { x.Id, x.Name }).ToList();
                return Json(districts);
            //}
        }
        // GET: Checkout
        public ActionResult Index()
        {
            var order = new  Order();

            //using (var db = new ApplicationDbContext())
            //{
            var countries = countryService.GetAll();
            var cities = cityService.GetAll();
            var districts = districtService.GetAll();
                ViewBag.CountryId = new SelectList(countries.OrderBy(c => c.Name).ToList(), "Id", "Name");
                ViewBag.CityId = new SelectList(cities.OrderBy(c => c.Name).Where(w => w.CountryId == order.CountryId).ToList(), "Id", "Name");
                ViewBag.DistrictId = new SelectList(districts.OrderBy(c => c.Name).Where(w => w.CityId == order.CityId).ToList(), "Id", "Name");
            //}

            return View(order);
        }
        [HttpPost]
        public ActionResult Index(Order order)
        {




            try
            {
                using (var db = new ApplicationDbContext())
                {
                    order.Id = Guid.NewGuid();
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }
    }
}