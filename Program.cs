using System;
using System.Collections.Generic;
// lb3metodstvorennyaobektiv
namespace DamageSystem 
{
    
    public interface IDamageable
    {
        void TakeDamage(int amount);
    }

    public abstract class Projectile
    {
        protected int damage;

        public Projectile(int damage)
        {
            this.damage = damage;
        }

        public abstract void HitTarget(IDamageable target); //нащадки зобов’язані реалізувати логіку попадання в ціль.


    }

    
    public class Bullet : Projectile
    {
        public Bullet(int damage) : base(damage) {}

        public override void HitTarget(IDamageable target)
        {
            Console.WriteLine($"💥 Пуля наносит {damage} урона!");
            target.TakeDamage(damage);
        }
    }
//ovr.perezap
    
    public class Enemy : IDamageable
    {
        public int Health { get; private set; }

        public Enemy(int health)
        {
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"🧟‍♂️ Враг получил урон. Осталось здоровья: {Health}");

            if (Health <= 0)
                Console.WriteLine("☠️ Враг уничтожен!");
        }
    }

   
    public class BreakableWall : IDamageable
    {
        public int Strength { get; private set; }

        public BreakableWall(int strength)
        {
            Strength = strength;
        }

        public void TakeDamage(int amount)
        {
            Strength -= amount;
            Console.WriteLine($"🧱 Стена получила урон. Осталось прочности: {Strength}");

            if (Strength <= 0)
                Console.WriteLine("💣 Стена разрушена!");
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
          
            Enemy enemy = new Enemy(50);
            BreakableWall wall = new BreakableWall(30);
            Bullet bullet = new Bullet(20);

            Console.WriteLine("== 🔫 Тест стрельбы по объектам ===");

           
            bullet.HitTarget(enemy);

          
            bullet.HitTarget(wall);

            
            Bullet bullet2 = new Bullet(40);
            bullet2.HitTarget(enemy);
        }
    }
}
// простір імен