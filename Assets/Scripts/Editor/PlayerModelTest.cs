using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class PlayerModelTest
{
    [Test]
    public void NewPlayerNameTest()
    {
        //Arrange
        PlayerModel p = new PlayerModel();
        string expectedResult = "";

        //Act
        string result = p.GetName();
        
        //Assert    
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void NewPlayerScoreTest()
    {  
        //Arrange
        PlayerModel p = new PlayerModel();
        int expectedResult = 0;

        //Act
        int result = p.GetScore();

        //Assert    
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void NewPlayerMovesTest()
    {
        //Arrange
        PlayerModel p = new PlayerModel();
        int expectedResult = 0;

        //Act
        int result = p.GetMoves();

        //Assert    
        Assert.AreEqual(expectedResult, result);

    }
}
/*
    [Test]
    public void test2_Square_Type_Enum_In_Constructor()
    {
        //Arrange
        LevelModel m = new LevelModel(4);
        LevelModel.SquareType expectedResult = LevelModel.SquareType.START_SQUARE;

        //Act
        LevelModel.SquareType result = m.map[0,0];

        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void test3_Square_Type_Enum_In_Constructor()
    {
        //Arrange
        LevelModel m = new LevelModel(4);

       // LevelModel.SquareType expectedResult =     m.map[3,3] = LevelModel.SquareType.OBSTACLE_FIRE;

        LevelModel.SquareType expectedResult = LevelModel.SquareType.OBSTACLE_FIRE;

        //Act
        LevelModel.SquareType result = m.map[3, 3];


        //Assert
        Assert.AreEqual(expectedResult, result);
    }
    */
