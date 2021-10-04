using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    public void MENU() 
    {
        GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().startMenu();
    }
}
