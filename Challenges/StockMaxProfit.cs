using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    public class StockMaxProfit
    {
        int[] input;

        public StockMaxProfit(int[] input)
        {
            this.input = input;
        }

        public int GetResult()
        {
            int buy = input[0];
            int sell = input[0];
            int currentBestProfit = -1;

            foreach (int price in input.Skip(1))
            {
                if (price < buy)
                {
                    UpdateCurrentBestProfit(sell - buy, ref currentBestProfit);
                    buy = price;
                    sell = price;
                }
                else if (price > sell)
                    sell = price;
            }

            UpdateCurrentBestProfit(sell - buy, ref currentBestProfit);
            return currentBestProfit;
        }

        private void UpdateCurrentBestProfit(int profit, ref int bestProfit)
        {
            bestProfit = (profit > 0 && profit > bestProfit) ?
                profit :
                bestProfit;
        }
    }
}
