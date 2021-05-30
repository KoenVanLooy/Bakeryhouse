using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BakeryHouse.Data;
using BakeryHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BakeryHouse.Controllers
{
    public class ErrorController : Controller
    {
        //private readonly BakeryHouseContext _context;

        //public ErrorController(BakeryHouseContext context)
        //{
        //    _context = context;
        //}

        //[Route("Error/{statusCode}")]
        //public IActionResult HttpStatusCodeHandler(int statusCode)
        //{
        //    string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
        //    var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
        //    switch (statusCode)
        //    {
        //        case 404:
        //            ViewBag.ErrorMessage = "Sorry deze Taart Bestaat niet!";
        //            ViewBag.Path = statusCodeResult.OriginalPath;
        //            ViewBag.Qs = statusCodeResult.OriginalQueryString;
        //            break;
        //    }
        //    return View("NotFound");
        //}

        //[Route("Error")]
        //[AllowAnonymous]
        //public IActionResult Error()
        //{
        //    var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        //    ViewBag.ExceptionPath = exceptionDetails.Path;
        //    ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
        //    ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

        //    return View("Error");

        //}
    }
}
