using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace GroupProject
{
    class Form
    {
        static Phase Phase;
        //declare references for player1 and player2,

        static void Main(string[] args)
        {
            Phase = new Phase();
            const int TWO = 2;
            Phase.InitialPhase();
            do
            {
                int p1Move = Phase.SelectPhase(1);
                int p2Move = Phase.SelectPhase(TWO);
                Phase.AttackPhase(p1Move, p2Move);
                Phase.ConcludePhase();
                ReadKey();
                Clear();

            } while (Phase.ConcludePhase() == 0);
            

            
        }


        


       
        

    }
}
