using ArvatoFront.ArvatoApi.Adapter;
using ArvatoFront.ArvatoApi.Adapter.Interfaces;
using ArvatoFront.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ArvatoFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IArvatoApiAdapter arvatoApiAdapter;
        private readonly IMapper mapper;

        public HomeController(
            ILogger<HomeController> logger,
            IArvatoApiAdapter arvatoApiAdapter,
            IMapper mapper)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.arvatoApiAdapter = arvatoApiAdapter ?? throw new ArgumentNullException(nameof(arvatoApiAdapter));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(CustomerSupportViewModel customerSupportViewModel)
        {
            if (ModelState.ContainsKey(nameof(CustomerSupportViewModel.Number)))
            {
                ModelState.Remove(nameof(CustomerSupportViewModel.Number));
            }

            if (ModelState.IsValid is false)
            {
                return View(customerSupportViewModel);
            }

            var customerSupport = mapper.Map<CustomerSupportPost>(customerSupportViewModel);
            arvatoApiAdapter.CreateCustomerSupportAsync(customerSupport);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
