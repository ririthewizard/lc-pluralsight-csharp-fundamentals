Console.WriteLine("Enter your age here:");
int age = int.Parse(Console.ReadLine());

switch (age)
{
    case < 18:
    case > 85:
        Console.WriteLine("Try again a different time");
        break;
    case 42:
        Console.WriteLine("Exactly what we're looking for!");
        break;
    default:
        Console.WriteLine("You are good to go!");
        break;
}
