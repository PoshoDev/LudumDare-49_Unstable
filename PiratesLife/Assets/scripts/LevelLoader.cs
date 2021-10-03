using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Animator transitionM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadGameStart() 
    {
            StartCoroutine(LoadGame());        
    }
    public void loadMenu(int i)
    {
            StartCoroutine(LoadMenu(i));
    }
    IEnumerator LoadGame() 
    {
        //Play Animation
        transitionM.SetTrigger("Start");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //Wait
        EditorSceneManager.LoadScene(1);
    }
    IEnumerator LoadMenu(int i)
    {
        //Play Animation
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //Wait
        EditorSceneManager.LoadScene(i);
    }


}
