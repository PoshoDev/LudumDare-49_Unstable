using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public int moni;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("scoreCount").GetComponent<ScoreKeep>().ChangeMoni(moni);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void removeMoni() 
    {
        GameObject.FindGameObjectWithTag("scoreCount").GetComponent<ScoreKeep>().ChangeMoni(-moni);
    }
}
