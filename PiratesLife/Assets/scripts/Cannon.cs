using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float rotSpeed;
    public float goal;
    public float cd;
    public GameObject bullet;
    private GameObject goalObj=null;
    private Transform cannon;
    private Transform gear;
    private bool Shot = true;
    // Start is called before the first frame update
    void Start()
    {
        cannon = transform.Find("cannon");
        gear = transform.Find("gear");
    }

    // Update is called once per frame
    void Update()
    {
        if (goalObj != null) 
        {
            Vector3 aimDirection = (goalObj.transform.position - transform.position).normalized;
            goal = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
            //print("new angle is "+goal+" and the game object position is: "+ goalObj.transform.position.x+ "and mine is :"+transform.position.x);
            cannon.transform.eulerAngles = new Vector3(0, 0, goal);
            gear.transform.eulerAngles = new Vector3(0, 0, -goal*2);
        }
        if (Shot) 
        {
            StartCoroutine(Shoot());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.tag);
        if (collision.CompareTag("enemy1")|| collision.CompareTag("enemy2")) 
        {
            if (goalObj == null) 
            {
                goalObj = collision.gameObject;
            }
            else
            if (Mathf.Abs(collision.transform.position.x - transform.position.x) < goalObj.transform.position.x || Mathf.Abs(-collision.transform.position.x + transform.position.x) < goalObj.transform.position.x) 
            {
                if (Mathf.Abs(collision.transform.position.y - transform.position.y) < goalObj.transform.position.y || Mathf.Abs(-collision.transform.position.y + transform.position.y) < goalObj.transform.position.y) 
                {
                    goalObj = collision.gameObject;
                }
            }
        }
    }
    IEnumerator Shoot() 
    {
        print("noo");
        if (goalObj != null)
        {
            Shot = false;
            GameObject a = Instantiate(bullet);
            a.transform.parent = transform;
            a.transform.position = transform.position;
            Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
            rb.AddForce((goalObj.transform.position - transform.position).normalized*1000);
            yield return new WaitForSeconds(cd);
            Shot = true;
        }
    }
}
