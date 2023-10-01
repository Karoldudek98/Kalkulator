﻿using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Jan";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry" : "Dobry Wieczor";

            Dane[] osoby =
                {
                    new Dane {Name = "Anna", Surname = "Kowalska"},
                    new Dane {Name = "Karol", Surname = "Dudek"},
                    new Dane {Name = "Jan", Surname = "Kowalski"}
                };


            return View(osoby); //przekazanie tablicy do View
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult Calc(Calc calc)
        {
            ViewBag.dodawanie = $"Wynik dodawania to {calc.Number1 + calc.Number2}";
            ViewBag.odejmowanie = $"Wynik odejmowania to {calc.Number1 - calc.Number2}";
            ViewBag.mnozenie = $"Wynik mnozenia to {calc.Number1 * calc.Number2}";
            ViewBag.dzielenie = $"Wynik dzielenia to {calc.Number1 / calc.Number2}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}