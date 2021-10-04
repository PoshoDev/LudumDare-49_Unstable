using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class BoatSway_2 : MonoBehaviour {
	public float count_left =  	0f;
	public float count_right = 	0f;
	public float ang_inc = 		0.01f;
	private float ang_spd =  	0f;
	private float ang = 		0f;
	public float ang_spd_max = 	0.01f;
	public float dir_div = 10f;

	// Start is called before the first frame update
    // Update is called once per frame
    void Update() {
		ang = transform.rotation.z;
        ang_spd += (count_left - count_right) * ang_inc;
		
		if (ang > 0f) 	  ang_spd -= ang_inc;
		else if (ang < 0) ang_spd += ang_inc;
		
		if (ang_spd < -ang_spd_max) 	ang_spd = -ang_spd_max;
		else if (ang_spd > ang_spd_max) ang_spd = ang_spd_max;
		
		gameObject.transform.Rotate(0, 0, ang_spd);
		
		count_left =  0;
		count_right = 0;
    }
	
	public void Count(float dir) {
		dir /= dir_div;
		//print(dir);
		if (dir < 0) count_left -= dir;
		else if (dir > 0) count_right += dir;
	}
	
}
