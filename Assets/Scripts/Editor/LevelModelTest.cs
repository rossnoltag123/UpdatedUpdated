using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using UnityEngine;

public class LevelModelTest
{
    
    [Test]
    public void test1_Square_Type_Enum_MapSize_Get_Set()
    {
        //Arrange
        LevelModel m = new LevelModel(1);
        int expectedResult = 1;

        //Act
        int result = m.map.Length;

        //Assert
        Assert.AreEqual(expectedResult, result);

    }

    [Test]
    public void test2_Square_Type_Enum_Array_Setting_Values()
    {
        //Arrange
        LevelModel m = new LevelModel(4);

        LevelModel.SquareType expectedResult = LevelModel.SquareType.EMPTY_H0;

        //Act
        LevelModel.SquareType result = m.map[0, 0];

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void test3_Player_X_Get_Set()
    {
        //Arrange
        LevelModel m = new LevelModel(1);

        //Set
        m.playerX = 1;
        int expectedResult = 1;

        //Act - Get
        int result = m.playerX;

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void test4_Player_Y_Get_Set()
    {
        //Arrange
        LevelModel m = new LevelModel(1);

        //Set
        m.playerY = 1;
        int expectedResult = 1;

        //Act - Get
        int result = m.playerY;

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void test5_Constructor_MapSize()
    {
        //Arrange
        LevelModel m = new LevelModel(1);
        int expectedResult = 1;

        //Act
        int result = m.mapSize;

        //Assert    
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void test6_Square_Type_Map_ArraySize_In_Constructor()
    {
        //Arrange
        LevelModel m = new LevelModel(1);
        int expectedResult = 1;

        //Act
        int result = m.map.Length;

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

        //Testing CompassDirections Enum Using Data provider

    [Test, TestCaseSource("ProviderCompassDirections")]
    public void test8_Player_Can_Walk_NORTH_SOUTH_EAST_WEST_From_Provider
        (int x, int y, int z, bool expectedResult, LevelModel.CompassDirection direction)
    {
        //Arrange
        LevelModel m = new LevelModel(z);
        m.playerX = x;
        m.playerY = y;
        m.Walk(direction);

        //Act
        bool result = m.GetLastActionSuccess();

        //Asses
        Assert.AreEqual(expectedResult, result);
    }

    //Data provider for Compass Directions Test
    static object[] ProviderCompassDirections =
    {
        new object[]{2,2,4,true,LevelModel.CompassDirection.NORTH},
        new object[]{2,2,4,true,LevelModel.CompassDirection.SOUTH},
        new object[]{2,2,4,true,LevelModel.CompassDirection.EAST},
        new object[]{2,2,4,true,LevelModel.CompassDirection.WEST}
    };

    [Test]
    public void test7_Out_Of_Bounds_Move()
    {
        //Arrange
        LevelModel m = new LevelModel(4);
        m.playerX = 1;
        m.playerY = 1;

        //Out of bounds..
        m.map[0, 1] = LevelModel.SquareType.EDGE_OF_BOARD;

        m.Walk(LevelModel.CompassDirection.NORTH);

        bool expectedResult = false;

        //Act
        bool result = m.GetLastActionSuccess();

        //Asses
        Assert.AreEqual(expectedResult, result);
    }
}


