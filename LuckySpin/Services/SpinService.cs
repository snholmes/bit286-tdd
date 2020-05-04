using System;
using LuckySpin.Repositories;
namespace LuckySpin.Services
{
    public class SpinService //TODO make this class extend the Interface ISpinService
    {
        private SpinRepository spinRepository;
        //Constructor with Dependency Injection
        public SpinService(SpinRepository sr)
        {
            spinRepository = sr;

        }

        //TODO Add and implement the method from the Interface
        
    }
}
