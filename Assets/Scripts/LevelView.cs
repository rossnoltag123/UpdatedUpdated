using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class LevelView 
{
 //   private LevelController controller;
 //   private LevelModel model;
    public LevelLayoutFromTextFile textFile;
/*
    public void SetModel(LevelModel model)
    {    
         this.model = model;
    }
/*
    public void SetController(LevelController controller )
    {
        this.controller = controller;
    }
    */

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
}

 


