using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedCrate : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("GameDir").GetComponent<GameDir>().addCrate();
    }
   /* void Awake()
    {
        GameObject.FindGameObjectWithTag("GameDir").GetComponent<GameDir>().addCrate();
        
    }*/
}
