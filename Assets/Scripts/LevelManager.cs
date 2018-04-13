using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private LevelModel model;
  //  private LevelController controller;
    private LevelView view;
    private LevelLayoutFromTextFile textFile;
    private InputController inputController;
    //private LevelView2 view2

    void Start()
    {
        //Text File Class
        textFile = new LevelLayoutFromTextFile(); 
        textFile.ReadTextFile();
   
        //model
        model = new LevelModel(18);

        // Controller 
        /*
        controller = new LevelController();
        controller.SetModel(model);
        controller.SetView(view);
        */

        inputController = new InputController();
        inputController.SetModel(model);

        // View 
        view = new LevelView();
        // view.SetModel(model);
        view.SetTextFile(textFile);
       // view.Refresh();
       // view.UpdateTextDisplay(z);

    }
}