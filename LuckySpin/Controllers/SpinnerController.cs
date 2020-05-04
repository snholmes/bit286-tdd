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
        private SpinRepository spinRepository;
        Random random = new Random();

        /***
         * Controller Constructor with Dependency Injection of a SpinRepository object
         */
        public SpinnerController(SpinRepository r) //TODO also inject a ISpinService object
        {
            spinRepository = r;
            //TODO: assign the spinService property the injected value
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
            if (ModelState.IsValid) {
                //Save the current player in the repository
                spinRepository.CurrentPlayer = player;
                spinRepository.CurrentPlayer.AddCredit(player.StartingBalance);
                return RedirectToAction("SpinIt");
            }

            return View();
        }

        /***
         * Spin Action
         **/  
         [HttpGet]      
         public IActionResult SpinIt(int luck) //use the repository value
        {
            //Check if enough balance to play, if not drop out to LuckList
            if (!spinRepository.CurrentPlayer.ChargeSpin())
            {
                return RedirectToAction("LuckList");
            }

            //Create the current Spin
            Spin spin = new Spin
            {
                Luck = luck > 0 ? luck : spinRepository.CurrentPlayer.Luck,
                A = random.Next(1, 10),
                B = random.Next(1, 10),
                C = random.Next(1, 10)
            };
            spin.IsWinning = (spin.A == spin.Luck || spin.B == spin.Luck || spin.C == spin.Luck);

            //Use the service to compute the average wins
            spin.averageWins = spinService.averageWins();

            //Add to Spin Repository
            spinRepository.AddSpin(spin);

            //Prepare the View
            if (spin.IsWinning)
            {
                ViewBag.Display = "block";
                spinRepository.CurrentPlayer.CollectWinnings();
            }
            else
                ViewBag.Display = "none";

            ViewBag.FirstName = spinRepository.CurrentPlayer.FirstName;
            ViewBag.Balance = spinRepository.CurrentPlayer.Balance;

            return View("SpinIt", spin);
        }

        /***
         * ListSpins Action
         **/

         public IActionResult LuckList()
        {
            ViewBag.Balance = 0;
            return View(spinRepository.PlayerSpins);
        }

    }
}

