using exercise.main;
using exercise.main.StoreItem;

namespace exercise.tests;

public class StoreTests
{
    [Test]
    public void CreateStoreTest()
    {
        Store testStore = new Store("testStore", 50);

        Assert.That(testStore.Name == "testStore" && testStore.MaxCapacity == 50 && testStore.InventoryDict.Values.Count == 0);
    }

    [Test]
    public void AddInventoryTest()
    {
        Store testStore = new Store("testStore", 50);
        Inventory InvItem = new Inventory("TEST", 0.50m, "Bagel", "testBagel");
        testStore.AddInventory(InvItem);

        Assert.That(testStore.InventoryDict.Values.Count == 1);
    }

    [Test]
    public void StoreHasItemTest() 
    {
        Store testStore = new Store("testStore", 50);
        Coffee coffee = new Coffee("COFF", "testCoffee", 1.09m);
        Bagel bagel = new Bagel("TEST", "testBagel", 0.50m);
        Inventory InvItemB = new Inventory("TEST", 0.50m, "Bagel", "testBagel");
        Inventory InvItemC = new Inventory("COFF", 1.09m, "Coffee", "testCoffee");

        testStore.AddInventory(InvItemB);
        testStore.AddInventory(InvItemC);
        bool resultB = testStore.StoreHasItem(bagel);
        bool resultC = testStore.StoreHasItem(coffee);

        Assert.That(resultB && resultC && testStore.InventoryDict.Values.Count == 2);
    }

    [Test]
    public void CreateBagelItemTest()
    {
        Store testStore = new Store("testStore", 50);
        Inventory InvItemB = new Inventory("TEST", 0.50m, "Bagel", "testBagel");
        testStore.AddInventory(InvItemB);
        Bagel bagel = testStore.CreateBagel("TEST");

        Assert.That(bagel.Sku == "TEST" && bagel.Price == 0.50m && bagel.Variant == "testBagel");
    }

    [Test]
    public void CreateCoffeeTest()
    {
        Store testStore = new Store("testStore", 50);
        Inventory InvItemC = new Inventory("TEST", 0.50m, "Coffee", "testCoffee");
        testStore.AddInventory(InvItemC);
        Coffee coffee = testStore.CreateCoffee("TEST");

        Assert.That(coffee.Sku == "TEST" && coffee.Price == 0.50m && coffee.Variant == "testBagel");
    }

    [Test]
    public void CreateFillingTest()
    {
        Store testStore = new Store("testStore", 50);
        Inventory InvItemF = new Inventory("TEST", 0.50m, "Filling", "testCoffee");
        testStore.AddInventory(InvItemF);
        Filling filling = testStore.CreateFilling("TEST");

        Assert.That(filling.Sku == "TEST" && filling.Price == 0.50m && filling.Variant == "testBagel");
    }

    [Test]
    public void CreateBasketTest()
    {
        Store testStore = new Store("testStore", 50);
        Basket basket = testStore.CreateBasket();

        Assert.That(basket.Capacity == 50);
    }

    [Test]
    public void AddFillToBagelTest()
    {
        Store testStore = new Store("testStore", 50);
        Inventory InvItemB = new Inventory("TEST", 0.50m, "Bagel", "testBagel");
        Inventory InvItemF = new Inventory("FILL", 0.39m, "Filling", "testFilling");

        testStore.AddInventory(InvItemB);
        testStore.AddInventory(InvItemF);

        Bagel bagel = testStore.CreateBagel("TEST");
        Filling fill = testStore.CreateFilling("TEST");
        testStore.AddFillToBagel(bagel, fill);
        
        Assert.That(bagel.Sku == "TEST" && bagel.Price == 0.80m && bagel.Variant == "testBagel" && bagel.Fillings.Contains(fill));
    }
        [Test]
    public void AddItemToBasketTest()
    {
        Store testStore = new Store("testStore", 50);
        Basket basket = testStore.CreateBasket();
        Inventory InvItemB = new Inventory("TEST", 0.50m, "Bagel", "testBagel");
        Inventory InvItemF = new Inventory("FILL", 0.39m, "Filling", "testFilling");

        testStore.AddInventory(InvItemB);
        testStore.AddInventory(InvItemF);

        Bagel bagel = testStore.CreateBagel("TEST");
        Filling fill = testStore.CreateFilling("TEST");
        testStore.AddFillToBagel(bagel, fill);

        testStore.AddItemToBasket(bagel, basket);
        Assert.That(basket.BasketHas(bagel) && basket.TotalCost() == 0.89m);
    }
}
