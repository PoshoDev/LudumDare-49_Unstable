using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BoatSway : MonoBehaviour
{
    public float speed;
    private float width = 1;
    private Rigidbody2D rb2d;
    public float maxDisbalance;
    private float previous = 0, balance = 0;
    public float boatRes;
    private TMP_Text debug, debug1;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        width = transform.localScale.x / 2*1.0f;
        //print ("print my width: "+ width);
    }

    // Update is called once per frame
    void Update()
    {
        debug = GameObject.FindGameObjectWithTag("debugger").GetComponent<TMP_Text>();
        debug1 = GameObject.FindGameObjectWithTag("debugger1").GetComponent<TMP_Text>();
        //print("max disbalance" + (maxDisbalance / 4)+"and balance is: "+balance);
        //print("rotation:" + transform.rotation.z);
        if (balance > 0)
        {
            //print("chuck e cheese");

            if (maxDisbalance/6 < balance && balance < maxDisbalance / 4)
            {

                if (transform.rotation.z < .05f)
                {
                    debug.text = "a with: "+transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > .05f)
                {
                    debug.text = "b with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
            if (balance > maxDisbalance / 4)
            {

                if (transform.rotation.z < .10f)
                {
                    debug.text = "c with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > .10f)
                {
                    debug.text = "d with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }

            }
            else if (balance > maxDisbalance / 2)
            {

                if (transform.rotation.z < .15f)
                {
                    debug.text = "e with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > .15f)
                {
                    debug.text = "f with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
            else if (balance > maxDisbalance - maxDisbalance / 4)
            {
                if (transform.rotation.z < .30f)
                {
                    debug.text = "g with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > .30f)
                {
                    debug.text = "h with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
            else if (balance >= maxDisbalance)
            {
                if (transform.rotation.z < .90f)
                {
                    debug.text = "i with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > .90f)
                {
                    debug.text = "j with: " + transform.rotation.z;

                    transform.Rotate(0, 0, -speed);
                }

            }
        }
        else if (balance < 0)
        {
            //print("poggers");
            //print("balance " + balance + " and max disbalance" + maxDisbalance);
            if (balance > -maxDisbalance / 4)
            {
                if (transform.rotation.z < -.05f)
                {
                    debug.text = "k with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > -.05f)
                {
                    debug.text = "L with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
            if (balance < -maxDisbalance / 4)
            {
                if (transform.rotation.z < -.10f)
                {
                    debug.text = "m with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > -.10f)
                {
                    debug.text = "n with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
            else if (balance < -maxDisbalance / 2)
            {
                if (transform.rotation.z < -.15f)
                {
                    debug.text = "o with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > -.15f)
                {
                    debug.text = "p with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
            else if (balance < -maxDisbalance - maxDisbalance / 4)
            {
                if (transform.rotation.z < -.30f)
                {
                    debug.text = "q with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > -.30f)
                {
                    debug.text = "r with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
            else if (balance <= -maxDisbalance)
            {
                if (transform.rotation.z < .90f)
                {
                    debug.text = "s with: " + transform.rotation.z;
                    transform.Rotate(0, 0, speed);
                }
                else if (transform.rotation.z > .90f)
                {
                    debug.text = "t with: " + transform.rotation.z;
                    transform.Rotate(0, 0, -speed);
                }
            }
        }
        else if (transform.rotation.z < 0)
        {
            debug.text = "u with: " + transform.rotation.z;
            transform.Rotate(0, 0, speed);
        }
        else if(transform.rotation.z>0)
        {
            debug.text = "v with: " + transform.rotation.z;
            transform.Rotate(0, 0, -speed);
        }
        //print("the rotation value is: " + transform.rotation.z);
    }
    public void ChangeBalance(float a) 
    {
       balance += a;
       debug1.text= ("i gave an: " + (a/boatRes)+" and i got a :"+balance);
    }
    public float getWidth() 
    {
        return width;
    }   
}
