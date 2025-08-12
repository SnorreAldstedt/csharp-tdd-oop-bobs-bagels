using exercise.main;
using exercise.main.StoreItem;

namespace exercise.tests;

public class DiscountTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCoffeeAndBagel()
    {
        Store store = new Store("Bob's TestBagels", 50);
        Basket storeBasket = store.CreateBasket();
        Inventory onionBagel = new Inventory("BGLO", 0.49m, "Bagel", "Onion");
        Inventory plainBagel = new Inventory("BGLP", 0.39m, "Bagel", "Plain");
        Inventory coffeeLatte = new Inventory("COFL", 1.29m, "Coffee", "Latte");
        Inventory coffeeWhite = new Inventory("COFW", 1.19m, "Coffee", "White");
        Inventory coffeeBlack = new Inventory("COFB", 0.99m, "Coffee", "Black");

        store.AddInventory(onionBagel);
        store.AddInventory(plainBagel);
        store.AddInventory(coffeeLatte);
        store.AddInventory(coffeeWhite);
        store.AddInventory(coffeeBlack);

        Bagel myBagel = store.CreateBagel("BGLO");
        Coffee myCoffee = store.CreateCoffee("COFW");

        store.AddItemToBasket(myBagel, storeBasket);
        store.AddItemToBasket(myCoffee, storeBasket);

        BasketCheckout checkout = new BasketCheckout(storeBasket, store);

        checkout.applyDiscount();
        decimal discountTest = checkout.discountTotal;

        Assert.That(discountTest == 0.43m);
    }

    [Test]
    public void TestSixBagelsAndCoffee()
    {
        Store store = new Store("Bob's TestBagels", 50);
        Basket storeBasket = store.CreateBasket();
        Inventory onionBagel = new Inventory("BGLO", 0.49m, "Bagel", "Onion");
        Inventory plainBagel = new Inventory("BGLP", 0.39m, "Bagel", "Plain");
        Inventory coffeeLatte = new Inventory("COFL", 1.29m, "Coffee", "Latte");
        Inventory coffeeWhite = new Inventory("COFW", 1.19m, "Coffee", "White");
        Inventory coffeeBlack = new Inventory("COFB", 0.99m, "Coffee", "Black");

        store.AddInventory(onionBagel);
        store.AddInventory(plainBagel);
        store.AddInventory(coffeeLatte);
        store.AddInventory(coffeeWhite);
        store.AddInventory(coffeeBlack);

        for(int i = 0; i<6; i++)
        {
            Bagel myBagel = store.CreateBagel("BGLO");
            store.AddItemToBasket(myBagel, storeBasket);
        }
        Bagel myPlainBagel = store.CreateBagel("BGLP");
        store.AddItemToBasket(myPlainBagel, storeBasket);

        Coffee myCoffee = store.CreateCoffee("COFW");

        store.AddItemToBasket(myCoffee, storeBasket);

        BasketCheckout checkout = new BasketCheckout(storeBasket, store);

        checkout.applyDiscount();
        decimal discountTest = checkout.discountTotal;

        Assert.AreEqual(discountTest, 0.45m);
    }
    [Test]
    public void TestSixBagelsNoCoffee()
    {
        Store store = new Store("Bob's TestBagels", 50);
        Basket storeBasket = store.CreateBasket();
        Inventory onionBagel = new Inventory("BGLO", 0.49m, "Bagel", "Onion");
        Inventory plainBagel = new Inventory("BGLP", 0.39m, "Bagel", "Plain");
        Inventory coffeeLatte = new Inventory("COFL", 1.29m, "Coffee", "Latte");
        Inventory coffeeWhite = new Inventory("COFW", 1.19m, "Coffee", "White");
        Inventory coffeeBlack = new Inventory("COFB", 0.99m, "Coffee", "Black");

        store.AddInventory(onionBagel);
        store.AddInventory(plainBagel);
        store.AddInventory(coffeeLatte);
        store.AddInventory(coffeeWhite);
        store.AddInventory(coffeeBlack);

        for (int i = 0; i < 6; i++)
        {
            Bagel myBagel = store.CreateBagel("BGLO");
            store.AddItemToBasket(myBagel, storeBasket);
        }
        Bagel myPlainBagel = store.CreateBagel("BGLP");
        store.AddItemToBasket(myPlainBagel, storeBasket);

        BasketCheckout checkout = new BasketCheckout(storeBasket, store);

        checkout.applyDiscount();
        decimal discountTest = checkout.discountTotal;

        decimal discountBagels = checkout.calculateDiscountBagels();

        Assert.AreEqual(discountTest, discountBagels);
        Assert.AreEqual(discountTest, 0.45m);
    }

    [Test]
    public void TestTwelveOnionBagelsAndCoffee()
    {
        Store store = new Store("Bob's TestBagels", 50);
        Basket storeBasket = store.CreateBasket();
        Inventory onionBagel = new Inventory("BGLO", 0.49m, "Bagel", "Onion");
        Inventory plainBagel = new Inventory("BGLP", 0.39m, "Bagel", "Plain");
        Inventory coffeeLatte = new Inventory("COFL", 1.29m, "Coffee", "Latte");
        Inventory coffeeWhite = new Inventory("COFW", 1.19m, "Coffee", "White");
        Inventory coffeeBlack = new Inventory("COFB", 0.99m, "Coffee", "Black");

        store.AddInventory(onionBagel);
        store.AddInventory(plainBagel);
        store.AddInventory(coffeeLatte);
        store.AddInventory(coffeeWhite);
        store.AddInventory(coffeeBlack);

        for (int i = 0; i < 12; i++)
        {
            Bagel myBagel = store.CreateBagel("BGLO");
            store.AddItemToBasket(myBagel, storeBasket);
        }
        Bagel myPlainBagel = store.CreateBagel("BGLP");
        store.AddItemToBasket(myPlainBagel, storeBasket);

        Coffee myCoffee = store.CreateCoffee("COFW");
        store.AddItemToBasket(myCoffee, storeBasket);

        BasketCheckout checkout = new BasketCheckout(storeBasket, store);

        checkout.applyDiscount();
        decimal discountTest = checkout.discountTotal;

        decimal discountBagels = checkout.calculateDiscountBagels();

        Assert.AreEqual(discountTest, discountBagels);
        Assert.AreEqual(discountTest, 1.89m);
    }
    [Test]
    public void TestTwelvePlainBagels()
    {
        Store store = new Store("Bob's TestBagels", 50);
        Basket storeBasket = store.CreateBasket();
        Inventory onionBagel = new Inventory("BGLO", 0.49m, "Bagel", "Onion");
        Inventory plainBagel = new Inventory("BGLP", 0.39m, "Bagel", "Plain");
        Inventory coffeeLatte = new Inventory("COFL", 1.29m, "Coffee", "Latte");
        Inventory coffeeWhite = new Inventory("COFW", 1.19m, "Coffee", "White");
        Inventory coffeeBlack = new Inventory("COFB", 0.99m, "Coffee", "Black");

        store.AddInventory(onionBagel);
        store.AddInventory(plainBagel);
        store.AddInventory(coffeeLatte);
        store.AddInventory(coffeeWhite);
        store.AddInventory(coffeeBlack);

        for (int i = 0; i < 12; i++)
        {
            Bagel myBagel = store.CreateBagel("BGLP");
            store.AddItemToBasket(myBagel, storeBasket);
        }
        Bagel myPlainBagel = store.CreateBagel("BGLO");
        store.AddItemToBasket(myPlainBagel, storeBasket);

        BasketCheckout checkout = new BasketCheckout(storeBasket, store);

        checkout.applyDiscount();
        decimal discountTest = checkout.discountTotal;

        decimal discountBagels = checkout.calculateDiscountBagels();

        Assert.AreEqual(discountTest, discountBagels);
        Assert.AreEqual(discountTest, 0.69m);
    }
    [Test]
    public void TestTwelveBagelsAndCoffee()
    {
        Store store = new Store("Bob's TestBagels", 50);
        Basket storeBasket = store.CreateBasket();
        Inventory onionBagel = new Inventory("BGLO", 0.49m, "Bagel", "Onion");
        Inventory plainBagel = new Inventory("BGLP", 0.39m, "Bagel", "Plain");
        Inventory coffeeLatte = new Inventory("COFL", 1.29m, "Coffee", "Latte");
        Inventory coffeeWhite = new Inventory("COFW", 1.19m, "Coffee", "White");
        Inventory coffeeBlack = new Inventory("COFB", 0.99m, "Coffee", "Black");

        store.AddInventory(onionBagel);
        store.AddInventory(plainBagel);
        store.AddInventory(coffeeLatte);
        store.AddInventory(coffeeWhite);
        store.AddInventory(coffeeBlack);

        for (int i = 0; i < 12; i++)
        {
            Bagel myOnionBagel = store.CreateBagel("BGLO");
            store.AddItemToBasket(myOnionBagel, storeBasket);
        }
        Bagel myBagel = store.CreateBagel("BGLO");
        Coffee myCoffee = store.CreateCoffee("COFW");

        store.AddItemToBasket(myBagel, storeBasket);
        store.AddItemToBasket(myCoffee, storeBasket);

        BasketCheckout checkout = new BasketCheckout(storeBasket, store);
        checkout.applyDiscount();

        decimal discountTest = checkout.discountTotal;

        decimal discountBagels = checkout.calculateDiscountBagels();

        Assert.AreEqual(discountTest, discountBagels);
        Assert.AreEqual(discountTest, 1.89m);

    }
}
