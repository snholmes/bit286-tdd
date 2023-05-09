using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.Services;
using LuckySpin.Repositories;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        private ISpinService spinService;
        private ISpinRepository spinRepository;
        Random random = new Random();

        /***
         * Controller Constructor with Dependency Injection of a SpinRepository object
         */
        public SpinnerController(ISpinRepository r, ISpinService ss) //TODO also inject a ISpinService object
        {
            spinRepository = r;
            //TODO: assign the spinService property the injected value
            spinService = ss;
        }

        /***
         * Entry Page Action
         **/

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (!ModelState.IsValid) { return View(); }

            player.AddCredit(player.StartingBalance);

         //Save the current player in the repository
            spinRepository.AddPlayer( player );
            return RedirectToAction("SpinIt");         
        }

        /***
         * Spin Action
         **/  
         [HttpGet]      
         public IActionResult SpinIt(int luck) //use the repository value
        {
            //Check if enough balance to play, if not drop out to LuckList
            if (!spinRepository.ChargePlayer())
            {
                return RedirectToAction("LuckList");
            }

            //Create the current Spin
            Spin spin = new Spin();

            //Add to Spin Repository
            spinRepository.AddSpin(spin);

            //Prepare the View
            if (spin.IsWinning)
            {
                ViewBag.Display = "block";
                spinRepository.CollectWinnings();
            }
            else
                ViewBag.Display = "none";

            
            ViewBag.Balance = spinRepository.GetBalance();

            //Use the service to compute the average wins
            spin.averageWins = spinService.averageWins();
            return View("SpinIt", spin);
        }

        /***
         * ListSpins Action
         **/

         public IActionResult LuckList()
        {
            ViewBag.Balance = 0;
            return View(spinRepository.GetSpins());
        }

    }
}

