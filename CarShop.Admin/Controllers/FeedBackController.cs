using CarShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Admin.Controllers
{
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackService feedbackService;

        public FeedBackController(IFeedBackService feedbackService) : base()
        {
            this.feedbackService = feedbackService;

        }

        // GET: FeedBack
        public ActionResult Index()
        {
            var feedback = feedbackService.GetAll();
            return View(feedback);
        }

        public ActionResult Details(Guid id)
        {
            var feedback = feedbackService.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }
    }
}