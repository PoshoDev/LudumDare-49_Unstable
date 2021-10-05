using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float i;
    private LevelLoader scrLoader;
    private bool alive = true;
    private Vector3 og;
    private AudioSource AS;
    // Start is called before the first frame update
    void Awake()
    {

        AS = gameObject.GetComponent<AudioSource>();
        og = gameObject.transform.position;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        scrLoader = (LevelLoader)GameObject.FindGameObjectWithTag("LevelLoader").transform.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.x <= -1273.6) 
        {
            GameObject[] arr = GameObject.FindGameObjectsWithTag("chest");
            GameObject.FindGameObjectWithTag("scoreCount").GetComponent<ScoreKeep>().ADDmoni();
            for (int i = 0; i < arr.Length; i++) 
            {
                Destroy(arr[i]);
            }
            print(gameObject.tag);
            if (alive) 
            {
                AS.Play();
                gameObject.transform.position = og;
                scrLoader = (LevelLoader)GameObject.FindGameObjectWithTag("LevelLoader").transform.GetComponent<LevelLoader>();
                scrLoader.startStore();
            }
                
        }
    }
    public void Move() 
    {
        GameObject.FindGameObjectWithTag("cloud1").GetComponent<WaterMovemet>().change(false);
        GameObject.FindGameObjectWithTag("cloud2").GetComponent<WaterMovemet>().change(false);
        GameObject.FindGameObjectWithTag("cloud1").GetComponent<MoveCloud>().Move(i*100);
        GameObject.FindGameObjectWithTag("cloud2").GetComponent<MoveCloud>().Move(-i*100);
        GameObject[] arr = GameObject.FindGameObjectsWithTag("rain");
        for (int i = 0; i < arr.Length; i++) 
        {
            print("found 1");
            arr[i].GetComponent<ParticleSystem>().Stop(true);
        }
        Color a = GameObject.FindGameObjectWithTag("background").GetComponent<SpriteRenderer>().color;
        a.a = 1;
        GameObject.FindGameObjectWithTag("background").GetComponent<SpriteRenderer>().color = a;
        rb2d.AddForce(new Vector2(i,0),ForceMode2D.Impulse);
    }
    public void playerDed() 
    {
        alive = false;
    }

}
