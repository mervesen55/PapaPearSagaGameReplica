using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallRight : MonoBehaviour
{
    public Text BallRighText;
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BallRighText.text = gameManager.BallRight.ToString("0");
    }
}
