using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class LevelView 
{
    private LevelController controller;
    private LevelModel model;
    public LevelLayoutFromTextFile textFile;
 

    //private int aPlayer = 8;
    //private int bDestination = 0;
    //string[] levelLayOut = textFile.levelLayOutArrayWrite;

    public void SetModel(LevelModel model)
    {    
         this.model = model;
    }

    public void SetController(LevelController controller )
    {
        this.controller = controller;
    }

    public void SetTextFile(LevelLayoutFromTextFile textFile)
    {
        this.textFile = textFile;
    }

    // I was testing some text displays, workin progress.
    public void Refresh()
    { 
        //test
        // textFile.levelLayOutString;
        // textFile.ConvertArrayStringtoNumber( 10, 11);
        // controller.TextFile();//returns a string.....
    }

    public void UpdateTextDisplay(int z)
    {
        int startPosition = 2;
        string destination = "x";
        string currentPosition = "P";
        int previousPosition;
        string repaint="";
       
      
        textFile.levelLayOutArrayWrite[startPosition] = currentPosition;
        Debug.Log("start"+startPosition);

 

        textFile.levelLayOutArrayWrite[z] = currentPosition;
        Debug.Log("destination"+z);

        // textFile.levelLayOutArrayWrite[z+=1] = destination;

        // textFile.levelLayOutArrayRead[z+=1] = repaint;
        // textFile.levelLayOutArrayWrite[z+=1] = repaint;
        // int index = Array.FindIndex(textFile.levelLayOutArrayWrite, element => element.Contains("P"));


        // previousPosition = index;
        // Debug.Log("index"+ previousPosition);

        // textFile.levelLayOutArrayWrite[previousPosition]=
        // textFile.levelLayOutArrayRead[previousPosition];


        // textFile.levelLayOutArrayWrite[z] = previousPosition;
        // textFile.levelLayOutArrayWrite[0] = textFile.levelLayOutArrayRead[0];
        string newString = string.Join(" ", textFile.levelLayOutArrayWrite);
        Debug.Log(newString);
    }

   
}

 


