using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    private AudioSource manager;
    private AudioSource ownManager;
    private bool loopisplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        ownManager = transform.GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("loop").transform.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ownManager.time >=ownManager.clip.length-0.1f && !loopisplaying)
        {
            manager.mute = false;
            manager.Play();
            loopisplaying = true;
        }
    }
}
