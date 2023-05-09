using System;
using System.Collections.Generic;
using LuckySpin.Models;

namespace LuckySpin.Repositories
{
    public interface ISpinRepository
    {
        public void AddPlayer(Player p);
        public Boolean ChargePlayer();
        public void CollectWinnings();
        public decimal GetBalance();
        public void AddSpin(Spin s);
        public IEnumerable<Spin> GetSpins();
    }
}
