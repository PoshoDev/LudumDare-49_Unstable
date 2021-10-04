using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6;
    public GameObject sLeft;
    public GameObject sRight;
    private GameObject game;
    private GameObject a;
    public int probR;
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Makeenemies() 
    {
       
        //print("called");
        int rand = (Random.Range(0, 100));
        if (rand <= probR)
        {
            a = Instantiate(enemy);
        }
        else 
        {
            rand = Mathf.RoundToInt(Random.Range(0, 7));
            switch (rand) 
            {
                case 0:
                case 1:
                    a = Instantiate(enemy1);
                    break;
                case 2:
                    a = Instantiate(enemy2);
                    break;
                case 3:
                    a = Instantiate(enemy3);
                    break;
                case 4:
                    a = Instantiate(enemy4);
                    break;
                case 5:
                    a = Instantiate(enemy5);
                    break;
                case 6:
                case 7:
                    a = Instantiate(enemy6);
                    break;
            }
        }
        int number = (Random.Range(0,10));
        a.transform.parent = game.transform;
        float pos = Random.Range(100, 300);
        float torque = Random.Range(90, 180);
        Rigidbody2D rb2d = a.GetComponent<Rigidbody2D>();
        if (number <=5)
        {
            a.transform.position = sLeft.transform.position;
            rb2d.AddForce(new Vector2(pos, 1000));
            rb2d.AddTorque(torque);
        }
        else 
        {
            a.transform.position = sRight.transform.position;
            rb2d.AddForce(new Vector2(-pos, 1000));
            rb2d.AddTorque(torque);
        }
    }
}
