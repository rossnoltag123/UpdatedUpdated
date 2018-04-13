using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class TestScene_LevelView
{
    private TestScene_LevelController controller;
    private TestScene_LevelModel model;
    private TestScene_LevelLayoutFromTextFile textFile;

    private void SetModel(TestScene_LevelModel model)
    {
        this.model = model;
    }

    private void SetController(TestScene_LevelController controller)
    {
        this.controller = controller;
    }

    public void SetTextFile(TestScene_LevelLayoutFromTextFile textFile)
    {
        this.textFile = textFile;
    }

    // I was testing some text displays, workin progress.
    private void Refresh()
    {
        //test
        // textFile.levelLayOutString;
        // textFile.ConvertArrayStringtoNumber( 10, 11);
        // controller.TextFile();//returns a string.....
    }

    public void UpdateTextDisplay(int z)
    {
        int startPosition = 2;
    //    string destination = "x";
        string currentPosition = "P";

        Debug.Log("start" + startPosition);
        textFile.levelLayOutArrayWrite[startPosition] = currentPosition;
       // Debug.Log("start" + startPosition);

        textFile.levelLayOutArrayWrite[z] = currentPosition;
        Debug.Log("destination" + z);

        string newString = string.Join(" ", textFile.levelLayOutArrayWrite);
        Debug.Log(newString);
    }
}

