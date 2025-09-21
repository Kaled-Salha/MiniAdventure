using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAdventure
{
    public class Enemy
    {

        public string Name;
        public int HP;
        public int Damage;
        public int GoldReward;

        public Enemy(string name, int hp, int damage, int goldR)
        {
                Name = name;
                HP = hp;
                Damage = damage;
                GoldReward = goldR;
        }

        public void PrintStats() 
        {
            Console.WriteLine($"Enemy: {Name} | HP: {HP} | Damage: {Damage} | Gold Drop: {GoldReward}");
        
        }

    }
}
