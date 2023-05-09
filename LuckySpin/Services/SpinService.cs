using System;
using LuckySpin.Models;
using LuckySpin.Repositories;
namespace LuckySpin.Services
{
    public class SpinService : ISpinService//TODO make this class extend the Interface ISpinService
    {
        private ISpinRepository spinRepository;
        //Constructor with Dependency Injection
        public SpinService(ISpinRepository sr)
        {
            spinRepository = sr;

        }

        public double averageWins()
        {
            
            IEnumerable<Spin> spins = spinRepository.GetSpins();
            int wins = 0;
            double count = 0;
            foreach (Spin s in spins) {
                if (s.IsWinning) { wins++; }
                count++;
            }

            return wins/count;
        }

        //TODO Add and implement the method from the Interface

    }
}
