using System;
using System.Collections.Generic;
using LuckySpin.Models;

namespace LuckySpin.Repositories
{
    public class SpinRepository
    {
        private List<Spin> spins = new List<Spin>();

        //Properties
        public Player CurrentPlayer { get; set; }
        public IEnumerable<Spin> PlayerSpins => spins;
        public int Length => spins.ToArray().Length;

        //Interaction method
        public void AddSpin(Spin s)
        {
            spins.Add(s);
        }

        
    }
}
