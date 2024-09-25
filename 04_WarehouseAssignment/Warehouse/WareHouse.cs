using System.ComponentModel.Design;
using Warehouse;


namespace WareHouse
{

    public class WareHouse
    {

        private List<Stock> _stockOfItems;
        public void WareHouseSimulator()
        {
            _stockOfItems = new();
            Stock item1 = new("Hat", 2);
            Stock item2 = new("Shoes", 3);
            Stock item3 = new("Jacket", 5);

            _stockOfItems.Add(item1);
            _stockOfItems.Add(item2);
            _stockOfItems.Add(item3);
        }

        public WareHouse()
        {
            _stockOfItems= new();
        }

        public void AddToStocks(string itemName, int itemCount)
        {
            if (itemCount>0) 
            {
                Stock stockExisting = _stockOfItems.FirstOrDefault(item => item.ItemName == itemName);

                if (stockExisting != null)
                {
                    stockExisting.Quantity += itemCount;
                }
                else
                {
                    Stock newStock=new Stock(itemName, itemCount);
                    _stockOfItems.Add (newStock);

                }

            }else { throw new ArgumentOutOfRangeException(); }

           

            
        }

        public bool InStock(string itemName)
        {
            return _stockOfItems.Any(item => item.ItemName == itemName && item.Quantity > 0);
        }

        public void TakeFromStock(string itemName, int quantity)
        {
            Stock? stock = null;
            if (InStock(itemName))
            {

                stock = _stockOfItems.FirstOrDefault(item => item.Quantity > 0);
                if (stock.Quantity >= quantity)
                {
                    stock.Quantity -= quantity;
                }
                else
                {
                    throw new Exception("Oversold " + stock.ItemName);
                }

            }
            else
            {
                throw new Exception("Oversold " + stock.ItemName);
            }
        }

        public int StockCount(string itemName)
        {
            Stock matching = _stockOfItems.FirstOrDefault(item=>item.ItemName==itemName);

            if (matching != null) 
            {
                return matching.Quantity;
            } else 
            {
                throw new Exception();
            }
        }

    }

}

