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

    public HudManager hudManager;
    public MenuManager menuManager;
    public ShopManager shopManager;
    public PauseManager pauseManager;

    public GameExitManager gameExitManager;

    public GameObject cameraPrefab;
    public GameObject eventSystemPrefab;

    private const int MAIN_INDEX = 0;
    private const int LEVEL_1_INDEX = 1;
    private const int LEVEL_2_INDEX = 2;
    private const int LEVEL_3_INDEX = 3;
    private const int MENU_INDEX = 4;
    private const int HUD_INDEX = 5;
    private const int PAUSE_INDEX = 6;
    private const int PLAYER_INDEX = 7;
    private const int ENVIRONMENT_INDEX = 8;
    private const int SHOP_INDEX = 9;

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
       
        InitializeGlobalEventSystem();
        Debug.Log("EventSystem Initalized!!!!!");
        Debug.Log("Initalizing camera system");
        InitializeGlobalCameraSystem();
    
        Debug.Log("Cameras initalized Initalized!!!");
        Debug.Log(" Menu  awakening...");
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
        Debug.Log(" menu loaded...");


      
        if (gameExitManager == null) gameExitManager = GetComponent<GameExitManager>();
        if (hudManager == null) hudManager = GetComponent<HudManager>();
        if (menuManager == null) menuManager = GetComponent<MenuManager>();
        if (pauseManager == null) pauseManager = GetComponent<PauseManager>();
        if (shopManager == null) shopManager = GetComponent<ShopManager>();


    }

    public void InitializeGlobalEventSystem()
    {
        EventSystem existingSystem = Object.FindFirstObjectByType<EventSystem>();// checks for extra event systems

        if (existingSystem != null)
        {
            DontDestroyOnLoad(existingSystem.gameObject); // keeps it from being destroyed.
        }
        else if (eventSystemPrefab != null)
        {
            GameObject spawnedSystem = Instantiate(eventSystemPrefab);// creates one if  not found
            spawnedSystem.name = "Global_EventSystem";
            DontDestroyOnLoad(spawnedSystem);
        }
    }
    public void InitializeGlobalCameraSystem()
    {
        Camera existingCamera = Object.FindFirstObjectByType<Camera>();
        if (existingCamera != null)
        {
            DontDestroyOnLoad(existingCamera.gameObject);
        }
        else if (cameraPrefab != null)
        {
            GameObject spawnedCamera = Instantiate(cameraPrefab);
            spawnedCamera.name = "Global_CameraSystem";
            DontDestroyOnLoad(spawnedCamera);
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
