namespace shoppingList.Models
{
    public class ShoppingProducts
    {
        public int pID { get; set; }
        public string pName { get; set; }
        public double pPrice { get; set; }

        public string pCategory { get; set; }

        public bool isInStock { get; set; }

        public string pDescription { get; set; }


        private static List<ShoppingProducts> cList = new List<ShoppingProducts>() { };
  
        private static List<ShoppingProducts> pList = new List<ShoppingProducts>()
        {
            new ShoppingProducts() {pID = 100, pName ="Mobiles", pCategory ="Gadgets", pPrice=10000, isInStock = true, pDescription ="Its Mobile Phone" },
             new ShoppingProducts() {pID = 101, pName ="Tablets", pCategory ="Gadgets", pPrice=25000, isInStock = true, pDescription ="Its Tablet" },
              new ShoppingProducts() {pID = 102, pName ="Laptops", pCategory ="Gadgets", pPrice=750000, isInStock = false, pDescription ="Its Laptop" },
               new ShoppingProducts() {pID = 103, pName ="EarPhone", pCategory ="Electronics Accessory", pPrice=3000, isInStock = true, pDescription ="Its Electronic accesory used for mobiles,tablets,laptop,PC's" },
                new ShoppingProducts() {pID =104, pName ="Washing Machine", pCategory ="Appliance", pPrice=6000, isInStock = true, pDescription ="Its Home appliance to wash " },
                new ShoppingProducts() {pID =105, pName ="Grinder", pCategory ="Appliance", pPrice=3000, isInStock = true, pDescription ="Its Home appliance to grind cooking items " },
                new ShoppingProducts() {pID =106, pName ="Black Mamba", pCategory ="Personal", pPrice=600, isInStock = true, pDescription ="Its Book - for self growth" },
                new ShoppingProducts() {pID =107, pName ="Kettle", pCategory ="Appliance", pPrice=1000, isInStock = true, pDescription ="Its Home appliance to heat water" },
                new ShoppingProducts() {pID =108, pName ="Chair", pCategory ="Furniture", pPrice=2500, isInStock = false, pDescription ="Its Furniture to Sit " },
                new ShoppingProducts() {pID =109, pName ="Maggi", pCategory ="Eatables", pPrice=25, isInStock = true, pDescription ="Its quick eatery" },
        };

        public List<ShoppingProducts> GetAllShoppingProducts()
        {
            return pList;
        }

        public List<ShoppingProducts> GetShoppingProductsByType(string ctg)
        {
            var shp = pList.FindAll(e => e.pCategory == ctg);

            if (shp != null)
            {
                return shp;
            }

            throw new Exception("ShoppingProducts not found");

        }

        public ShoppingProducts GetShoppingProductsByName(string name)
        {
            var shp = pList.Find(e => e.pName == name);

            if (shp != null)
            {
                return shp;
            }

            throw new Exception("ShoppingProducts not found by name " + name);

        }
        public List<ShoppingProducts> GetInstockShoppingProducts(bool stock)
        {
            var shps = pList.FindAll(e => e.isInStock == stock);
            return shps;
        }
        public int GetTotalShoppingProducts()
        {
            var total = pList.Count;
            return total;
        }

        public string AddShoppingProducts(ShoppingProducts obj)
        {
            pList.Add(obj);
            return ("ShoppingProducts added" + obj);

        }

        public string UpdateShoppingProducts(ShoppingProducts obj)
        {
            var shp = pList.Find(e => e.pID == obj.pID);

            if (shp != null)
            {
                shp.pName = obj.pName;
                shp.pCategory = obj.pCategory;
                shp.pPrice = obj.pPrice;
                shp.isInStock = obj.isInStock;
                return "ShoppingProducts has been updated";

            }
            throw new Exception("ShoppingProducts not found by the ID" + obj.pID);

        }

        public string DeleteShoppingProducts(int id)
        {
            var shp = pList.Find(e => e.pID == id);
            if (shp != null)
            {
                pList.Remove(shp);
                return "ShoppingProducts Deleted";
            }
            throw new Exception("ShoppingProducts Not Found");

        }

        public string AddProductsToCart(int id)
        {
            var shp = pList.Find(e => e.pID == id);
            if (shp != null)
            {
                cList.Add(shp);
            }
            return ("ShoppingProducts added to cart" + shp);

        }

        public List<ShoppingProducts> GetAllCartProducts()
        {
            return cList;
        }
    }
}
