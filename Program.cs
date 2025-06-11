using System;
using System.Collections.Generic;

class User
{
    public string UserName { get; set; }
    public string Email { get; set; }
    private string _password;

    public void SetPassword(string newPassword) 
    {
        _password = newPassword;
    }

    public bool Authenticate(string inputPassword) 
    {
        return _password == inputPassword;
    }

    public virtual void DisplayInfo()
    {
        Console.Write($"Ім'я: {UserName} | Email: {Email}");
    }
}

class Admin : User
{
    public void BlockUser(User user)
    {
        Console.WriteLine($"Користувача {user.UserName} заблоковано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine(" | Роль: Адміністратор");
    }
}

class Moderator : User
{
    public void ModerateContent()
    {
        Console.WriteLine("Контент модеровано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine(" | Роль: Модератор");
    }
}

class RegularUser : User
{
    public void PostComment()
    {
        Console.WriteLine("Коментар опубліковано.");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine(" | Роль: Звичайний користувач");
    }
}

class Program
{
    static void Main()
    {
        
        var admin = new Admin { UserName = "AdminUser", Email = "admin@example.com" };
        admin.SetPassword("admin123");

        var mod = new Moderator { UserName = "ModUser", Email = "mod@example.com" };
        mod.SetPassword("mod123");

        var user = new RegularUser { UserName = "RegUser", Email = "user@example.com" };
        user.SetPassword("user123");

        List<User> users = new List<User> { admin, mod, user };

        Console.WriteLine("=== Інформація про користувачів ===");
        foreach (var u in users)
        {
            u.DisplayInfo();
        }

        Console.WriteLine("\n=== Тестування методів ===");
        foreach (var u in users)
        {
            if (u is Admin a)
                a.BlockUser(user);

            if (u is Moderator m)
                m.ModerateContent();

            if (u is RegularUser ru)
                ru.PostComment();
        }

        Console.WriteLine("\n=== Перевірка аутентифікації ===");
        Console.WriteLine($"AdminUser: {(admin.Authenticate("admin123") ? "Успішна аутентифікація" : "Невірний пароль")}");
        Console.WriteLine($"ModUser: {(mod.Authenticate("wrongpassword") ? "Успішна аутентифікація" : "Невірний пароль")}");
        Console.WriteLine($"RegUser: {(user.Authenticate("user123") ? "Успішна аутентифікація" : "Невірний пароль")}");
    }
}
