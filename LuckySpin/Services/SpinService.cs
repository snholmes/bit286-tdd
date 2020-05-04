using System;
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
            return 2.0;
        }

        //TODO Add and implement the method from the Interface

    }
}
