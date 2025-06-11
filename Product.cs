using System;

class Product // клас
{
   
    private string name;
    private decimal price;
    private int quantity;

 
    public Product(string name, decimal price, int quantity) 
    {
        Name = name;
        Price = price;
        this.quantity = quantity;
    }


    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                Console.WriteLine("❌ Назва товару не може бути порожньою!");
        }
    }


    public decimal Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine("❌ Ціна не може бути від’ємною!");
        }
    }


    public int Quantity
    {
        get { return quantity; }
    }

   
    public decimal TotalValue
    {
        get { return price * quantity; }
    }

    
    public void Restock(int amount) // назва методу
    {
        if (amount > 0)
            quantity += amount;
        else
            Console.WriteLine("❌ Кількість для поповнення повинна бути додатною!");
    }


    public void Sell(int amount) //
    {
        if (amount <= 0)
        {
            Console.WriteLine("❌ Кількість для продажу повинна бути додатною!");
        }
        else if (amount > quantity)
        {
            Console.WriteLine("❌ Недостатньо товару на складі!");
        }
        else
        {
            quantity -= amount;
        }
    }

   
    public string GetInfo() //
    {
        return $"Товар: {name}, Ціна: {price} грн, Кількість: {quantity}, Загальна вартість: {TotalValue} грн";
    }
}
