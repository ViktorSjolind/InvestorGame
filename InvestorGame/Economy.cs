using InvestorGame.Models;
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
        private int MaxHousePrice = 3000 + 10000 + 2000;
        private int MinHousePrice = 2000;

        private int MaxShopPrice = 3000 + 15000 + 5000;
        private int MinShopPrice = 5000;

        private int MaxOfficePrice = 3000 + 30000 + 2000;
        private int MinOfficePrice = 10000;

        public int BuildHousePrice = 10000;
        public int BuildShopPrice = 15000;
        public int BuildOfficePrice = 30000;

        public int MaxShopIncome = 100;
        public int MinShopIncome = 25;

        public int MaxOfficeIncome = 200;
        public int MinOfficeIncome = 50;

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
                    if(lot.Income == 0)
                    {
                        switch (lot.State)
                        {
                            case LotState.Shop:
                                lot.Income = MinShopIncome;
                                break;

                            case LotState.Office:
                                lot.Income = MinOfficeIncome;
                                break;
                        }
                    }
                    lot.Income = RandomGenerator.GetInteger(0, 2) < 1 ? LowerIncome(lot.Income, lot.State) : HigherIncome(lot.Income, lot.State);
                    if(lot.Owner == Player.Human)
                    {
                        lot.TotalIncome += lot.Income;
                        Game.Money += lot.Income;
                    }
                    
                }
            }
        }


        private int HigherIncome(int currentIncome, LotState lotState)
        {
            int newIncome;
            switch (lotState)
            {
                case LotState.Shop:
                    newIncome = (int)(1.2d * currentIncome);
                    return newIncome <= MaxShopIncome ? newIncome : currentIncome;

                case LotState.Office:
                    newIncome = (int)(1.2d * currentIncome);
                    return newIncome <= MaxOfficeIncome ? newIncome : currentIncome;

                default:
                    return 0;
            }
        }


        private int LowerIncome(int currentIncome, LotState lotState)
        {
            int newIncome;
            switch (lotState)
            {
                case LotState.Shop:
                    newIncome = (int)(0.9d * currentIncome);
                    return newIncome >= MinShopIncome ? newIncome : currentIncome;

                case LotState.Office:
                    newIncome = (int)(0.9d * currentIncome);
                    return newIncome >= MinOfficeIncome ? newIncome : currentIncome;

                default:
                    return 0;
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
