using UnityEngine;

public class TestScene_LevelController
{
    private TestScene_LevelModel model;
    private TestScene_LevelView view;
    private LevelLayoutFromTextFile textFile;

    public void SetModel(TestScene_LevelModel model)
        {
            this.model = model;
        }

    public void SetView(TestScene_LevelView view)
        {
            this.view = view;
        }
    }
