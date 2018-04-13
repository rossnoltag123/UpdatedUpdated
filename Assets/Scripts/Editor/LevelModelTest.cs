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

        m.map[0,0] = LevelModel.SquareType.EDGE_OF_BOARD;

        LevelModel.SquareType expectedResult = LevelModel.SquareType.EDGE_OF_BOARD;

        //Act
        LevelModel.SquareType result = m.map[0,0];

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
        LevelModel m = new LevelModel(2);
        int expectedResult = 2;

        //Act
        int result1 = m.map.GetLength(0);
        int result2 = m.map.GetLength(1);

        //Assert
        Assert.AreEqual(expectedResult, result1);
        Assert.AreEqual(expectedResult, result2);
    }
 
    //Testing CompassDirections Enum Using Data provider
    [Test, TestCaseSource("ProviderCompassDirections")]
    public void test7_Player_Can_Walk_NORTH_SOUTH_EAST_WEST_From_Provider

        (int playPositionX, int playPositionY, int mapSize, bool expectedResult, LevelModel.CompassDirection direction)
    {
        //Arrange
        LevelModel m = new LevelModel(mapSize);
        m.map[1, 2] = LevelModel.SquareType.EMPTY_H0;
        m.map[2, 2] = LevelModel.SquareType.EMPTY_H0;
        m.map[2, 3] = LevelModel.SquareType.EMPTY_H0;
        m.map[1, 2] = LevelModel.SquareType.EMPTY_H0;
        m.map[1, 2] = LevelModel.SquareType.EMPTY_H0;
        m.playerX = playPositionX;
        m.playerY = playPositionY;

        m.Walk(direction);


        //Act
        bool result = m.GetLastActionSuccess();


        //Assert
        Assert.AreEqual(expectedResult, result);
    }
  
    [Test, TestCaseSource("OutOfBounds")]
    public void test8_Out_Of_Bounds_ImpassableVolcano_ImpassablePit_Move
     (int playPositionX, int playPositionY, int mapSize, bool expectedResult, LevelModel.SquareType squareType)
    {
        //Arrange
        LevelModel m = new LevelModel(6);
        m.playerX = 1;
        m.playerY = 1;

        //Out of bounds...
        m.map[0, 1] = squareType;

        m.Walk(LevelModel.CompassDirection.NORTH);

        //Act
        bool result = m.GetLastActionSuccess();

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test, TestCaseSource("Jump")]
    public void test9_Player_Can_Jump_From_Provider
    (int playPositionX, int playPositionY, int mapSize, bool expectedResult, LevelModel.SquareType squareType1, LevelModel.SquareType squareType2)
    {
        //Arrange
        LevelModel m = new LevelModel(mapSize);
        m.Jump(true);

        m.map[2, 2] = squareType1;
        m.map[3, 2] = squareType2;

        m.playerX = playPositionX;
        m.playerY = playPositionY;

        m.Walk(LevelModel.CompassDirection.SOUTH);

        //Act
        bool result = m.GetLastActionSuccess();

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    public void test10_Player_Cant_Jump_H0_To_H2_From_Provider
    (int playPositionX, int playPositionY, int mapSize, bool expectedResult, LevelModel.SquareType squareType1, LevelModel.SquareType squareType2)
    {
        //Arrange
        LevelModel m = new LevelModel(mapSize);
        m.Jump(true);

        m.map[2, 2] = squareType1;
        m.map[3, 2] = squareType2;

        m.playerX = playPositionX;
        m.playerY = playPositionY;

        m.Walk(LevelModel.CompassDirection.SOUTH);

        //Act
        bool result = m.GetLastActionSuccess();

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    //Data provider for Compass Directions Test
    static object[] ProviderCompassDirections=
    {
        new object[]{3,3,5,true,LevelModel.CompassDirection.NORTH},
        new object[]{3,3,5,true,LevelModel.CompassDirection.SOUTH},
        new object[]{3,3,5,true,LevelModel.CompassDirection.EAST},
        new object[]{3,3,5,true,LevelModel.CompassDirection.WEST}
    };

    static object[] Jump=
    {
        new object[]{3,3,5,true,LevelModel.SquareType.EMPTY_H0,LevelModel.SquareType.EMPTY_H1},
        new object[]{3,3,5,true,LevelModel.SquareType.EMPTY_H1,LevelModel.SquareType.EMPTY_H2}
    };

    static object[] OutOfBounds=
    {
        new object[]{3,3,5,false,LevelModel.SquareType.EDGE_OF_BOARD},
        new object[]{3,3,5,false,LevelModel.SquareType.IMPASSABLE_PIT},
        new object[]{3,3,5,false,LevelModel.SquareType.IMPASSABLE_VOLCANO}
    };
}


