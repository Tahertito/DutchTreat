using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailServer _mailServer;
        private readonly IDutchRepository dutchRepository;
       

        public AppController(IMailServer mailServer, IDutchRepository dutchRepository)
        {
            _mailServer = mailServer;
            this.dutchRepository = dutchRepository;
           
        }
        public IActionResult Index()
        {
            //throw new IndexOutOfRangeException("index out of Range");
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {                     
            return View();
        }
        [HttpPost("contact")]
        public  IActionResult Contact(ContactsViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailServer.SendMail(model.Name, model.Subject, model.Message);
                ViewBag.Message = "mail sent";
                ModelState.Clear();
            }
           
           return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About Page";
            return View();
        }
        
        public IActionResult Shop()
        {
            var products = dutchRepository.GetAllProducts();
            return View(products);
        }
    }
}
