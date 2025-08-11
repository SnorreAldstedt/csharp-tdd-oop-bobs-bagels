using exercise.main.StoreItem;

namespace exercise.tests;
public class StoreItemTests
{

    [Test]
    public void FillingTest()
    {
        Filling testFilling = new Filling("TEST", "testFilling", 1.99m);
        Decimal expectedPrice = 1.99m;
        string expectedSku = "TEST";
        string expectedVariant = "testFilling";
        Assert.That(
            testFilling.Sku == expectedSku && 
            testFilling.Variant == expectedVariant && 
            testFilling.Price == expectedPrice);
    }

    [Test]
    public void CoffeeTest()
    {
        Coffee testCoffee = new Coffee("TEST", "testCoffee", 1.59m);
        Decimal expectedPrice = 1.59m;
        string expectedSku = "TEST";
        string expectedVariant = "testCoffee";
        Assert.That(
            testCoffee.Sku == expectedSku &&
            testCoffee.Variant == expectedVariant &&
            testCoffee.Price == expectedPrice);
    }
    [Test]
    public void BagelTest()
    {
        Bagel testBagel = new Bagel("TEST", "testBagel", 0.59m);
        Decimal expectedPrice = 0.59m;
        string expectedSku = "TEST";
        string expectedVariant = "testBagel";
        Assert.That(
            testBagel.Sku == expectedSku &&
            testBagel.Variant == expectedVariant &&
            testBagel.Price == expectedPrice);
    }
   
    [Test]
    public void BagelFillingTest()
    {
        Bagel testBagel = new Bagel("TEST", "testBagel", 0.59m);
        Filling testFilling = new Filling("TEST", "testFilling", 0.11m);

        testBagel.AddFilling(testFilling);

        Decimal expectedPrice = 0.70m;
        Decimal bagelPrice = testBagel.GetTotalPrice();

        Assert.That(bagelPrice == expectedPrice && testBagel.Fillings.Contains(testFilling));
    }

    [Test]
    public void BagelRemoveFillingTest()
    {
        Bagel testBagel = new Bagel("TEST", "testBagel", 0.59m);
        Filling testFilling1 = new Filling("TEST", "testFilling1", 0.11m);
        Filling testFilling2 = new Filling("TEST", "testFilling2", 0.11m);


        testBagel.AddFilling(testFilling1);
        testBagel.AddFilling(testFilling2);

        testBagel.RemoveFilling(testFilling1);
        Decimal expectedPrice = 0.70m;
        Decimal bagelPrice = testBagel.GetTotalPrice();

        Assert.That(bagelPrice == expectedPrice && testBagel.Fillings.Contains(testFilling2) && !testBagel.Fillings.Contains(testFilling1));
    }
}
