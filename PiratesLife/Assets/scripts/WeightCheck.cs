using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightCheck : MonoBehaviour {
	public bool check = false;
	private bool touch_boat = false;
	private GameObject boat;
	private BoatSway_2 scr;
	private Vector3 vel;
	private float aVel;
	private Rigidbody2D rb2d;
	private bool Wdisabled = false;
	
    // Start is called before the first frame update
    void Start() {
        boat = GameObject.FindGameObjectWithTag("Boat");
		scr = (BoatSway_2)boat.GetComponent(typeof(BoatSway_2));
		rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void Update() {
		if (Wdisabled) 
		{
			rb2d.velocity = vel;
			rb2d.angularVelocity = aVel;
			Wdisabled = false;
		}
        if (check) {
			float dir = transform.position.x - boat.transform.position.x;
			scr.Count(dir);
		}
		if (gameObject.transform.position.y < -10) 
		{
			if (!gameObject.transform.CompareTag("Player"))
			{
				if (gameObject.transform.CompareTag("speed_crate"))
				{
					GameObject.FindGameObjectWithTag("GameDir").GetComponent<GameDir>().loseCrate();
				}
				if (gameObject.transform.CompareTag("chest")) 
				{
					gameObject.GetComponent<chest>().removeMoni();
				}
				check = false;
				Destroy(gameObject);
			}
			else
			{
				GameObject.FindGameObjectWithTag("pController").GetComponent<pauseGame>().playerDied();
			}
		}
		aVel = rb2d.angularVelocity;
		vel = rb2d.velocity;
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
    private void OnDisable()
    {
		Wdisabled = true;
    }
}
