using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class DashboardsController : Controller
    {
        public ActionResult Dashboard_1()
        {
            return View();
        }

        
        public ActionResult CreateError500()
        {
            var ai = new TelemetryClient();
            ai.TrackException(new HttpException(500, "CreateError500"));
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult CreateEvent()
        {
            var ai = new TelemetryClient();
            ai.TrackEvent("Event trigger demo");
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult CreateTrace()
        {
            var ai = new TelemetryClient();
            ai.TrackTrace("Slow database response",
               SeverityLevel.Warning,
               new Dictionary<string, string> { { "database", "123" } });
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

    }
}