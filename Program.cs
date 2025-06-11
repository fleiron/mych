class Program
{
    static void Main()
    {
        Product apple = new Product("Яблуко", 5, 100);
        
        
        Console.WriteLine(apple.GetInfo());

        apple.Sell(20);
        Console.WriteLine(apple.GetInfo());

        apple.Restock(50);
        Console.WriteLine(apple.GetInfo());

        apple.Price = 7;
        Console.WriteLine(apple.GetInfo());

        apple.Name = "Зелене яблуко";
        Console.WriteLine(apple.GetInfo());

        apple.Price = -10;  
        apple.Name = "";    
        apple.Sell(200);    
    }
}
