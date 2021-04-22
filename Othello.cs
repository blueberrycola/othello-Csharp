public class Othello {
    
    private int size;
    private char playerdisc;
    private char EMPTY = 'X';
    private char BLACK = 'B';
    private char WHITE = 'W';
    private char SPACE = ' ';
    private char[][] board;

    public Othello(int p1, int p2, char p3) {
        //Command line checking done via Driver
        this.size = p1;
        this.playerdisc = p3;
        initBoard();
    }
    //testme
    /*
        Prints the board and its value 'B' is black, 'W' is white. X is empty
        An index vertical and horizontal based on board[][] is also printed
        Starting number for index is zero because that is what board starts at in C#
    */
    public string printBoard(int size, char[] board) {
        //Create size index horizontally
        for(int i = 0; i < size; i++) {
            Console.Write(i + ' ');
        }
        Console.WriteLine("");
        
        for(int i = 0; i < size; i++) {
            //Write index vertically for each row
            Console.Write(i + SPACE);
            for(int j = 0; j < size; j++) {
                Console.Write(board[i][j] + SPACE);
            }
            //New line
            Console.WriteLine("");
        }
    }
    /*
    Initializes the board with blank sheets and provides values for the starting board based on size
    */
    public void initBoard(int size, char[] board) {
        for(int i = 0; i < size; i++) {
            for(int j = 0; j < size; j++) {
                board[i][j] = EMPTY;
            }
        }
        //Starting disc values
        board[size/2 - 1][size/2 - 1] = BLACK;
	    board[size/2 - 1][size/2] = WHITE;
	    board[size/2][size/2 - 1] = WHITE;
	    board[size/2][size/2] = BLACK;
    }
}