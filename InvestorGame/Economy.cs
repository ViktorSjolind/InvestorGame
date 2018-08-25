﻿using InvestorGame.Models;
using InvestorGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorGame
{
    internal class Economy
    {

        public bool MarketBoom;
        public bool MarketCrash;
        private int MaxEmptyPrice = 3000;
        private int MinEmptyPrice = 10;
        //Including lot
        private int MaxHousePrice = 6000;
        private int MinHousePrice = 2000;

        private int MaxShopPrice = 10000;
        private int MinShopPrice = 5000;

        private int MaxOfficePrice = 20000;
        private int MinOfficePrice = 10000;

        private List<Lot> Lots;

        public Economy(List<IMapComponents> mapComponents)
        {
            Lots = mapComponents.OfType<Lot>().ToList();
        }

        public void UpdateLotPrices()
        {
            foreach(Lot lot in Lots)
            {
                if (MarketBoom)
                {

                }

                else if (MarketCrash)
                {

                }
                else
                {
                    lot.Value = RandomGenerator.GetInteger(0, 2) < 1 ? LowerValue(lot.Value, lot.State) : HigherValue(lot.Value, lot.State);
                }
            }
        }

        public void EventMarketCrash()
        {
            foreach (Lot lot in Lots)
            {
                lot.Value = (int)(lot.Value * 0.6);
            }
        }

        public void EventMarketBoom()
        {
            foreach(Lot lot in Lots)
            {
                lot.Value = (int)(lot.Value * 1.4);
            }
        }

        private int HigherValue(int currentValue, LotState lotState)
        {
            int newValue;
            switch (lotState)
            {
                case LotState.Empty:
                    newValue = (int)(1.2d * currentValue);
                    return newValue <= MaxEmptyPrice ? newValue : currentValue;

                case LotState.House:
                    newValue = (int)(1.3d * currentValue);
                    return newValue <= MaxHousePrice ? newValue : currentValue;

                case LotState.Shop:
                    newValue = (int)(1.3d * currentValue);
                    return newValue <= MaxShopPrice ? newValue : currentValue;

                case LotState.Office:
                    newValue = (int)(1.1d * currentValue);
                    return newValue <= MaxOfficePrice ? newValue : currentValue;

                default:
                    return currentValue;
            }
        }

        private int LowerValue(int currentValue, LotState lotState)
        {
            int newValue;
            switch (lotState)
            {
                case LotState.Empty:
                    newValue = (int)(0.9d * currentValue);
                    return newValue <= MaxEmptyPrice && newValue >= MinEmptyPrice ? newValue : currentValue;

                case LotState.House:
                    newValue = (int)(0.8d * currentValue);
                    return newValue <= MaxHousePrice && newValue >= MinHousePrice ? newValue : currentValue;

                case LotState.Shop:
                    newValue = (int)(0.8d * currentValue);
                    return newValue <= MaxShopPrice && newValue >= MinShopPrice ? newValue : currentValue;

                case LotState.Office:
                    newValue = (int)(0.9d * currentValue);
                    return newValue <= MaxOfficePrice && newValue >= MinOfficePrice ? newValue : currentValue;

                default:
                    return currentValue;
            }
        }
    }
}