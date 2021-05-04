using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallController : MonoBehaviour
{
    public static BallController Instance;
    [HideInInspector] public Rigidbody2D rb;
    public int AcornjumpCounter = -1;
    public int CarrotjumpCounter = -1;
    public int BallDestroyedCounter = 0;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Acorn")
        {
            FindObjectOfType<AudioController>().Play("AcornBounce");
            if (AcornjumpCounter < 2)
            {
                AcornjumpCounter += 1;
            }
            GameManager.Instance.spawnAndDestroyNumbers(AcornjumpCounter, collision.gameObject.transform.position + GameManager.Instance.offset);
            collision.gameObject.GetComponent<Obstacles>().ChangetheSprite();
            Destroy(collision.transform.gameObject, 0.5f);
            if (AcornjumpCounter == 0)
            {
                // GameManager.Instance.Score += 100;
                GameManager.Instance.GiveScore(100);
            }
            if (AcornjumpCounter == 1)
            {
                // GameManager.Instance.Score += 120;
                GameManager.Instance.GiveScore(120);
            }
            if (AcornjumpCounter > 1)
            {
                //GameManager.Instance.Score += 140;
                GameManager.Instance.GiveScore(140);
            }
        }
        if (collision.collider.tag == "Bucket")
        {
            FindObjectOfType<AudioController>().Play("Yummy");
            Destroy(gameObject);
            BallDestroyedCounter += 1;
            //GameManager.Instance.Score += 200;
            GameManager.Instance.GiveScore(200);
        }
        if (collision.collider.tag == "Carrot")
        {
            LevelTasks.Instance.CarrotCounter += 1;
            if (CarrotjumpCounter < 2)
            {
                CarrotjumpCounter += 1;
            }
            FindObjectOfType<AudioController>().Play("CarrotBounce");
            GameManager.Instance.spawnAndDestroyNumbers(CarrotjumpCounter, collision.gameObject.transform.position + GameManager.Instance.offset);
            collision.gameObject.GetComponent<Obstacles>().ChangetheSprite();
            Destroy(collision.transform.gameObject, 0.5f);
           // GameManager.Instance.Score += 100;
            if (CarrotjumpCounter == 0)
            {
                //GameManager.Instance.Score += 100;
                GameManager.Instance.GiveScore(100);
            }
            if (CarrotjumpCounter == 1)
            {
                // GameManager.Instance.Score += 120;
                GameManager.Instance.GiveScore(120);
            }
            if (CarrotjumpCounter > 1)
            {
                //GameManager.Instance.Score += 140;
                GameManager.Instance.GiveScore(140);
            }
        }
        if (collision.collider.tag == "wood")
        {
            FindObjectOfType<AudioController>().Play("Wood");
            collision.gameObject.GetComponent<Obstacles>().ChangeAndDestroySprite();
            //GameManager.Instance.Score += 100;
            GameManager.Instance.GiveScore(100);
        }
        if (collision.collider.tag == "Chili")
        {
            FindObjectOfType<AudioController>().Play("ChiliBounce");
            collision.gameObject.GetComponent<Obstacles>().ChangeAndDestroySprite();
            //GameManager.Instance.Score += 100;
            GameManager.Instance.GiveScore(100);
        }
        if (collision.collider.tag == "Lid")
        {
            FindObjectOfType<AudioController>().Play("Lid");
            collision.gameObject.GetComponent<Obstacles>().ChangeAndDestroySprite();
            //GameManager.Instance.Score += 100;
            GameManager.Instance.GiveScore(100);
        }
        if (collision.collider.tag == "GlassLid")
        {
            FindObjectOfType<AudioController>().Play("GlassLid");
            collision.gameObject.GetComponent<Obstacles>().ChangeAndDestroySprite();
            //GameManager.Instance.Score += 100;
            GameManager.Instance.GiveScore(100);
        }
        if (collision.collider.tag == "Boundary")
        {
          FindObjectOfType<AudioController>().Play("Boundary");
        }
        if (collision.collider.tag == "PointBonus")
        {
           Destroy(collision.transform.gameObject);
            //GameManager.Instance.Score = 100;
            GameManager.Instance.GiveScore(100);
        }

    }
}
