using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Admin.Controllers
{
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService) : base()
        {
            this.orderService = orderService;

        }

        // GET: Order
        public ActionResult Index()
        {
            var order = orderService.GetAll();
            return View(order);            
        }

        public ActionResult Details(Guid id)
        {
            var order = orderService.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
    }
}