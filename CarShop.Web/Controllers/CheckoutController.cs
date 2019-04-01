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
          IOrderProductsService orderProductsService, ILocationService locationService) : base(categoryService)
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
            //var order = new Order();
            //order.Id = Guid.NewGuid();
            //orderService.Insert(order);
            var cartProducts = cartService.GetAll();
          
            

            foreach (var item in cartProducts)
            {
                var orderProducts = new OrderProducts();
               

                //foreach (var testItem in orderProductsService.GetAll())
                //{
                //    if(testItem.ProductName == item.ProductName)
                //    {
                //        contains = true;
                //    }
                //}

                if (orderProductsService.GetAll().FirstOrDefault() == null)
                {
                    orderProducts.ProductName = item.ProductName;
                    orderProducts.Priece = item.Price;
                    orderProducts.Quantity = item.Piece;
                    orderProducts.TotalPrice = item.Price * item.Piece;
                    //orderProducts.OrderId = order.Id;
                    orderProductsService.Insert(orderProducts);
                    contains = true;
                }else 
                {
                    foreach (var currentitem in orderProductsService.GetAll())
                    {
                        if(currentitem.ProductName == item.ProductName)
                        {
                            orderProducts.ProductName = item.ProductName;
                            orderProducts.Priece = item.Price;
                            orderProducts.Quantity = item.Piece;
                            orderProducts.TotalPrice = item.Price * item.Piece;
                            //orderProducts.OrderId = order.Id;
                            orderProductsService.Update(orderProducts);
                        }

                    }
                   

                }


                //bool contains = false;
                //var orderProducts = new OrderProducts();

                //foreach (var orderItem in orderService.GetAll().Where(o => o.Id == order.Id))
                //{
                //    foreach (var orderProducts in orderItem.OrderProducts)
                //    {
                //        orderProducts.ProductName = item.ProductName;
                //        orderProducts.Priece = item.Price;
                //        orderProducts.Quantity = item.Piece;
                //        orderProductsService.Insert(orderProducts);
                //    }


                //    //if (orderItem.OrderProducts == item.ProductName)

                //    //    contains = true;
                //}

                //if (contains == false)
                //{
                //    orderProducts.ProductName = item.ProductName;
                //    orderProducts.Priece = item.Price;
                //    orderProducts.Quantity = item.Piece;
                //    orderProducts.TotalPrice = item.Piece * item.Price;
                //    orderProducts.OrderId = order.Id;
                //    orderProductsService.Insert(orderProducts);
                //}

            }

            ViewBag.OrderProducts = orderProductsService.GetAll();



            var countries = countryService.GetAll();
            var cities = cityService.GetAll();
            var districts = districtService.GetAll();
            ViewBag.CountryId = new SelectList(countries.OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.CityId = new SelectList(cities.OrderBy(c => c.Name).Where(w => w.CountryId == location.CountryId).ToList(), "Id", "Name");
            ViewBag.DistrictId = new SelectList(districts.OrderBy(c => c.Name).Where(w => w.CityId == location.CityId).ToList(), "Id", "Name");

            //using (var db = new ApplicationDbContext())
            //{
            //    location.Id = Guid.NewGuid();
            //    db.Locations.Add(location);
            //    db.SaveChanges();
            //}

            return View(location);
        }
        [HttpPost]
        public ActionResult Index(Guid currentOrderId,Location location, string firstName, string lastName, string adress, string phone, string email, string byBankTransfer, string atDelivery)
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
            foreach (var item in orderProductsService.GetAll().Where(p => p.OrderId == null))
            {
                item.OrderId = order.Id;
                orderProductsService.Update(item);
            }

            var orderId = orderService.Find(order.Id);
           


            //try
            //{
            //    using (var db = new ApplicationDbContext())
            //    {
            //        location.Id = Guid.NewGuid();
            //        db.Locations.Add(location);
            //        db.SaveChanges();
            //        return Json(new { success = true });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Json(new { success = false, message = ex.Message });
            //}
            

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