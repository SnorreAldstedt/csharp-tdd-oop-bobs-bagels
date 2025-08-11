using exercise.main;
using exercise.main.StoreItem;
using System.Reflection.Emit;

namespace exercise.tests;

public class BasketTests
{
    [Test]
    public void AddTwoBagelTest()
    {
        Bagel bagel1 = new Bagel("TEST1", "testBagel1", 0.59m);
        Bagel bagel2 = new Bagel("TEST2", "testBagel2", 0.59m);
        Basket basket = new Basket();
        basket.Add(bagel1);
        basket.Add(bagel2);

        int ItemsInBasket = basket.ItemCount;

        Assert.That(ItemsInBasket == 2 && basket.BasketHas(bagel1) && basket.BasketHas(bagel2));
    }
    public void AddBagelWithFillingTest()
    {
        Bagel bagel = new Bagel("TEST", "testBagel", 0.59m);
        Filling filling = new Filling("FILL", "testFill", 0.15m);
        Basket basket = new Basket();

        bagel.AddFilling(filling);
        basket.Add(bagel);

        int ItemsInBasket = basket.ItemCount;

        Assert.That(ItemsInBasket == 1 && basket.BasketHas(bagel));
    }

    [Test]
    public void RemoveOneBagelTest()
    {
        Bagel bagel1 = new Bagel("TEST1", "testBagel1", 0.59m);
        Bagel bagel2 = new Bagel("TEST2", "testBagel2", 0.59m);
        Basket basket = new Basket();
        basket.Add(bagel1);
        basket.Add(bagel2);
        basket.Remove(bagel2);
        int ItemsInBasket = basket.ItemCount;

        Assert.That(ItemsInBasket == 1 && basket.BasketHas(bagel1) && !basket.BasketHas(bagel2));
    }

    [Test]
    public void BasketNotFullTest()
    {
        Bagel bagel = new Bagel("TEST", "testBagel", 0.59m);
        Basket basket = new Basket();
        basket.Add(bagel);

        Assert.That(!basket.IsFull());
    }

    [Test]
    public void BasketFullTest()
    {
        Bagel bagel1 = new Bagel("TEST1", "testBagel1", 0.59m);
        Bagel bagel2 = new Bagel("TEST2", "testBagel2", 0.59m);
        Bagel bagel3 = new Bagel("TEST3", "testBagel3", 0.59m);

        Basket basket = new Basket(3);
        basket.Add(bagel1);
        basket.Add(bagel2);
        basket.Add(bagel3);

        Assert.That(basket.IsFull());
    }

    [Test]
    public void BasketPriceTest()
    {
        Bagel bagel1 = new Bagel("TEST1", "testBagel1", 0.59m);
        Bagel bagel2 = new Bagel("TEST2", "testBagel2", 0.49m);
        Bagel bagel3 = new Bagel("TEST3", "testBagel3", 0.59m);

        Basket basket = new Basket();
        basket.Add(bagel1);
        basket.Add(bagel2);
        basket.Add(bagel3);
        Decimal expectedPrice = 1.67m;
        Decimal actualPrice = basket.TotalCost();

        Assert.That(expectedPrice == actualPrice);
    }

    [Test]
    public void BasketWithFillTest()
    {
        Bagel bagel = new Bagel("TEST", "testBagel", 0.59m);
        Filling filling = new Filling("FILL", "testFill", 0.16m);
        bagel.AddFilling(filling);
        Basket basket = new Basket();
        basket.Add(bagel);

        Decimal expectedPrice = 0.75m;
        Decimal actualPrice = basket.TotalCost();
        Assert.That(expectedPrice == actualPrice);
    }
}