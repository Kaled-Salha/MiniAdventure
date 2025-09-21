using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure
{


    public class Character
    {
        public string UserName;
        public string ClassType;
        public int MaxHP;
        public int HP;
        public int Damage;
        public int Gold;



        public Character(string userName, string classType, int hp, int damage)
        {
            UserName = userName;
            ClassType = classType;
            MaxHP = hp;
            HP = hp;
            Damage = damage;
            Gold = 0;

        }

       

        public void PrintStats()
        {

            Console.WriteLine($"Name: {UserName} | Class: {ClassType} | HP: {HP}/{MaxHP} | Damage: {Damage} | Gold: {Gold}");

        }

        public void Rest()
        {
            HP = MaxHP;
            Console.WriteLine("Your character has rested and your HP is full again!");

        }

        public void Attack()
        {
            Console.WriteLine($"You attacked the target and caused {Damage} damage to their HP.");

        }

        public void RunAway()
        {

            Console.WriteLine("You ran away succesfully!");

        }


        public void GetAttacked(int enemyDamage)
        {
            HP -= enemyDamage;
            Console.WriteLine($"You got attacked and lost {enemyDamage} HP. You now have {HP} HP.");
        }




    }
}
