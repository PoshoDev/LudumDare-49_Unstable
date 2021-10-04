using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
	public float danger_angle;
	public float cd;
	public GameObject arm1;
	public GameObject arm2;
	private GameObject eyes_1;
	private GameObject eyes_2;
	private bool cdD = true;
	private GameObject boat;
	public GameObject Box1;
	public GameObject Box2;
	public GameObject Box3;
	public float boxHeight;
	private Animator anim;
	private ScoreKeep sS;
    // Start is called before the first frame update
    void Start()
    {
		sS = (ScoreKeep)GameObject.FindGameObjectWithTag("scoreCount").GetComponent<ScoreKeep>();
		boat = GameObject.FindGameObjectWithTag("Boat");
        rb2d = GetComponent<Rigidbody2D>();
		eyes_1 = GameObject.FindGameObjectWithTag("eyes_1");
		eyes_2 = GameObject.FindGameObjectWithTag("eyes_2");
		anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float inp = Input.GetAxis("Horizontal");
        rb2d.AddForce(new Vector2(inp * speed, 0));
		
		//print(inp);
		bool move;
		if (inp == 0) move = false;
		else move = true;
		anim.SetBool("moving", move);
		
		//print(Mathf.Abs(transform.rotation.z));
		bool danger = false;
		if (Mathf.Abs(transform.rotation.z) > Mathf.Abs(danger_angle))
			danger = true;
		
		eyes_1.SetActive(!danger);
		eyes_2.SetActive(danger);
		if (cdD)
		{
			arm2.SetActive(false);
			arm1.SetActive(true);
		}
		else 
		{
			arm2.SetActive(true);
			arm1.SetActive(false);
			
		}

		}
    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (cdD)
			{
				if (sS.CheckBox(1)) 
				{
					sS.removeBox(1);
					playerMakeBox(Box1);
				}
					
				//print("me");

			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if (cdD)
			{
				if (sS.CheckBox(2))
				{
					sS.removeBox(2);
					playerMakeBox(Box2);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (cdD)
			{
				if (sS.CheckBox(3))
				{
					sS.removeBox(3);
					playerMakeBox(Box3);
				}
			}
		}
	}
    public void playerMakeBox(GameObject box) 
	{
		StartCoroutine(CoolDown(box));
	}
	private IEnumerator CoolDown(GameObject box) 
	{
		print("me too");
		cdD = false;
		SpawnBox(box);
		yield return new WaitForSeconds(cd);
		cdD = true;
	}
    private void OnEnable()
    {
		if (!cdD) 
		{
			StartCoroutine(gotU());
		}
    }
	private IEnumerator gotU() 
	{
		yield return new WaitForSeconds(cd);
		cdD = true;
	}
	public void SpawnBox(GameObject box) 
	{
		//print("also me"); 
		GameObject a = Instantiate(box);
		a.transform.parent = boat.transform;
		a.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +boxHeight , gameObject.transform.position.z);
	}
}
