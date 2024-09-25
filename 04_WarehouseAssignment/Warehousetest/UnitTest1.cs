using Warehouse;
namespace Warehousetest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToStock_WithPositiveNumber()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item,12);

            bool result= wareHouse.InStock(item);
            int expected = 12;
            int actual = wareHouse.StockCount(item);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToStock_WithZeroValue()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wareHouse.AddToStocks(item, 0));

        }

        [TestMethod]
        public void AddToStock_NegativeValue()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wareHouse.AddToStocks(item, -7));

        }

        [TestMethod]
        public void InStock_PositiveAmount()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item, 12);

            bool result = wareHouse.InStock(item);
            int expected = 12;
            int actual = wareHouse.StockCount(item);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void InStock_ZeroAmount_Success()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item, 11);

            wareHouse.TakeFromStock(item, 11);

            bool result = wareHouse.InStock(item);
            int expected = 0;
            int actual = wareHouse.StockCount(item);

            Assert.IsFalse(result);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InStock_NegativeAmount()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item, 11);

            Assert.ThrowsException<Exception>(() => wareHouse.TakeFromStock(item, 35));

            bool result = wareHouse.InStock(item);
            int expected = 11;
            int actual = wareHouse.StockCount(item);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TakeFromStock_TakeItems_Success() 
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item, 12);

            wareHouse.TakeFromStock(item, 12);

            bool result = wareHouse.InStock(item);
            int expected = 0;
            int actual = wareHouse.StockCount(item);

            Assert.IsFalse(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TakeFromStock_TakeZeroItems_Success() 
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item, 5);

            wareHouse.TakeFromStock(item, 0);

            bool result = wareHouse.InStock(item);
            int expected = 5;
            int actual = wareHouse.StockCount(item);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToStock_SameItemTwice_Success()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item, 5);
            wareHouse.AddToStocks(item, 5);
            bool result = wareHouse.InStock(item);
            int expected = 10;
            int actual = wareHouse.StockCount(item);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToStock_TakeFromStock_Success()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(item, 5);

            int expected = 5;
            int actual = wareHouse.StockCount(item);

            Assert.AreEqual(expected, actual);

            wareHouse.TakeFromStock(item, 5);

            bool result = wareHouse.InStock(item);
            int wanted = 0;
            int gotten = wareHouse.StockCount(item);

            Assert.IsFalse(result);
            Assert.AreEqual(wanted, gotten);
        }

        [TestMethod]
        public void StockCount_NoItem_Exception()
        {
            string item = "Jeans";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            Assert.ThrowsException<Exception>(() => wareHouse.StockCount(item));
        }

    }
}