using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSway : MonoBehaviour
{
    public float boatResistance;
    private float boatleft;
    private float boatright;
    private float height;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        height = transform.lossyScale.x/2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        print("entre");
        if (collision.transform.position.y >= transform.position.y) 
        {
            print("entre2");
            if (collision.transform.position.x >= transform.position.x)
            {
                print((collision.transform.position.x - transform.position.x)*collision.rigidbody.mass/9);
            }
            else 
            {
                print((transform.position.x - collision.transform.position.x) * collision.rigidbody.mass / 9);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
