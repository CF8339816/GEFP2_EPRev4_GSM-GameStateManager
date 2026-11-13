using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    [Header("System References")]// defines other scripts
    public Custom_sceneManager customSceneManager { get; private set; }= null;
public HudManager hudManager { get; private set; } = null;
    public MenuManager menuManager { get; private set; } = null;
    public ShopManager shopManager { get; private set; } = null;
    public PauseManager pauseManager { get; private set; } = null;
    public GameManager gameManager { get; private set; } = null;
    public GameExitManager gameExitManager { get; private set; } = null;
    public ServiceHub serviceHub { get; private set; } = null;
    public GameObject cameraPrefab { get; private set; } = null;
    public GameObject eventSystemPrefab { get; private set; } = null;

    public static _BS1_ Instance { get; private set; } = null;
     void Awake()
    {


        if (Instance != null && Instance != this)// checks for multiples
        {
            Debug.Log("Bootstrap found on " + gameObject.name);
            
            Destroy(gameObject); //destroy whole object
            return;
        }

        Debug.Log("Bootstrap Initalized!!!");
        Instance = this;

        DontDestroyOnLoad(gameObject); // prevents  boostrapper from being destroyed on multiscene load
        Debug.Log("Initalize Event System.");
        ServiceHub.Instance.InitializeGlobalEventSystem();
        Debug.Log("EventSystem Initalized!!!!!");
        Debug.Log("Initalizing camera system");
        ServiceHub.Instance.InitializeGlobalCameraSystem();
        Debug.Log("Cameras initalized Initalized!!!");

        if (serviceHub == null) serviceHub = GetComponent<ServiceHub>();
        if (customSceneManager == null) customSceneManager = GetComponent<Custom_sceneManager>();
        if (gameManager == null) gameManager = GetComponent<GameManager>();
        if (gameExitManager == null) gameExitManager = GetComponent<GameExitManager>();
        if (hudManager == null) hudManager = GetComponent<HudManager>();
        if (menuManager == null) menuManager = GetComponent<MenuManager>();
        if (pauseManager == null) pauseManager = GetComponent<PauseManager>();




 }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentLevelOutput();
    }


    public void UpdateCurrentLevelOutput()
    {
        if (menuManager.textCurrentLevel != null)
        {
            string CurrentScene = SceneManager.GetActiveScene().name;
            menuManager.textCurrentLevel.text = "Current Level Loaded: " + CurrentScene;
        }
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
