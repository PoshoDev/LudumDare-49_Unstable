using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    public AudioClip clank;
    public AudioClip splash;
    private AudioSource boi;
    // Start is called before the first frame update
    void Start()
    {
        boi = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("enemy2"))
        {
            boi.clip = clank;
        }
        else
        {
            boi.clip = splash;
        }
        boi.Play();
    }
}
