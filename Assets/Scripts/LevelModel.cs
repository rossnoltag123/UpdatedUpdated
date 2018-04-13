using UnityEngine;

public class LevelModel
{
    //Everything is tested here. I just want to change the syntax around 
    // on the two mehtods  XMoveForDirection() YMoveForDirection(). The last two methods
    // at the bottom of the script.
    public enum SquareType
    {
        EMPTY_H0,       //For the sake of testing, i am putting out of bound second in the list becasue the default board is made of EMPTY_H0(walkable tiles).
        EDGE_OF_BOARD,  //I can test for Out of bounds specificly in the arrangement of a test. Map[0,0] = out of bounds, walk from Map[1,0](walkable) to Map[0,0].
        EMPTY_H1,
        EMPTY_H2,
        TARGET_H0_UNLIT,
        TARGET_H0_LIT,
        TARGET_H1_UNLIT,
        TARGET_H1_LIT,
        TARGET_H2_UNLIT,
        TARGET_H2_LIT,
        IMPASSABLE_PIT,
        IMPASSABLE_VOLCANO,
    };

    public SquareType squareType;

    public int mapSize { get; set; }
    public SquareType[,] map { get; set;}

    public int playerX { get; set; }
    public int playerY { get; set; }

    // Constuctor
    public LevelModel(int mapSize)
    {
        this.mapSize = mapSize;
        this.map = new SquareType[this.mapSize, this.mapSize];
    }

    public enum CompassDirection : int
    {
        NORTH = 0,//0
        SOUTH = 1,//1
        EAST = 2,//2
        WEST = 3//3
    } 
    public CompassDirection compassDirection;   

    private bool lastActionSuccess;
    public bool GetLastActionSuccess()
    {
        return lastActionSuccess;
    }

    private bool JumpFlag;

    public bool Jump(bool jumpflag)
    {
        JumpFlag = jumpflag;
        return JumpFlag;
    }

    public bool Walk(CompassDirection direction)
    {
        SquareType currentPlayerSquareType = map[playerX, playerY];//where the player is
        int moveToSquareX = GetMoveToSquareX(direction);
        int moveToSquareY = GetMoveToSquareY(direction);
        SquareType moveToSquareType = map[moveToSquareX, moveToSquareY];//where the destination is

        if (moveToSquareType == SquareType.EDGE_OF_BOARD || moveToSquareType == SquareType.IMPASSABLE_PIT || moveToSquareType == SquareType.IMPASSABLE_VOLCANO)
        {
            lastActionSuccess = false;
            return false;
        }

        // test for empty H0/H1/H2
        return TryWalk(moveToSquareType, currentPlayerSquareType, moveToSquareX, moveToSquareY);    

        // if we get this far - move not permitted     
        lastActionSuccess = false;
        return false;
    }

    private bool TryWalk(SquareType moveToSquareType, SquareType currentPlayerSquareType, int moveToSquareX, int moveToSquareY)
    {
        if (SquareType.EMPTY_H0 == moveToSquareType || SquareType.EMPTY_H1 == moveToSquareType ||
            SquareType.EMPTY_H2 == moveToSquareType)
        {
            if (moveToSquareType == currentPlayerSquareType)
            {
                // okay to move the player
                playerX = moveToSquareX;
                playerY = moveToSquareY;
                lastActionSuccess = true;
                return true;
            }
        
            if (moveToSquareType != currentPlayerSquareType)
            {   
               return TryJump(moveToSquareType, currentPlayerSquareType, moveToSquareX, moveToSquareY);          
            }     
        }
        // if we get this far - move not permitted

        lastActionSuccess = false;
        return false;
    }



    private bool TryJump(SquareType moveToSquareType, SquareType currentPlayerSquareType, int moveToSquareX, int moveToSquareY)
    {  
        if (currentPlayerSquareType == SquareType.EMPTY_H0 && moveToSquareType == SquareType.EMPTY_H1 || 
            currentPlayerSquareType == SquareType.EMPTY_H1 && moveToSquareType == SquareType.EMPTY_H2 && JumpFlag == true)
        {     
            playerX = moveToSquareX;
            playerY = moveToSquareY;
            lastActionSuccess = true;
            return true;
            // all else is false, cant jump, on H2 or from H0 to H2 etc.
        }
        lastActionSuccess = false;
        return false;
    }



    public int GetMoveToSquareX(CompassDirection direction)
    {
        int xMove = XMoveForDirection(direction);

        if ((playerX + xMove) >= 0)
        {
            return playerX + xMove;
        } 
        return 0;
    }

    public int GetMoveToSquareY(CompassDirection direction)
    {
        int yMove = YMoveForDirection(direction);
        if ((playerY + yMove) >= 0)
        {
            return playerY + yMove;
        }
        return 0;
    }

    private int XMoveForDirection(CompassDirection direction)
    {
        int[] xMoves = new int[4];
        xMoves[(int)CompassDirection.NORTH] = -1;
        xMoves[(int)CompassDirection.SOUTH] = 1;
        xMoves[(int)CompassDirection.EAST] = 0;
        xMoves[(int)CompassDirection.WEST] = 0;
        return xMoves[(int)direction];
    }

    private int YMoveForDirection(CompassDirection direction)
    {
        int[] yMoves = new int[4];
        yMoves[(int)CompassDirection.EAST] = -1;
        yMoves[(int)CompassDirection.WEST] = 1;
        yMoves[(int)CompassDirection.NORTH] = 0;
        yMoves[(int)CompassDirection.SOUTH] = 0;
        return yMoves[(int)direction];
    } 
}


