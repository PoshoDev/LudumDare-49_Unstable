using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().loadGameStart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().loadGameStart();
        }
    }
}
