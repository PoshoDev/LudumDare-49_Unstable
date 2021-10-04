using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOWN : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3(0,0,360);
    }
}
