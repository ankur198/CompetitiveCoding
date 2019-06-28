using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PhilalandCoin
{
    class SelectedCoins
    {
        public int Index { get; set; }
        public List<int> Coins { get; set; }

        public SelectedCoins()
        {
            Coins = new List<int>();
        }

        public int BuyDifference(int n)
        {
            minDifference = Int32.MaxValue;
            traverse(0, new List<int>(), n);
            return minDifference;
        }

        int minDifference;

        void traverse(int index, List<int> currentCoins, int remDifference)
        {
            if (remDifference < minDifference && remDifference > -1)
            {
                minDifference = remDifference;
            }
            if (remDifference > -1 && index < Coins.Count)
            {
                var c1 = new List<int>(currentCoins);
                var c2 = new List<int>(currentCoins);
                var value = Coins[index];
                c1.Add(value);
                index++;

                traverse(index, c1, remDifference - value);
                traverse(index, c2, remDifference);
            }
        }
    }

    class Builder
    {
        public List<int> MinimizeCoins(int maxValue)
        {
            SelectedCoins node = new SelectedCoins();
            int coin = 1;
            for (int i = 1; i < maxValue+1; i++)
            {
                var diff = node.BuyDifference(i);
                if (diff > 0)
                {
                    node.Coins.Add(coin++);
                }
            }

            return node.Coins;
        }
    }
}
