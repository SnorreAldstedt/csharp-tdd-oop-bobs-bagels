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

    [Test]
    public void BagelEquivalentTest()
    {
        Bagel bagel1 = new Bagel("TEST", "testBagel", 0.59m);
        Bagel bagel2 = new Bagel("TEST", "testBagel", 0.59m);

        bool shouldBeTrue = bagel1.Equivalent(bagel2);
        Assert.That(shouldBeTrue == true);
    }

    [Test]
    public void CoffeeEquivalentTest()
    {
        Coffee coffee1 = new Coffee("TEST", "testCoffee", 0.59m);
        Coffee coffee2 = new Coffee("TEST", "testCoffee", 0.59m);

        bool shouldBeTrue = coffee1.Equivalent(coffee2);
        Assert.That(shouldBeTrue == true);
    }

    [Test]
    public void FillingEquivalentTest()
    {
        Filling filling1 = new Filling("TEST", "testFilling", 0.59m);
        Filling filling2 = new Filling("TEST", "testFilling", 0.59m);

        bool shouldBeTrue = filling1.Equivalent(filling2);
        Assert.That(shouldBeTrue == true);
    }

    [Test]
    public void BagelWithFillingEquivalentTest()
    {
        {
            Bagel bagel1 = new Bagel("TEST", "testBagel", 0.59m);
            Bagel bagel2 = new Bagel("TEST", "testBagel", 0.59m);
            Filling filling1 = new Filling("TEST", "testFilling", 0.59m);
            Filling filling2 = new Filling("TEST", "testFilling", 0.59m);

            bagel1.AddFilling(filling1);
            bagel2.AddFilling(filling2);

            bool fillingEquivalent = filling1.Equivalent(filling2);
            bool shouldBeTrue = bagel1.Equivalent(bagel2);
            Assert.That(shouldBeTrue == true && fillingEquivalent);
        }
    }

    [Test]
    public void BagelWithSameFillingEquivalentTest()
    {
        {
            Bagel bagel1 = new Bagel("TEST", "testBagel", 0.59m);
            Bagel bagel2 = new Bagel("TEST", "testBagel", 0.59m);
            Filling filling1 = new Filling("TEST", "testFilling", 0.59m);
            Filling filling2 = new Filling("TEST", "testFilling", 0.59m);

            bagel1.AddFilling(filling1);
            bagel1.AddFilling(filling2);

            bagel2.AddFilling(filling1);
            bagel2.AddFilling(filling2);

            bool shouldBeTrue = bagel1.Equivalent(bagel2);
            Assert.That(shouldBeTrue == true);
        }
    }

    [Test]
    public void CopyBagelTest()
    {
        Bagel bagel = new Bagel("TEST", "testBagel", 0.59m);
        Bagel copyBagel = (Bagel)bagel.Copy();

        Assert.That(bagel != copyBagel && bagel.Equivalent(copyBagel));
    }
    [Test]
    public void CopyBagelNotEquivalentTest()
    {
        Bagel bagel = new Bagel("TEST", "testBagel", 0.59m);
        Bagel copyBagel = (Bagel)bagel.Copy();
        Filling filling = new Filling("TEST", "testFilling", 0.59m);
        bagel.AddFilling(filling);


        Assert.That(bagel != copyBagel && !bagel.Equivalent(copyBagel));
    }
    [Test]
    public void CopyCoffeeTest()
    {
        Coffee coffee = new Coffee("TEST", "testCoffee", 0.59m);
        Coffee copyCoffee = (Coffee)coffee.Copy();

        Assert.That(coffee != copyCoffee && coffee.Equivalent(copyCoffee));
    }
    [Test]
    public void CopyFillingTest()
    {
        Filling filling = new Filling("TEST", "testFilling", 0.59m);
        Filling copyFilling = (Filling)filling.Copy();

        Assert.That(filling != copyFilling && filling.Equivalent(copyFilling));
    }
    [Test]
    public void CopyBagelWithFillingTest()
    {
        Bagel bagel = new Bagel("TEST", "testBagel", 0.59m);
        Filling filling = new Filling("TEST", "testFilling", 0.59m);
        bagel.AddFilling(filling);
        Bagel copyBagel = (Bagel)bagel.Copy();

        Assert.That(bagel != copyBagel && bagel.Equivalent(copyBagel));
    }
}
