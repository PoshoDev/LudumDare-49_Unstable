using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameDir : MonoBehaviour
{
    public float seconds = 1;
    private int moneyCount;
    private TMP_Text Text;
    private TMP_Text Text1;
    private SpawnGoon scr1;
    private int i;
    private int remainingTime = 100;
    private int og;
    private bool canStart=false;
    private int speedCrates;
    private GameObject island;
    private int currChestcount;
    public int chestCount;
    public GameObject chest;
    private GameObject boat;
    public float boxHeight;
    private GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Boat");
        game = GameObject.FindGameObjectWithTag("game");
        currChestcount = chestCount;
        /*
        GameObject[] arr = GameObject.FindGameObjectsWithTag("enemy1");
        for (int a = 0; a < arr.Length; a++) 
        {
            Destroy(arr[a]);
        }*/
        Text = GameObject.FindGameObjectWithTag("debugger").GetComponent<TMP_Text>();
        Text1 = GameObject.FindGameObjectWithTag("debugger1").GetComponent<TMP_Text>();
        scr1 = (SpawnGoon)GameObject.FindGameObjectWithTag("EnemySpawner1").transform.GetComponent<SpawnGoon>();
        island = GameObject.FindGameObjectWithTag("island");
        canStart = true;
        remainingTime = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().currentDur;
        StartCoroutine(timeToIsland());
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Current Moneies: "+ GameObject.FindGameObjectWithTag("scoreCount").GetComponent<ScoreKeep>().GetMoniCount();
        Text1.text = "Meters to Island: "+ remainingTime;
    }
    private IEnumerator Waves() 
    {
        yield return new WaitForSeconds(seconds);
        while (remainingTime > 0) 
        {
                scr1.Makeenemies();
                yield return new WaitForSeconds(seconds);
        }
    }
    private IEnumerator timeToIsland() 
    {
        //
        og = remainingTime;
        while (remainingTime>0) 
        {
            
            yield return new WaitForSeconds((1.0f/(speedCrates+1)));
            setRemainingtime();
            //print("tiempo a isla: "+(remainingTime));
        }
        island.GetComponent<islandMove>().Move();
        i = 0;
    }
    //agrega dinero al jugador
    public void changeMoney(int ammount) 
    {
        moneyCount += ammount;
    }
    private void OnEnable()
    {
        if (canStart) 
        {
            StartCoroutine(timeToIsland());
            StartCoroutine(Waves());
        }
    }
    private void Awake()
    {
        remainingTime = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().currentDur;
        speedCrates = 0;
        currChestcount = chestCount;
        if (seconds > 1) 
        {
            seconds--;
        }
    }
    public void setRemainingtime() 
    {
        remainingTime = remainingTime - 1 ;
        if (currChestcount != 0)
            if (Random.Range(0,100)<5 &&currChestcount>0)
            {
                currChestcount--;
                gameObject.GetComponent<AudioSource>().Play();
                GameObject a = Instantiate(chest);
                a.transform.parent = boat.transform;
                a.transform.position = new Vector3(boat.transform.position.x, boat.transform.position.y + boxHeight, boat.transform.position.z);

            }
    }
    public void addCrate() 
    {
        speedCrates++;
        print("speed crates+ "+speedCrates);
    }
    public void loseCrate() 
    {
        //print("sub");
        speedCrates--;
        print("speed crates- " + speedCrates);
    }
    public void setTime(int i) 
    {
        remainingTime = i;
        GameObject.FindGameObjectWithTag("disabler").GetComponent<DisableCHildren>().disabled.SetActive(false); 
    }

}

