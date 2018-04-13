using UnityEngine;
using UnityEngine.UI;

public class TestScene_LevelManager : MonoBehaviour
{
    private TestScene_LevelModel model;
    private TestScene_LevelController controller;
    private TestScene_LevelView view;
    private TestScene_LevelLayoutFromTextFile textFile;
    public Text screenTextLevel;
    private int z = 0;

    void Start()
    {
        //Text File Class
        textFile = new TestScene_LevelLayoutFromTextFile();

        textFile.ReadTextFile();

        //model
     //   model = new TestScene_LevelModel(18);

        // Controller
        controller = new TestScene_LevelController();
        controller.SetModel(model);
        controller.SetView(view);

        // View 
        view = new TestScene_LevelView();
        view.SetTextFile(textFile);
    
        DisplayTextLevel();
        onClickAdd1();
    }

    private void DisplayTextLevel() { screenTextLevel.text = textFile.levelLayOutString; }

    private void onClickAdd1()
    {
        z++;
        view.UpdateTextDisplay(z);
    }
}