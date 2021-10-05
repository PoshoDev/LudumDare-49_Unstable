using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Animator transitionM;
    public int currentDur;
    public int time2Add;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag("GameDir").GetComponent<GameDir>().setTime(currentDur);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadGameStart()
    {
        StartCoroutine(LoadGame(1));
    }
    public void loadGameLoop()
    {

        
        StartCoroutine(LoadLoopGame());
    }
    public void startMenu()
    {
        StartCoroutine(LoadMenu());
    }
    public void startStore() 
    {
        //GameObject.FindGameObjectWithTag("disabler").GetComponent<DisableCHildren>().disabled.SetActive(false);
        StartCoroutine(LoadStore());
    }
    IEnumerator LoadGame(int i) 
    {
        //Play Animation
        transitionM.SetTrigger("Start");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //Wait
        SceneManager.LoadScene(i);
        
    }
    IEnumerator LoadLoopGame()
    {
        //Play Animation
        transitionM.SetTrigger("Start");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        GameObject.FindGameObjectWithTag("disabler").GetComponent<DisableCHildren>().disabled.SetActive(true);
        Color a = GameObject.FindGameObjectWithTag("background").GetComponent<SpriteRenderer>().color;
        a.a = 0;
        GameObject.FindGameObjectWithTag("background").GetComponent<SpriteRenderer>().color = a;
        GameObject.FindGameObjectWithTag("cloud1").GetComponent<WaterMovemet>().change(true);
        GameObject.FindGameObjectWithTag("cloud2").GetComponent<WaterMovemet>().change(true);
        //Wait
        SceneManager.LoadScene(3);

    }
    IEnumerator LoadMenu()
    {
        //Play Animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //Wait
        SceneManager.LoadScene(0);
    }
    IEnumerator LoadStore() 
    {
        //Play Animation
        currentDur += time2Add;
        GameObject.FindGameObjectWithTag("Boat").transform.eulerAngles = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("Player").transform.localPosition = new Vector3(-1273.357f, -218.241f, 767.3306f);
        GameObject.FindGameObjectWithTag("Player").transform.eulerAngles = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("GameDir").GetComponent<GameDir>().setTime(currentDur);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //Wait
        SceneManager.LoadScene(2);
        //GameObject.FindGameObjectWithTag("disabler").SetActive(false);
    }


}
