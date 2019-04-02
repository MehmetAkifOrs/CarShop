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
        private readonly ILocationService locationService;


        bool contains = false;


        public CheckoutController(IProductService productService, ICategoryService categoryService, IOrderService orderService,
          ICountryService countryService, ICityService cityService, IDistrictService districtService, ICartService cartService,
          IOrderProductsService orderProductsService, ILocationService locationService) : base(categoryService, cartService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.orderService = orderService;
            this.countryService = countryService;
            this.cityService = cityService;
            this.districtService = districtService;
            this.cartService = cartService;
            this.orderProductsService = orderProductsService;
            this.locationService = locationService;
        }
        public ActionResult GetCities(Guid? countryId)
        {

            var db = cityService.GetAll();
            var cities = db.Where(c => c.CountryId == countryId).OrderBy(o => o.Name).Select(x => new { x.Id, x.Name }).ToList();
            return Json(cities);

        }
        public ActionResult GetDistricts(Guid? cityId)
        {

            var db = districtService.GetAll();
            var districts = db.Where(c => c.CityId == cityId).OrderBy(o => o.Name).Select(x => new { x.Id, x.Name }).ToList();
            return Json(districts);

        }
        // GET: Checkout
        public ActionResult Index()
        {
            var location = new Location();

            ViewBag.CurrentOrders = cartService.GetAll();

           

            var countries = countryService.GetAll();
            var cities = cityService.GetAll();
            var districts = districtService.GetAll();
            ViewBag.CountryId = new SelectList(countries.OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.CityId = new SelectList(cities.OrderBy(c => c.Name).Where(w => w.CountryId == location.CountryId).ToList(), "Id", "Name");
            ViewBag.DistrictId = new SelectList(districts.OrderBy(c => c.Name).Where(w => w.CityId == location.CityId).ToList(), "Id", "Name");

          

            return View(location);
        }
        [HttpPost]
        public ActionResult Index(Location location, string firstName, string lastName, string adress, string phone, string email, string byBankTransfer, string atDelivery)
        {


            var order = new Order();
            order.Id = Guid.NewGuid();
           
            //orderService.Insert(order);

            order.CountryName = countryService.GetAll().Where(c => c.Id == location.CountryId).FirstOrDefault().Name;
            order.CityName = cityService.GetAll().Where(c => c.Id == location.CityId).FirstOrDefault().Name;
            order.DistrictName = districtService.GetAll().Where(c => c.Id == location.DistrictId).FirstOrDefault().Name;
            order.CustomerFirstName = firstName;
            order.CustomerLastName = lastName;
            order.Email = email;
            order.Phone = phone;
            order.Address = adress;
            orderService.Insert(order);
            foreach (var item in cartService.GetAll())
            {
                var orderProduct = new OrderProducts();
                orderProduct.ProductName = item.ProductName;
                orderProduct.Priece = item.Price;
                orderProduct.Quantity = item.Piece;
                orderProduct.OrderId = order.Id;
                orderProductsService.Insert(orderProduct);
            }
           
            foreach (var item in orderProductsService.GetAll().Where(p => p.OrderId == null))
            {
                item.OrderId = order.Id;
                orderProductsService.Update(item);
            }

            var orderId = orderService.Find(order.Id);       
                                 
            

            if(byBankTransfer == "on")
            {
                return RedirectToAction("ByBankTransfer",orderId);
            }
            else
            {
                return RedirectToAction("CompleteShop");
            }


           

        }
        public ActionResult ByBankTransfer(Order orderId)
        {

            return View(orderId);
        }

        [HttpPost]
        public ActionResult ByBankTransfer(Guid id,string name,string idNumner, string bankName, string bankIban)
        {
            var currentOrder = orderService.Find(id);
            currentOrder.SenderName = name;
            currentOrder.IdNumber = idNumner;
            currentOrder.BankName = bankName;
            currentOrder.BankIban = bankIban;
            orderService.Update(currentOrder);



            return RedirectToAction("CompleteShop");
        }

        public ActionResult CompleteShop()
        {
            foreach (var item in cartService.GetAll())
            {
                cartService.Delete(item);
            }
            return View();
        }
    }
}