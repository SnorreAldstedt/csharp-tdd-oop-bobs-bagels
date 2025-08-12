using exercise.main;

namespace exercise.tests;

public class InventoryTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateInventoryItemTest()
    {
        Inventory testInv = new Inventory("TEST", 0.50m, "Bagel", "TestBagel");
        Assert.That(testInv.Sku == "TEST" && testInv.Price == 0.50m && testInv.Name == "Bagel" && testInv.Variant == "TestBagel");
    }
}
