using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject sLeft;
    public GameObject sRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Makeenemies() 
    {
        print("called");
        int number = (Random.Range(0,10));
        GameObject a = Instantiate(enemy);
        float pos = Random.Range(100, 300);
        float torque = Random.Range(0, 50);
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
