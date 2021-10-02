using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class weightwatcher : MonoBehaviour
{
    public float weight;
    private GameObject boat;
    private Rigidbody2D rb2d;
    private float pdata=0, ndata = 0;
    private BoatSway bsway;
    private float width;
    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boat = GameObject.FindGameObjectWithTag("Boat");
        bsway = (BoatSway)boat.GetComponent(typeof(BoatSway));
        width = bsway.getWidth();
    }

    // Update is called once per frame
    void Update()
    {
        if (check) 
        {
                //print("we gottem");
                if (transform.position.x > boat.transform.position.x)
                {
                //print(transform.position.x + "and " + boat.transform.position.x);
                    //print("poggers");
                    ndata = (transform.position.x - boat.transform.position.x);
                    if (ndata - pdata > 2|| pdata ==0)
                    {
                    bsway.ChangeBalance(-((ndata - pdata)/(width*10.0f)));
                    //print("a: "+((-((ndata - pdata) / (width * 10.0f)) )));
                        pdata = ndata;
                    }
                    if (ndata - pdata < -2 || pdata == 0)
                    {
                    //print("b: " + (-(((ndata - pdata) / (width* 10.0f)))));
                    bsway.ChangeBalance(- ((ndata - pdata)/ (width * 10.0f)) );
                        pdata = ndata;
                    }
                }
                else if (transform.position.x < boat.transform.position.x)
                {
                    //print("chuck e cheese");
                    ndata = -(boat.transform.position.x - transform.position.x);
                    //print(" c ndata: " + ndata + "pdata: " + pdata);
                    if (ndata - pdata > 2 || pdata == 0)
                    {
                        //print("c: " + (( -((ndata - pdata) / (width * 10.0f)))));
                        bsway.ChangeBalance(-((ndata - pdata) / (width * 10.0f)));
                        pdata = ndata;
                    }
                    if (ndata-pdata < -2 || pdata == 0)
                    {
                        //print("d: " + ((-((ndata - pdata) / (width * 10.0f)))));
                        bsway.ChangeBalance((-(ndata-pdata) / (width * 10.0f)));
                        pdata = ndata;
                    }
                }
           
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("we good");

        if (rb2d.velocity.y >= 0)
        {
            if (collision.transform.CompareTag("Boat"))
            {
                check = true;
            }
            else if (collision.transform.position.y > transform.position.y + transform.localScale.y / 2) 
            {
                check = true;
            }
           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (check) 
        {
            if (collision.transform.CompareTag("Boat"))
            {
                check = false;
                removeData();
            }
            else if (collision.transform.position.y > transform.position.y + transform.localScale.y / 2) 
            {
                check = false;
                removeData();
            }
            //print("outtie i will take: "+ (((pdata) / (width * 10.0f))));
        }
        //print("we out");
        
    }
    public void removeData()
    {
        bsway.ChangeBalance(((pdata) / (width * 10.0f)));
    }

}
