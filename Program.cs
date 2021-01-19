using System;

namespace Project_Part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Select a number of players: ");
            int nbplayers = int.Parse(Console.ReadLine());

            Console.Write("Select a number of turns to win: ");
            int nbturns = int.Parse(Console.ReadLine());

            Playerclass[] player = new Playerclass[nbplayers];

            for (int i = 0; i < nbplayers; i++)
            {
                Console.Write("Name of player number " + i + ": ");
                player[i] = new Playerclass(Console.ReadLine());
                Console.Write("Starting position of " + player[i].Name + " is : ");
                player[i].Position = int.Parse(Console.ReadLine());

            }

            Console.WriteLine();

            int turn = 1;
            int FirstDice = 0;
            int SecondDice = 0;
            int[] DiceArray;
            Random r = new Random();

            for (int j = 0; j < nbplayers; j++)
            {
                while (player[j].Score != nbturns)
                {
                    for (int k = 0; k < nbplayers; k++)
                        if (player[k].isJail == false && player[k].Position != 30 && player[k].Compteur != 3)
                        {

                            
                            DiceArray = Turn(player, k, FirstDice, SecondDice,r);
                            FirstDice = DiceArray[0];
                            SecondDice = DiceArray[1];

                            if(SecondDice == FirstDice) { player[k].Compteur += 1; }

                            while (SecondDice == FirstDice && player[k].Compteur < 3)
                            {
                                DiceArray = Turn(player, k, FirstDice, SecondDice,r);
                                FirstDice = DiceArray[0];
                                SecondDice = DiceArray[1];

                                if (SecondDice == FirstDice) { player[k].Compteur += 1; }
                                
                            }
                            

                            if (player[k].Position == 30 || player[k].Compteur == 3)
                            {
                                Console.WriteLine("You have been arrested, you must go to Jail !");
                                player[k].Compteur = 0;
                                player[k].isJail = true;
                                player[k].Position = 10;
                            }
                            else
                            {
                                Playerposit(player[k]);
                                Checkthescore(player[k]);
                                player[k].Compteur = 0;
                            }
                            

                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();

                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(player[k].Name + " is in Prison");
                            Console.WriteLine(player[k].Name + "'s turn, first dice in Prison");
                            FirstDice = Dice(player[k],r);
                            Console.WriteLine(player[k].Name + "'s turn, second dice in Prison");
                            SecondDice = Dice(player[k],r);
                            if (SecondDice == FirstDice)
                            {
                                Console.WriteLine(player[k].Name + " rolled a double, he/she can leave from Prison !");
                                player[k].isJail = false;
                                player[k].CompteurPrison = 0;
                                player[k].Position += FirstDice;
                                player[k].Position += SecondDice;
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                            else
                            {
                                player[k].CompteurPrison += 1;
                                if (player[k].CompteurPrison == 3)
                                {
                                    Console.WriteLine(player[k].Name + " spent 3 turns in Prison, he/she can leave from Prison !");
                                    player[k].isJail = false;
                                    player[k].CompteurPrison = 0;
                                    player[k].Position += FirstDice;
                                    player[k].Position += SecondDice;
                                }
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                                Console.WriteLine();
                            }
                        }
                }



                turn++;
            }


            Console.ReadKey();
        }

        static public int Dice(Playerclass player,Random r) /* method to roll the dice */
        {
            int value = r.Next(1, 7);
            Console.WriteLine(player.Name + " rolled: " + value.ToString());

            return value;
        }

        static private void Playerposit(Playerclass player) /* method to change player position with respect to the 40 cases */
        {
            if (player.Position > 39)
            {
                player.Score += 1;
                player.Position -= 40;
            }
            Console.WriteLine(player.Name + "'s new Position is: " + player.Position);
        }

        static private void Checkthescore(Playerclass player) /* method to print the current score of the player */
        {
            Console.WriteLine(player.Name + "'s current Score is: " + player.Score + "\n");
        }

        static private int[] Turn(Playerclass[] player, int k,int FirstDice, int SecondDice,Random r)
        {
            int[] DiceArray = new int[2];
            Console.WriteLine(player[k].Name + "'s turn, first dice");
            FirstDice = Dice(player[k],r);
            player[k].Position += FirstDice;
            DiceArray[0] = FirstDice;

            Console.WriteLine(player[k].Name + "'s turn, second dice");
            SecondDice = Dice(player[k],r);
            player[k].Position += SecondDice;
            DiceArray[1] = SecondDice;

            return DiceArray;
        } /* method to roll two dice and update position*/

    }

}
