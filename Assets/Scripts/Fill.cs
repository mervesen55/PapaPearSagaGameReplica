using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    public Image fill;
    public static Fill Instance;
    public float DivideValue = 24000;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        fill.fillAmount = GameManager.Instance.Score / DivideValue;
   
    }
    public void ScoreFill(int score)
    {
        fill.fillAmount = (score/DivideValue);
        
        Debug.Log(fill.fillAmount);
        
    }
}
