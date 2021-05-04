using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Gri tuğla spritelarını açık gri spritelara döndürecek
    public void ChangetheSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
    public void ChangeAndDestroySprite()
    {
        if (spriteRenderer.sprite == newSprite)
        {
            Destroy(gameObject);
            //GameManager.Instance.Score += 100;
            GameManager.Instance.GiveScore(100);
        }
        spriteRenderer.sprite = newSprite;
    }
    }
