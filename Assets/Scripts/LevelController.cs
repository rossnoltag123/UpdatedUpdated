using UnityEngine;

public class LevelController 
{
    public LevelModel model;
    public LevelView view;
    public InputController input;
    public LevelLayoutFromTextFile textFile;

    public void SetModel(LevelModel model){
        this.model = model;
    }

    public void SetView(LevelView view){
        this.view = view; 
    }

    public void SetInput(InputController input){
        this.input = input;
    }





}
