using BethanysPieShop.InventoryManagement;

Price samplePrice = new Price(10, Currency.Euro);
Product sugar = new Product(1, "Sugar", "Lorem ipsum", samplePrice, UnitType.PerKg, 100);

sugar.IncreaseStock(15);
sugar.Description = "A sweetener";

PrintWelcome();

#region Layout

static void PrintWelcome()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Welcome to ");
    Console.WriteLine("-------------------------");
    Console.WriteLine("Bethany's Pie Shop Inventory Management");
    Console.WriteLine("-------------------------");

    Console.ResetColor();

    Console.WriteLine("Press enter key to start logging in!");

    Console.ReadLine();

    Console.Clear();
}


#endregion
