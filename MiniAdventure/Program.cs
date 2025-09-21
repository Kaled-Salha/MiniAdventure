namespace MiniAdventure
{


    internal class Program
    {
        string playerName;
        string chosenClass;


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, hero. What is your name?");
            
            string playerName = Console.ReadLine();
            
            Console.WriteLine($"Welcome {playerName}! Choose your class: Warrior/Wizard/Archer");
            string chosenClass = Console.ReadLine().ToLower();

            int hp = 0;
            int damage = 0;

            if (chosenClass == "warrior")
            {
                hp = 50;
                damage = 22;
            
            }

            else if (chosenClass == "wizard")
            {
                hp = 60;
                damage = 17;

            }

            else if (chosenClass == "archer")
            {
                hp = 55;
                damage = 19;

            }

            else
            {
                Console.WriteLine("Invalid class. Defaulting to Warrior.");

                chosenClass = "warrior";
                hp = 50;
                damage = 22;

            }

            Character player = new Character(playerName, chosenClass, hp, damage);

            player.PrintStats();

            List<Enemy> enemies = new List<Enemy>()
            {

                new Enemy("Rat", 15, 3, 1),
                new Enemy("Goblin", 25, 5, 3),
                new Enemy("Skeleton", 30, 6, 4),
                new Enemy("Bandit", 40, 10, 8)


            };


            bool gameRunning = true;
            bool firstTime = true;
            while (gameRunning)
            {
                Console.Clear();

                if (firstTime)
                {
                    Console.WriteLine("You just spawned in a forest!");
                    firstTime = false;
                }
                

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[1]. Adventure deeper.");
                Console.WriteLine("[2]. Exit the forrest.");
                Console.WriteLine("[3]. Rest.");
                Console.WriteLine("[4]. Status.");
                Console.WriteLine("[5]. Exit the game.");


                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {

                    case 1:
                        Console.WriteLine($"You encountered 2 {"Goblin"}s");
                        break;

                    case 2:
                        Console.WriteLine("You found a village full with residents!");
                        break;

                    case 3:
                        player.Rest();
                        break;

                    case 4:
                        player.PrintStats();
                        break;

                    case 5:
                        gameRunning = false;
                        break;


                }

                Console.ReadKey();
            }
        }

    }
}
