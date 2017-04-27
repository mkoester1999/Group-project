using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GroupProject
{
    class Phase
    {
        //declare referances for player class
        static Player P1;
        static Player P2;

        //Name: InitialPhase
        //Purpose: initialize player objects
        //parameters: none
        //reterns: void
        static public void InitialPhase()
        {
            //initialze objects
            P1 = new Player();
            P2 = new Player();

            //ask p1 for name
            Write("hello Player One, Please enter you name: ");
            P1.Name = ReadLine();

            //ask p2 for name
            Write("Player Two, Please enter you name: ");
            P2.Name = ReadLine();
        }

        // Method: SelectPhase
        // Purpose: to chose the move that they want to do
        // Parameters: obj p2
        // Returns: select
        //Dev: Morgan
        static public int SelectPhase(int player)
        {
            //call gaincharge
            P1.GainCharge();
            P2.Charge = 0;
            P2.GainCharge();

            if (player == 1)
            {
                // declare int select
                int select = 0;



                if (P1.Wait == false)
                {

                    do
                    {

                        WriteLine($"{P1.Name}'s turn ");
                        WriteLine($"Charge: {P1.Charge}");

                        // displays options for selection in a numbered list

                        WriteLine("Please select a move:\n1: Attack 1\n     1 charge, 10 damage");
                        WriteLine("2: Attack 2\n     2 charge, 20 damage");
                        WriteLine("3: Attack 3\n     3 charge, 30 damage");
                        WriteLine("4: Special Attack\n     3 charge, 50 damage\n     2 turn spool time");
                        WriteLine("5: weak attack\n     no charge, 5 damage");
                        WriteLine("6: charge\n     gain an extra charge, take extra damage");
                        WriteLine("7: Block\n     25% chance to blcok 50% damage\n     50% chance to block 25% damage\n     25% chance to fail");

                        // sets select to a number that the player inputs
                        select = int.Parse(ReadLine());

                        // if the input that the input isn’t 1, 2, 3, 4, 5, 6, 7, then ask them to input again
                        if ((select > 7) || select < 1) { WriteLine("the number you entered is outside of acceptable values, please reenter your input"); ReadKey(); }

                        
                        Clear();
                        if (select < 5)
                        {
                            if (select > P2.Charge)
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("you do not have enough charge to use that move");
                                select = -1;
                            }
                        }


                    } while (select > 7 || (select < 1));


                }
                else { P1.Wait = false; }
                // returns select
                return select;
            }
            else if (player == 2)
            {
                // declare int select
                int select = 0;



                if (P2.Wait == false)
                {

                    do
                    {
                        WriteLine($"{P2.Name}'s turn");
                        WriteLine($"Charge: {P2.Charge}");


                        // displays options for selection in a numbered list

                        WriteLine("Please select a move:\n1: Attack 1\n     1 charge, 10 damage");
                        WriteLine("2: Attack 2\n     2 charge, 20 damage");
                        WriteLine("3: Attack 3\n     3 charge, 30 damage");
                        WriteLine("4: Special Attack\n     3 charge, 50 damage\n     2 turn spool time");
                        WriteLine("5: weak attack\n     no charge, 5 damage");
                        WriteLine("6: charge\n     gain an extra charge, take extra damage");
                        WriteLine("7: Block\n     25% chance to blcok 50% damage\n     50% chance to block 25% damage\n     25% chance to fail");

                        // sets select to a number that the player inputs
                        select = int.Parse(ReadLine());

                        // if the input that the input isn’t 1, 2, 3, 4, 5, 6, 7, then ask them to input again
                        if ((select > 7) || select < 1)
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("the number you entered is outside of acceptable values, please reenter your input");
                        }
                        if (select < 5)
                        {
                            if(select > P2.Charge)
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("you do not have enough charge to use that move");
                                select = -1;
                            }
                        }
                    } while (select > 7 || (select < 1));


                }
                else { P2.Wait = false; }
                // returns select
                return select;
            }
            else { int select = 0; return select; }
        }
        // Method: AttackPhase
        // Purpose: executes the attack that they chose
        // Parameters: p1Move p2Move
        // Returns: none
        static public void AttackPhase(int p1Move, int p2Move)
        {
            string attackName1 = "";
            string attackName2 = "";

            //execute player attacks
            if(p1Move <6)
            {
                P1.Attack(p1Move, out attackName1);

            }

            else if (p1Move == 6)
            {
                attackName1 = "Charge";
                P1.ExtraCharge();
            }
            else if (p1Move == 7)
            {
                attackName1 = "Block";
                P1.Block();
            }

            if (p2Move < 6)
            {
                P2.Attack(p2Move, out attackName2);

            }
            else if(p2Move == 6)
            {
                attackName2 = "Charge";
                P2.ExtraCharge();
            }
            else if(p2Move == 7)
            {
                attackName2 = "Block";
                P2.Block();
            }
            
            //player1 take damage
            int p1DamageTaken = (int)(P2.Damage * P1.BlockDamage * P1.ChargeDamage);
            P1.Health -= p1DamageTaken;

            //player2 take damage
            int p2DamageTaken = (int)(P1.Damage * P2.BlockDamage * P2.ChargeDamage);

            P2.Health -= p2DamageTaken;
            //display $"{p1name} used {move}
            WriteLine($"{P1.Name} used {attackName1}");

            //display $"{p2Name} used {move}
            WriteLine($"{P2.Name} used {attackName2}");

            //{p1} lost {damage} health
            WriteLine($"{P1.Name} lost {p1DamageTaken}");

            //{p2} lost {damage} health
            WriteLine($"{P2.Name} lost {p2DamageTaken}");

            //{p1} total health: {health}
            WriteLine($"total {P1.Name} health = {P1.Health}");

            //{p2} total health: {health}
            WriteLine($"total {P2.Name} health = {P2.Health}");
            ReadKey();

        }

        // Method: ConcludePhase
        // Purpose: gets the the players healths and checks if anyone is dead
        // Parameters: none
        // Returns: int conclusion
        static public int ConcludePhase()
        {
            int conclusion;
            // gets the the players healths and checks if anyone is dead
            // if player1 health is less than 0, conclusion = 1 and if player 2 health >= 0, conclusion = 2, if both > 0, conclusion = 3
            if ( P1.Health <=0 && !(P2.Health <= 0))
            {
                conclusion = 1;
                WriteLine($"{P1.Name} is dead. {P2.Name} wins.");
                return conclusion;
            }
            else if (P2.Health <= 0 && !(P1.Health <= 0))
            {
                conclusion = 2;
                WriteLine($"{P2.Name} is dead. {P1.Name} wins.");
                return conclusion;
            }
            else if (P2.Health <= 0 && (P1.Health <= 0))
            {
                conclusion = 3;
                WriteLine("You are both dead. Tie");
                return conclusion;
            }
            else
            {
                conclusion = 0;
                WriteLine("next round");
                return conclusion;
            }

            //otherwise, return 0

        }


    }
}
