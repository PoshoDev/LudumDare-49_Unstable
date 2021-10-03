using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDir : MonoBehaviour
{
    public int roundsToIsland;
    public float seconds = 1;
    public int maxEnemies;
    private LevelLoader scrLoader;
    private SpawnGoon scr1;
    // Start is called before the first frame update
    void Start()
    {
        scr1 = (SpawnGoon)GameObject.FindGameObjectWithTag("EnemySpawner1").transform.GetComponent<SpawnGoon>();
        scrLoader = (LevelLoader)GameObject.FindGameObjectWithTag("LevelLoader").transform.GetComponent<LevelLoader>();
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Waves() 
    {
        while (true) 
        {
            int enemies = Mathf.RoundToInt(Random.Range(maxEnemies - (maxEnemies / 4), maxEnemies));
            for (int i = 0; i < enemies; i++) 
            {
                scr1.Makeenemies();
                yield return new WaitForSeconds(seconds);
                
            }
            roundsToIsland--;
            if (roundsToIsland == 0) 
            {
                scrLoader.loadMenu(0);
            }
            
           
        }
        
        print("a");
    }
}

