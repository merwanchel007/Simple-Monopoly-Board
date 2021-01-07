using System;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Select a number of players: ");
            int nbplayers = int.Parse(Console.ReadLine());

            Console.Write("Select a number of turns: ");
            int nbturns = int.Parse(Console.ReadLine());

            Playerclass[] player = new Playerclass[nbplayers];

            for (int i = 0; i < nbplayers; i++)
            {
                Console.Write("Name of player number " + i +": ");
                player[i] = new Playerclass(Console.ReadLine());

            }

            Console.WriteLine();

            int turn = 1;
            int FirstDice;
            int SecondDice;



            for (int j = 0; j < nbplayers; j++) { 
                while (player[j].Score != nbturns)
            {
                    for (int k = 0; k < nbplayers; k++)
                        if (player[k].isJail == false && player[k].Position != 30 && player[k].Compteur != 3)
                {
                    Console.WriteLine(player[k].Name + "'s turn, first dice");
                    FirstDice = Dice(player[k]);
                    player[k].Position += FirstDice;
                    Console.WriteLine(player[k].Name + "'s turn, second dice");
                    SecondDice = Dice(player[k]);
                    if (SecondDice == FirstDice)
                    {
                        player[k].Compteur += 1;
                    }
                    else
                    {
                        player[k].Compteur = 0;
                    }
                    player[k].Position += SecondDice;
                    Playerposit(player[k]);
                    Checkthescore(player[k]);
                    if (player[k].Position == 30 || player[k].Compteur == 3)
                    {
                        Console.WriteLine("You have been arrested, you must go to Jail !");
                        player[k].Compteur = 0;
                        player[k].isJail = true;
                        player[k].Position = 10;

                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(player[k].Name + " is in Prison");
                    Console.WriteLine(player[k].Name + "'s turn, first dice in Prison");
                    FirstDice = Dice(player[k]);
                    player[k].Position += FirstDice;
                    Console.WriteLine(player[k].Name + "'s turn, second dice in Prison");
                    SecondDice = Dice(player[k]);
                    if (SecondDice == FirstDice)
                    {
                        Console.WriteLine(player[k].Name + "rolled a double, he/she can leave from Prison !");
                                player[k].isJail = false;
                                player[k].CompteurPrison = 0;
                                Console.ReadLine();
                    }
                    else
                    {
                        player[k].CompteurPrison += 1;
                        if(player[k].CompteurPrison == 3)
                        {
                            Console.WriteLine(player[k].Name + " spent 3 turns in Prison, he/she can leave from Prison !");
                            player[k].isJail = false;
                            player[k].CompteurPrison = 0;
                        }
                        Console.ReadLine();
                    }
                }
                }

                

                turn++;
            }


            Winneris(player);

        }

        static public int Dice(Playerclass player)
        {
            Random r = new Random();
            int value = r.Next(1, 7);
            Console.WriteLine(player.Name + " rolled: " + value.ToString());

            return value;
        }

        static private void Playerposit(Playerclass player)
        {
            if (player.Position > 39)
            {
                player.Score += 1;
                player.Position -= 39;
            }
            Console.WriteLine(player.Name + "'s new Position is: " + player.Position);
        }

        static private void Checkthescore(Playerclass player)
        {
            Console.WriteLine(player.Name + "'s current Score is: " + player.Score + "\n");
        }

        static private void Winneris(Playerclass[] player)
        {
            foreach (Playerclass _player in player)
            {
                if (_player.Score == 10)
                {
                    Console.WriteLine(_player.Name + " wins");
                    Console.ReadLine();
                }
            }
        }
    }

}