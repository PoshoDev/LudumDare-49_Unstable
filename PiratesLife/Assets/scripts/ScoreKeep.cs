using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
public class ScoreKeep : MonoBehaviour
{
    
    private int moneyCount = 0;
    private int moneyTotal= 0;
    private int trip = 100;
    private int box1 = 1;
    private int box2 = 1;
    private int box3 = 1;  
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
    }
    void Update() 
    {
        if (SceneManager.GetActiveScene().name == ("menu")) 
        {
            box1 = 1;
            box2 = 1;
            box3 = 1;
            moneyCount = 0;
            trip = 100;
        }
        if (SceneManager.GetActiveScene().name == ("Store")) 
        {
            trip+= 50;
            GameObject.FindGameObjectWithTag("debugger").GetComponent<TMP_Text>().text = "CurrentMoney = " + moneyTotal;
        }
        if ((SceneManager.GetActiveScene().name == ("GameLoop")) || (SceneManager.GetActiveScene().name == ("Game")))
        {
            GameObject.FindGameObjectWithTag("currentBoxes").GetComponent<TMP_Text>().text = "" + box1;
            GameObject.FindGameObjectWithTag("currentBoxes1").GetComponent<TMP_Text>().text = "" + box2;
            GameObject.FindGameObjectWithTag("CurrentBoxes2").GetComponent<TMP_Text>().text = "" + box3;
        }
    }
    public int getAllMoni() 
    {
        return moneyTotal;
    }
    public void looseMoni(int i) 
    {
        moneyTotal -= i;
    }
    public int GetMoniCount() 
    {
        return moneyCount;
    }
    public int GetTripCount()
    {
        return trip;
    }
    public void ChangeMoni(int i) 
    {
        moneyCount += i;
    }
    public void ADDmoni() 
    {
        print("i adde da moni"+moneyCount);
        moneyTotal += moneyCount;
        moneyCount = 0;
    }
    void Awake() 
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("scoreCount");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
    public void removeBox(int i) 
    {
        switch (i) 
        {
            case 1:
                box1--;
                break;
            case 2:
                box2--;
                break;
            case 3:
                box3--;
                break;

        }
    }
    public bool CheckBox(int i)
    {
        switch (i)
        {
            case 1:
                if (box1 > 0) 
                {
                    return true;
                }
                break;
            case 2:
                if (box2 > 0)
                {
                    return true;
                }
                break;
            case 3:
                if (box3 > 0)
                {
                    return true;
                }
                break;
        }
        return false;
    }
    public void addBox(int i) 
    {
        switch (i)
        {
            case 1:
                box1++;
                break;
            case 2:
                box2++;
                break;
            case 3:
                box3++;
                break;

        }
    }
}
