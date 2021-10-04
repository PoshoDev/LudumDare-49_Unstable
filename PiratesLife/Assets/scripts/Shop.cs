using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
	public int box1;
	public int box2;
	public int box3;
    public Sprite boxS1;
    public Sprite boxS2;
    public Sprite boxS3;
    private ScoreKeep sS;
    private int index=1;
    private TMP_Text text;
    // Start is called before the first frame update
    private void Start()
    {
        sS = (ScoreKeep)GameObject.FindGameObjectWithTag("scoreCount").GetComponent<ScoreKeep>();
        text = GameObject.FindGameObjectWithTag("debugger1").GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().loadGameLoop();
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            if (index == 3)
            {
                index = 1;
            }
            else index++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index == 1)
            {
                index = 3;
            }
            else index--;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (index == 1)
            {
                if (box1 <= sS.getAllMoni()) 
                {
                    buy(1);

                }
            }
            else if (index == 2)
            {
                if (box2 <= sS.getAllMoni())
                {
                    buy(2);

                }
            }
            else if (index == 3) 
            {
                if (box3 <= sS.getAllMoni())
                {
                    buy(3);

                }
            }
        }
        switch (index) 
        {
            case 1:
                text.text = ""+box1;
                gameObject.GetComponent<SpriteRenderer>().sprite = boxS1;
                break;
            case 2:
                text.text = "" + box2;
                gameObject.GetComponent<SpriteRenderer>().sprite = boxS2;
                break;
            case 3:
                text.text = "" + box3;
                gameObject.GetComponent<SpriteRenderer>().sprite = boxS3;
                break;
        }
    }
    public void buy(int i) 
    {
        GameObject.FindGameObjectWithTag("shopKeep").GetComponent<Animator>().SetTrigger("Bought");
        gameObject.GetComponent<AudioSource>().Play();
        sS.addBox(i);
        if (i == 1)
        sS.looseMoni(box1);
        if (i == 2)
        sS.looseMoni(box2);
        if (i==3)
        sS.looseMoni(box3);
    }
}
