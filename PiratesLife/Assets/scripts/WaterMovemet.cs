using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovemet : MonoBehaviour {
	private float st_x;
	private float st_y;
	public float mod;
	public float inc;
	private float tot;
	public bool check=true;
	
    // Start is called before the first frame update
    void Start() {
        tot = 0.0f;
		st_x = transform.position.x;
		st_y = transform.position.y;
    }

    // Update is called once per frame
    void Update() {
		if (check) 
		{
			tot += inc;
			float new_x = st_x - Mathf.Sin(tot) * mod;
			float new_y = st_y + Mathf.Cos(tot) * mod;
			gameObject.transform.position = new Vector3(new_x, new_y, 0);
		}
		
    }
	public void change(bool a) 
	{
		check = a;
	}
}
