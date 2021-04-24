using System;
namespace Othello
{
    class Othello
    {
        //Othello State Variables
        private int size;
        private char playerdisc;
        private char[,] board;

        //Board Values
        private char EMPTY = 'X';
        private char BLACK = 'B';
        private char WHITE = 'W';
        private char SPACE = ' ';
        private char TIE = 'T';
        //These arrays are used to check direction 0:row, 1:col
        private int[] LEFT = { 0, -1 };
        private int[] RIGHT = { 0, 1 };
        private int[] UP = { -1, 0 };
        private int[] DOWN = { 1, 0 };
        //Diagonal directions
        private int[] UP_LEFT = { -1, -1 };
        private int[] UP_RIGHT = { -1, 1 };
        private int[] DOWN_LEFT = { 1, -1 };
        private int[] DOWN_RIGHT = { 1, 1 };
        //Constructor
        public Othello(int p1, int p2, char p3)
        {
            //Command line checking done via Driver
            this.size = p1;
            this.playerdisc = p3;
            InitBoard(p1); //Initialize Board with starting values
        }
        /*
         Prints the board and its value 'B' is black, 'W' is white. X is empty
         An index vertical and horizontal based on board[][] is also printed
         Starting number for index is zero because that is what board starts at in C#
        */
        public void PrintBoard()
        {
            //Create index vertically as first line
            Console.Write(SPACE);
            Console.Write(SPACE);
            for(int i = 0; i < size; i++)
            {
                Console.Write(i);
                Console.Write(SPACE);
            }
            Console.WriteLine();
            for(int i = 0; i < size; i++)
            {
                Console.Write(i);
                Console.Write(SPACE);
                for(int j = 0; j < size; j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(SPACE);
                }
                Console.WriteLine();
            }
        }
        public bool GameOver()
        {
            //FIXME: add method
            return false;
        }
        public bool BoardFull()
        {
            //FIXME: add method
            return false;
        }
        public char CheckWinner()
        {
            //FIXME: add method
            return 'T';
        }
        /*
        Initializes the board with blank sheets and provides values for the starting board based on size
        */
        public void InitBoard(int size)
        {
            this.board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.board[i,j] = EMPTY;
                }
            }
            //Starting disc values
            this.board[size / 2 - 1, size / 2 - 1] = BLACK;
            this.board[size / 2 - 1, size / 2] = WHITE;
            this.board[size / 2, size / 2 - 1] = WHITE;
            this.board[size / 2, size / 2] = BLACK;
        }
        //Driver Method for Othello
        static void Main(string[] args)
        {
            Console.WriteLine("<<<Welcome to the game of Othello>>>");
            //Ask user for input for othello, command line checking
            //Implement turn change in Othello Class
            bool doneInput = false;
            int num = 0;
            char disc = 'W';
            while (!doneInput)
            {
                Console.WriteLine("Please enter size for size x size othello matrix");
                string s = Console.ReadLine();
                bool sizeenter = false;
                bool discenter = false;
                if ((s == "4" || s == "6" || s == "8") && !sizeenter)
                {
                    num = Int32.Parse(s);
                    sizeenter = true;
                } else
                {
                    Console.WriteLine("Invalid input size, please try again");
                }
                Console.WriteLine("Please enter B or W for player color");
                string p = Console.ReadLine();
                if(p == "B" && !discenter)
                {
                    disc = Char.Parse(p);
                    discenter = true;
                } else
                {
                    Console.WriteLine("Invalid input please try again");
                }
                if(sizeenter && discenter)
                {
                    doneInput = true;
                }
            }
            
            Othello game = new Othello(num, num, disc);
            game.PrintBoard();
            //Game Loop
            while(!game.GameOver())
            {
                //Print board
                //Check if valid move available. If no valid move change turn twice.
                //Else ask for user input of disc location
                    //If invalid, outofbounds, or not valid ask again
                    //If valid place disc and change turn.
            }
            //Once game is over print final board
            //CheckWinner
            //Print victory/tie/loss String
            //Close program

        }

        //END OF CLASS SCOPE
        //Methods todo:
        /*
            checkdir +outofbounds?
            isvalid_move
            placedisc
            isvalid_move_available
            isboardfull
            isgameover
            checkwinner

        */
    }
}

