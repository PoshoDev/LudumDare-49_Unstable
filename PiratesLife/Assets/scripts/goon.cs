using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goon : MonoBehaviour
{
    private bool check = false;
    public float speed;
    private float movement;
    private Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (check) 
        {
            rb2d.AddForce(new Vector2( 1* movement, 0));
        }
    }
    public void setUp() 
    {
        int number = Random.Range(0, 10);
        if (number <= 5)
        {
            movement = -speed;
        }
        else 
        {
            movement = speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("enemy1")&&!collision.transform.CompareTag("enemy2")) 
        {
            print("touched a " + collision.transform.tag);
            anim.SetBool("touch",true);
            //print("gottem");
            check = true;
            setUp();
        }
        
    }
}
