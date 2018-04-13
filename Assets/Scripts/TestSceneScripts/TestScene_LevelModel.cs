using UnityEngine;

public class TestScene_LevelModel
{
    //Everything is tested here. I just want to change the syntax around 
    // on the two mehtods  XMoveForDirection() YMoveForDirection(). The last two methods
    // at the bottom of the script.
    public enum SquareType
    {
        EMPTY_H0,
        EMPTY_H1,
        EDGE_OF_BOARD,

        EMPTY_H2,
        TARGET_H0_UNLIT,
        TARGET_H0_LIT,
        TARGET_H1_UNLIT,
        TARGET_H1_LIT,
        TARGET_H2_UNLIT,
        TARGET_H2_LIT,
        IMPASSABLE_PIT,
        IMPASSABLE_VOLCANO,
        OBSTACLE_ICE,
        OBSTACLE_FIRE
    };

    public int mapSize { get; set; }
    public SquareType[,] map { get; set; }

    public int playerX { get; set; }
    public int playerY { get; set; }

   // public LevelModel(int mapSize)
  //  {
   //     this.mapSize = mapSize;
  //      this.map = new SquareType[this.mapSize, this.mapSize];
   // }

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

    public bool Walk(CompassDirection direction)
    {
        SquareType currentPlayerSquareType = map[playerX, playerY];
        int moveToSquareX = GetMoveToSquareX(direction);//North = -1 (X)    
        int moveToSquareY = GetMoveToSquareY(direction);// North = 0 (Y) pass in "north" and get value for it returned
        SquareType moveToSquareType = map[moveToSquareX, moveToSquareY];

        if (moveToSquareType == SquareType.EDGE_OF_BOARD)
        {
            lastActionSuccess = false;
            return false;
        }

        // test for empty H0/H1/H2
        return TryWalkH0H1(moveToSquareType, currentPlayerSquareType, moveToSquareX, moveToSquareY);

        // if we get this far - move not permitted
       // lastActionSuccess = false;
       // return false;
    }

    private bool TryWalkH0H1(SquareType moveToSquareType, SquareType currentPlayerSquareType, int moveToSquareX, int moveToSquareY)
    {
        if (SquareType.EMPTY_H0 == moveToSquareType || SquareType.EMPTY_H1 == moveToSquareType)
        {
            if (moveToSquareType == currentPlayerSquareType)
            {
                // okay to move the player
                playerX = moveToSquareX;
                playerY = moveToSquareY;

                lastActionSuccess = true;
                return true;
            }
        }
        // if we get this far - move not permitted
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

    //Need to change the (int) for both methods,
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
        yMoves[(int)CompassDirection.NORTH] = 0;
        yMoves[(int)CompassDirection.SOUTH] = 0;
        yMoves[(int)CompassDirection.EAST] = -1;
        yMoves[(int)CompassDirection.WEST] = 1;
        return yMoves[(int)direction];
    }
}


