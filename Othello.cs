using System;
namespace Othello
{
    class Othello
    {
        //Othello State Variables
        private int size;
        private char disc;
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
            this.disc = p3;
            InitBoard(p1); //Initialize Board with starting values
        }
        // Iterates next turn in othello. Used twice if no valid moves available for next player
        public void NextTurn()
        {
            if(this.disc == WHITE)
            {
                this.disc = BLACK;
            } else
            {
                this.disc = WHITE;
            }
        }
        //Returns true if and only if it is between 0 and size-1. used by checkdirection
        public bool OuttaBounds(int i, int j)
        {
            if(i < 0 || j < 0)
            {
                
                return true;
            }
            if(i >= size || j >= size)
            {
                
                return true;
            }
            return false;
        }
        /*
         * Checks the direction given in the actual params. 
         * returns true if a move can be placed
         */
        public bool CheckDirection(int i, int j, int[] dir)
        {
            bool done = false;
            bool match = true;
            int r = i + dir[0];
            int c = j + dir[1];
            if(this.board[i,j] != EMPTY)
            {
                return false;
            }
            if(OuttaBounds(r,c))
            {
                return false;
            }
            if(this.board[r,c] == disc)
            {
                return false;
            }
            



            while(!done)
            {
                if(dir[0] == 1 && OuttaBounds(r, c))
                {
                    
                    return false;
                }
                if(dir[0] == -1 && OuttaBounds(r, c))
                {
                    return false;
                }
                if(dir[1] == 1 && OuttaBounds(r,c))
                {
                    return false;
                }
                if (dir[1] == -1 && OuttaBounds(r, c))
                {
                    return false;
                }
                if (this.board[r, c] == disc)
                {
                    return true;
                }
                if (this.board[r,c] == EMPTY)
                {
                    return false;
                }
                
                
                r += dir[0];
                c += dir[1];
                if(OuttaBounds(r,c))
                {
                    done = true;
                }
            }

            return false;
        }

        /*
         * Determines if the tile in board[i,j] contains a direction that makes the move valid.
         */
        public bool IsValidMove(int i, int j)
        {
            bool directioncheck = false;
            //Check each direction using check dir and specified direction.
            if(CheckDirection(i,j,UP))
            {
                directioncheck = true;
            }
            if(CheckDirection(i,j,DOWN))
            {
                directioncheck = true;
            }
            if(CheckDirection(i,j,LEFT))
            {
                directioncheck = true;
            }
            if(CheckDirection(i,j,RIGHT))
            {
                directioncheck = true;
            }
            if(CheckDirection(i,j,UP_LEFT))
            {
                directioncheck = true;
            }
            if(CheckDirection(i,j,UP_RIGHT))
            {
                directioncheck = true;
            }
            if(CheckDirection(i,j,DOWN_LEFT))
            {
                directioncheck = true;
            }
            if(CheckDirection(i,j,DOWN_RIGHT))
            {
                directioncheck = true;
            }
            
            if(directioncheck)
            {
                return true;
            }
            return false;
        }
        /*
         * For loop that checks each tile and board and tells us if there is a valid move available on the board.
         */
        public bool IsValidMoveAvailable(char disc)
        {
            bool valid = false;
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(IsValidMove(i, j))
                    {
                        Console.Write("Valid Move Found: ");
                        Console.Write(i);
                        Console.Write(SPACE);
                        Console.WriteLine(j);
                        valid = true;
                    }
                }
            }
            if(valid)
            {
                return true;
            }
            return false;
        }
        /*
         * Places disc at [i,j] in board. Initiates next turn
         */
        public void PlaceDisc(int i, int j)
        {
            //Place disc at location, IsValidMove+Available already used in Main
            this.board[i, j] = this.disc;
        }

        /*
         Prints the board and its value 'B' is black, 'W' is white. X is empty
         An index vertical and horizontal based on board[][] is also printed
         Starting number for index is zero because that is what board starts at in C#
        */
        public void PrintBoard()
        {
            //Create index horizontally as first line
            Console.Write(SPACE);
            Console.Write(SPACE);
            for(int i = 0; i < size; i++)
            {
                Console.Write(i);
                Console.Write(SPACE);
            }
            Console.WriteLine();
            //Draw board + vertical index
            for(int i = 0; i < size; i++)
            {
                //Create index vertically
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
            if(BoardFull())
            {
                return true;
            }
            
              if(!IsValidMoveAvailable(BLACK) && !IsValidMoveAvailable(WHITE))
            {
                return true;
            }
                   
             
            return false;
        }
        public bool BoardFull()
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(board[i,j] == EMPTY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public char CheckWinner()
        {
            int white = 0;
            int black = 0;
            if(!GameOver())
            {
                return '0';
            } else
            {
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        if(board[i,j] == BLACK)
                        {
                            black++;
                        }
                        if(board[i,j] == WHITE)
                        {
                            white++;
                        }
                    }
                }
            }
            if(white < black)
            {
                return BLACK;
            }
            if(black < white)
            {
                return WHITE;
            }
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
                if((p == "B" || p == "W") && !discenter)
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
            Console.WriteLine("Starting game...");
            Othello game = new Othello(num, num, disc);
            Console.Write("Player 1: ");
            Console.WriteLine(disc);
            
            
            //Game Loop
            while(!game.GameOver())
            {
                game.PrintBoard();
                //If invalid place disc for all tiles, change turn.
                if (!game.IsValidMoveAvailable(game.disc))
                {
                    Console.WriteLine("No valid moves available disc. You lose 1 turn");
                    game.NextTurn();
                } else
                {
                    //User Input loop
                    bool valid = false;
                    int row = 0;
                    int col = 0;
                    while(!valid)
                    {

                        Console.WriteLine("Your turn. Please enter a coordinate:");
                        string[] input = Console.ReadLine().Split();
                        row = int.Parse(input[0]);
                        col = int.Parse(input[1]);
                        
                        //If invalid or outtabounds, ask for input again
                        if (game.OuttaBounds(row, col))
                        {
                            Console.WriteLine("Your input is out of bounds try again:");
                            input = Console.ReadLine().Split();
                            valid = false;
                        }
                        if (!game.IsValidMove(row, col))
                        {
                            Console.WriteLine("Your input is not a valid move try again:");
                            valid = false;
                        } else
                        {
                            valid = true;
                        }
                    }
                    //Input is valid, place disc on board
                    game.PlaceDisc(row, col);
                    game.NextTurn();
                    //Implement testing for all methods up to here

                }
                
                
                
            }
            //Once game is over print final board
            //CheckWinner
            //Print victory/tie/loss String
            //Test last of methods, simulate game
            //Close program

        }

        //END OF CLASS SCOPE
        //Methods todo:
        /*
            checkdir
            isvalid_move
            placedisc
            isvalid_move_available


        */
    }
}

