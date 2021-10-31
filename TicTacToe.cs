using System;

using System.Threading;
 
namespace TIC_TAC_TOE

{
    class Program

    {
        /* making array and by default I am providing 0-9 where there 
        will be no use of zero. This will make the numbering easy to connect
        the board spaces they will be the same number as the args */ 
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        //By default player 1 is set 
        static int player = 1;  

        //This holds the choice at which position player wants to mark their spot
        static int choice;   

        /* The flag veriable checks who has won; 
        if it's value is 1 then a player has won the match; 
        if -1 then the match is a Draw; 
        if 0 then the match is still running */ 

        static int flag = 0;

        static void Main(string[] args)

        {

            do

            {
                // whenever loop will begin; start screen will be cleared 
                Console.Clear();

                Console.WriteLine("Player1:X and Player2:O");

                Console.WriteLine("\n");

                //checking the chance of the player 
                if (player % 2 == 0) 

                {

                    Console.WriteLine("Player 2 Chance");
                
                }

                else

                {

                    Console.WriteLine("Player 1 Chance");
                
                }

                Console.WriteLine("\n");

                // calling the board Function 
                Board(); 

                //Player enters choice
                choice = int.Parse(Console.ReadLine());   


                /* checking the position where player choice is marked 
                   (with X or O) or number */

                if (arr[choice] != 'X' && arr[choice] != 'O')

                {
                    // if chance is of player 2 then mark O else mark X 
                    if (player % 2 == 0)  

                    {

                        arr[choice] = 'O';

                        player++;

                    }

                    else

                    {

                        arr[choice] = 'X';

                        player++;

                    }

                }

                /* If there is any position that the player wants to pick 
                which is already marked, then show message and load board again */

                else 

                {

                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);

                    Console.WriteLine("\n");

                    Console.WriteLine("Please wait 2 seconds, the board is loading again.....");

                    Thread.Sleep(2000);

                }

                // calling of check win 
                flag = CheckWin(); 

            /* This loop will be run until all cells of the grid are not
             marked with X and O or some player has not won */
            } 
            while (flag != 1 && flag != -1);  

            // clearing the console  
            Console.Clear();

            // Fill board again 
            Board(); 

            /* if flag value is 1 then a player has won or it will
            mean the player marked last will have the win */ 
            if (flag == 1)

            {

                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            
            }
            /* if flag value is -1 the match will be a draw and no one 
               is the winner */
            else 

            {

                Console.WriteLine("Draw");
            
            }

            Console.ReadLine();

        }

        // Board method; this creates the board  
        private static void Board()

        {

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");

        }

        //Checking if any player has won
        private static int CheckWin()

        {

            #region Horzontal Winning Condtion

            //Winning Condition For First Row   
            if (arr[1] == arr[2] && arr[2] == arr[3])

            {

                return 1;

            }

            //Winning Condition For Second Row   
            else if (arr[4] == arr[5] && arr[5] == arr[6])

            {

                return 1;

            }

            //Winning Condition For Third Row   
            else if (arr[6] == arr[7] && arr[7] == arr[8])

            {

                return 1;

            }

            #endregion



            #region Vertical Winning Condtion

            //Winning Condition For First Column       
            else if (arr[1] == arr[4] && arr[4] == arr[7])

            {

                return 1;

            }

            //Winning Condition For Second Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])

            {

                return 1;

            }

            //Winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])

            {

                return 1;

            }

            #endregion



            #region Diagonal Winning Condition

            //Winning Condition for Diagonals
            else if (arr[1] == arr[5] && arr[5] == arr[9])

            {

                return 1;

            }

            else if (arr[3] == arr[5] && arr[5] == arr[7])

            {

                return 1;

            }

            #endregion


 
            #region Checking For a Draw

            /* If all the cells or values are filled with X or O 
               then one of the players has won the match */ 

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')

            {

                return -1;

            }



            #endregion



            else

            {

                return 0;

            }

        }

    }

}  