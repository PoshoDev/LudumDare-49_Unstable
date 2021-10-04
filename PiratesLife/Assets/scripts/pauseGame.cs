using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    private GameObject game;
    private GameObject pMenu;
    private GameObject dMenu;
    private bool playerDed = false;
    private bool check = true;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("game");
        dMenu = GameObject.FindGameObjectWithTag("diedMenu");
        pMenu = GameObject.FindGameObjectWithTag("pauseMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            check = !check;
        }
        if (!check||playerDed) 
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().startMenu();
            }
        }
        if (!playerDed) 
        {
            game.SetActive(check);
            pMenu.SetActive(!check);
            dMenu.SetActive(false);
        }
        if (playerDed) 
        {
            GameObject.FindGameObjectWithTag("island").GetComponent<islandMove>().playerDed();
            GameObject.FindGameObjectWithTag("musicMan").GetComponent<GameplayMusic>().playerDED();
            pMenu.SetActive(false);
            dMenu.SetActive(playerDed);
        }
        
    }
    public void playerDied() 
    {
        playerDed = true;
    }

}
