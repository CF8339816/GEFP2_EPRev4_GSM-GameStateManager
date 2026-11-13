using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.SceneManagement;

public static class PerformBootstrap
{
    const string SceneName = "_BootStrap_";


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void ExecuteBootstrap66()
    { 
    for (int sceneIndex = 0; sceneIndex<SceneManager.sceneCount; ++sceneIndex)// checks through loaded scenes for the bootstrap scene
        {
            var candidate = SceneManager.GetSceneAt(sceneIndex);

            if (candidate.name == SceneName)// checks if scene already loaded an stops process
            {
                return;
            }


            Debug.Log("Loading Bootstrp scene"+SceneName);

        }

         SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);  // loads bootstrap adatively


    }


}



public class _BS1_ : MonoBehaviour
{

    public static _BS1_ Instance { get; private set; } = null;
     void Awake()
    {


        if (Instance != null && Instance != this)// checks for multiples
        {
            Debug.Log("Bootstrap found on " + gameObject.name);
            
            Destroy(gameObject); //destroy whole object
            return;
        }

        Debug.Log("Bootstrapinitalized");
        Instance = this;

        DontDestroyOnLoad(gameObject); // prevents  boostrapper from being destroyed on multiscene load
    }

    public void TestBS()
    {
        Debug.Log("Bootstrap Functioning correctly" + gameObject.name);

    }

}
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

