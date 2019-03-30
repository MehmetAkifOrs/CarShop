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
        private readonly ICartService cartService;
        private readonly IOrderProductsService orderProductsService;
        public CheckoutController(IProductService productService, ICategoryService categoryService, IOrderService orderService,
          ICountryService countryService, ICityService cityService, IDistrictService districtService, ICartService cartService,
          IOrderProductsService orderProductsService) : base(categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.orderService = orderService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.districtService = districtService;
            this.cartService = cartService;
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
           
            var location = new Location();
            var cartProducts = cartService.GetAll();
            var orderProducts = orderProductsService.GetAll();
            
            foreach (var item in cartProducts)
            {

                foreach (var orderItem in orderProducts)
                {
                    orderItem.ProductName = item.ProductName;
                    orderItem.Priece = item.Piece;
                    orderItem.Quantity = item.Piece;
                    orderItem.TotalPrice = item.Piece * item.Price;
                }

                //bool contains = false;

                //foreach (var orderItem in orderProductsService.GetAll())
                //{
                //    if(orderItem.ProductName == item.ProductName)
                //    {
                //       contains = true;
                //    }

                //}
                //var order = new Order();

                //if (contains == false)
                //{
                //    order.OrderProducts.P = item.Piece * item.Price;
                //    order.Orders = item.ProductName;
                //    order.piece = item.Piece;
                //    orderService.Insert(order);
                //}

            }

            ViewBag.OrderProducts = orderProductsService.GetAll();
           

            //using (var db = new ApplicationDbContext())
            //{
            var countries = countryService.GetAll();
            var cities = cityService.GetAll();
            var districts = districtService.GetAll();
                ViewBag.CountryId = new SelectList(countries.OrderBy(c => c.Name).ToList(), "Id", "Name");
                ViewBag.CityId = new SelectList(cities.OrderBy(c => c.Name).Where(w => w.CountryId == location.CountryId).ToList(), "Id", "Name");
                ViewBag.DistrictId = new SelectList(districts.OrderBy(c => c.Name).Where(w => w.CityId == location.CityId).ToList(), "Id", "Name");
            //}

            return View(location);
        }
        [HttpPost]
        public ActionResult Index(Location location)
        {


            try
            {
                using (var db = new ApplicationDbContext())
                {
                    location.Id = Guid.NewGuid();
                    db.Locations.Add(location);
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