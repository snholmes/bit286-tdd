using System;
using System.Collections.Generic;
using LuckySpin.Models;

namespace LuckySpin.Repositories
{
    public interface ISpinRepository
    {
        public IEnumerable<Spin> GetSpins();
    }
}
