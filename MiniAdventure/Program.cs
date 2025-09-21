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
            Random rnd = new Random();

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


                Console.WriteLine("Enter your choice: ");
                string input = Console.ReadLine();

                bool validInput = int.TryParse(input, out int choice);
                if (!validInput || choice <1 || choice > 5) 
                {
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 5");
                    Console.ReadKey();
                    continue;

                }


                switch (choice)
                {

                    case 1:

                        
                        Enemy template = enemies[rnd.Next(enemies.Count)];
                        Enemy enemy = new Enemy(template.Name, template.HP, template.Damage, template.GoldReward);


                        Console.WriteLine($"You encountered a {enemy.Name}");
                        Console.WriteLine($"HP: {enemy.HP}, Damage: {enemy.Damage}, Gold: {enemy.GoldReward}");

                        while (enemy.HP > 0 && player.HP > 0)
                        {
                            Console.WriteLine("What do you want to do?");
                            Console.WriteLine("[1]. Fight?");
                            Console.WriteLine("[2]. Run?");

                            string decision = Console.ReadLine();

                            if (decision == "1")
                            {
                                player.Attack();
                                enemy.HP -= player.Damage;
                                Console.WriteLine($"You dealt {player.Damage} damage to the {enemy.Name}!");
                                if (enemy.HP > 0)
                                {
                                    player.GetAttacked(enemy.Damage);
                                    if (player.HP <= 0)
                                    {
                                        Console.WriteLine("You died.... GAME OVER!");
                                        Console.ReadKey();
                                        gameRunning = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"You defeated the {enemy.Name} and gained {enemy.GoldReward} gold!");
                                    player.Gold += enemy.GoldReward;
                                }
                            }
                            else if (decision == "2")
                            {
                                player.RunAway();
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Invalid input. Please type 1 or 2.");
                            }

                        }
                        break;

                    case 2:
                        Console.WriteLine("You found a village full with residents and lived happily ever after!");
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


                Console.Clear();
                Console.WriteLine("--- Made by ---");
                Console.WriteLine("╔═════════════════════╗");
                Console.WriteLine("║===  HEXE_MORTEM  ===║");
                Console.WriteLine("╚═════════════════════╝");


            }
        }

    }
}
