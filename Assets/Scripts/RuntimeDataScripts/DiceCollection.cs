using UnityEngine;
using System.Collections.Generic;

namespace Encounter
{
    public sealed class DiceCollection
    {
        private List<DieData> _dice;
        public List<DieData> Dice { get { return _dice; } }

        public DiceCollection()
        {
            _dice = new List<DieData>();
        }
        public DiceCollection(List<DieData> dice)
        {
            _dice = dice;
        }
    }
}
