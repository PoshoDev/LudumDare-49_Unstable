using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightCheck : MonoBehaviour {
	public bool check = false;
	private bool touch_boat = false;
	private GameObject boat;
	private BoatSway_2 scr;
	
    // Start is called before the first frame update
    void Start() {
        boat = GameObject.FindGameObjectWithTag("Boat");
		scr = (BoatSway_2)boat.GetComponent(typeof(BoatSway_2));
    }
	
    // Update is called once per frame
    void Update() {
        if (check) {
			float dir = transform.position.x - boat.transform.position.x;
			scr.Count(dir);
		}
    }
	
	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.CompareTag("Boat")) {
			touch_boat = true;
			check = true;
		}
		else {
			WeightCheck other = (WeightCheck)collision.transform.GetComponent(typeof(WeightCheck));
			if (other.check) check = true;
		}
	}
	
	private void OnCollisionExit2D(Collision2D collision) {
		if (collision.transform.CompareTag("Boat"))
			check = false;
	}
}
