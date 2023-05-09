using System;
using System.Collections.Generic;
using LuckySpin.Models;

namespace LuckySpin.Repositories
{
    public class SpinRepository: ISpinRepository
    {
        private List<Spin> spins = new List<Spin>();
        private Player currentPlayer;

        //Properties
        private Player CurrentPlayer => currentPlayer;
        public IEnumerable<Spin> PlayerSpins => spins;
        public int Length => spins.ToArray().Length;

        public void AddPlayer(Player player)
        {
            currentPlayer = player;
        }
        public Boolean ChargePlayer()
        {
            return currentPlayer.ChargeSpin();
        }
        public decimal GetBalance()
        {
            return currentPlayer.Balance;
        }
        
        public void AddSpin(Spin s)
        {
            s.Player = currentPlayer;
            spins.Add(s);
        }
        public IEnumerable<Spin> GetSpins() { return spins; }

        public void CollectWinnings()
        {
            currentPlayer.CollectWinnings();
        }

        //TODO: Create Average Spin
    }
}
