using UnityEngine;
using System.Collections.Generic;
using System;

public class InputController
{
    //There was input to be taken from the UI, from some sort of controller. This was to handle it.
    public enum Input
    {
        WALK,//Walk north 1
        TURN_LEFT,//
        TURN_RIGHT,//
        ACTION,//Do action
        JUMP//Allow to walk up 1 level of steps     
    }

    private bool JumpFlag;//false

    public Input input;
    private LevelModel model;

    public LevelModel.CompassDirection North = LevelModel.CompassDirection.NORTH;
    public LevelModel.CompassDirection South = LevelModel.CompassDirection.SOUTH;
    public LevelModel.CompassDirection East = LevelModel.CompassDirection.EAST;
    public LevelModel.CompassDirection West = LevelModel.CompassDirection.WEST;

    public void SetModel(LevelModel model)
    {
        this.model = model;
    }

    public bool Jump()
    {
        JumpFlag = true;
        return JumpFlag;
    }

    public void Action()
    {
        //Action
    }

    public void Directon(LevelModel.CompassDirection direction)
    {
        model.Walk(direction);
    }
}