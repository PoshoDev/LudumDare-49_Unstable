using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dontDestroyme : MonoBehaviour
{
    private GameObject boat;
    private GameObject player;
    private bool ran = false;
    private GameObject disabler;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        print("town conf: " + (SceneManager.GetActiveScene().name));       
    }
    // Update is called once per frame
    void Update()
    {
        ran = true;
        if (SceneManager.GetActiveScene().name == "menu")
        {
            Destroy(this.gameObject);
        }else
        if (SceneManager.GetActiveScene().name == "GameLoop"|| SceneManager.GetActiveScene().name == "Game")
        {
            //disabler.SetActive(true);
        }
    }
    void Awake()
    {
        boat = GameObject.FindGameObjectWithTag("Boat");
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("hugger");
        if (objs.Length > 1)
        {
            for (int i = 0; i<objs.Length; i++) 
            {
                if (!objs[i].GetComponent<dontDestroyme>().ran) 
                {
                    Destroy(objs[i].gameObject);
                }
            }
            
        }
    }
}
