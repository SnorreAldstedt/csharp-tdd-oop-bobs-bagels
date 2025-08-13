using exercise.main;
using exercise.main.StoreItem;

namespace exercise.tests;

public class ReceiptTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BuildReceipt()
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

        Receipt receipt = new Receipt(checkout);

        string receiptString = receipt.buildReceipt();

        Assert.AreEqual(receiptString.GetType(),  typeof(string));
        receipt.printReceipt();
    }
}
