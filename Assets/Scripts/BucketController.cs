using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public static BucketController Instance;
    public Sprite newSprite;

    private SpriteRenderer spriteRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Fruit")
        {
            Destroy(collision.transform.gameObject);
            GameManager.Instance.Score += 1000; // oyunda kaç puan veriyor bakıp güncelle
            LevelTasks.Instance.DroppedFruit += 1;
            Debug.Log(LevelTasks.Instance.DroppedFruit);
        }
    }
}
