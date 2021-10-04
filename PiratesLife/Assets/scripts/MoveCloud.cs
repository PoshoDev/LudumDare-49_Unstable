using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private Vector3 a;
    private Vector3 b;
    // Start is called before the first frame update
    void Start()
    {
        a = transform.position;
        b = transform.eulerAngles;
        //rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        transform.position = a;
        transform.eulerAngles = b;
    }
    public void Move(float i)
    {
        rb2d.AddForce(new Vector2(i, Mathf.Abs(i/8.0f)));
        rb2d.AddTorque(-i*90);
    }
}
