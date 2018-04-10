using UnityEngine;

public class InputController 
{
    //There was input to be taken from the UI, from some sort of controller. This was to handle it.

    public enum Input
    {
        WALK_NORTH,//Walk north 1
        WALK_SOUTH,//""
        WALK_EAST,//""
        WALK_WEST,//""
        TURN_LEFT,//
        TURN_RIGHT,//
        ACTION,//Do action
        JUMP//Allow to walk up 1 level of steps     
    }

    public Input input;
    public LevelModel model;

    public LevelModel.CompassDirection North = LevelModel.CompassDirection.NORTH;
    public LevelModel.CompassDirection South = LevelModel.CompassDirection.SOUTH;
    public LevelModel.CompassDirection East = LevelModel.CompassDirection.EAST;
    public LevelModel.CompassDirection West = LevelModel.CompassDirection.WEST;

    
    public void Directon(LevelModel.CompassDirection direction)
    {
        model.Walk(direction);
    }
 
    /*
        void Update()
        {
            if (Input.GetKeyDown("w")){
                LevelModel.CompassDirection compassDir = LevelModel.CompassDirection.NORTH;
            }
            if (Input.GetKeyDown("s")){
                model.compassDir = LevelModel.CompassDirection.SOUTH;
            }
            if (Input.GetKeyDown("a")){
                model.compassDir = LevelModel.CompassDirection.EAST;

            }
            if (Input.GetKeyDown("d")){
                model.compassDir = LevelModel.CompassDirection.WEST;
            }
        }

        public int GetMoveToSquareX(CompassDirection direction)
        {

            switch (MoveToSquare)
            {
                case CompassDirection.NORTH:
                    playerX -= 1;
                    playerY += 0;
                    break;
                case CompassDirection.SOUTH:
                    playerX += 1;
                    playerY += 0;
                    break;
            }
        }

        public void GetMoveToSquareY(CompassDirection direction)
        {
            switch (MoveToSquare)
            {
                case CompassDirection.EAST:
                    playerX -= 0;
                    playerY += 1;
                    break;
                case CompassDirection.WEST:
                    playerX += 0;
                    playerY -= 1;
                    break;
            }
        }
        */
}