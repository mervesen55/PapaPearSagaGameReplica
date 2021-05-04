using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTasks : MonoBehaviour
{
    //private bool TasksCompleted = false;
    public int DroppedFruit = 0;
    public int CarrotCounter = 0;
    public static LevelTasks Instance;
    private bool level1 = true;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.Instance.Score >= 8000)
        //{
        //    GameManager.Instance.TasksCompleted = true;
        //}
    }

    public bool IsLevel1TasksCompleted()
    {
        if (GameManager.Instance.Score >= 8000 && level1)
        {
            level1 = false;
            return true;
            
        }
        else
        {
            return false;
        }
    }

    public bool IsLevel2TasksCompleted()
    {
        if (GameManager.Instance.Score >= 5000 && DroppedFruit == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsLevel3TasksCompleted()
    {
        if (GameManager.Instance.Score >= 5000 && CarrotCounter == 30)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
