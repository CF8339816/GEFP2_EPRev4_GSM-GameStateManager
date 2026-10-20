using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Unity: Game Manager & Persistence
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations: Fixed naming conflict with Unity's built-in SceneManager.
/// </summary>
#endregion
public class ServiceHub : MonoBehaviour
{    public static ServiceHub Instance { get; private set; }// creates szervice hub instance 
    [Header("System References")]// defines other scripts
    public Custom_sceneManager customSceneManager;
    public HudManager hudManager;
    public MenuManager menuManager; 
    public PauseManager pauseManager;   
    public GameManager gameManager;
    public GameExitManager gameExitManager;

    public GameObject cameraPrefab;
    public GameObject eventSystemPrefab;
    public GameObject _ServiceHub;
    public GameObject HUDManager;
    public GameObject PAUSEManager;
    public GameObject MENUManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); //destroy whole object
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); //maintaains gameobject accross scenes
        if (customSceneManager == null) customSceneManager = GetComponent<Custom_sceneManager>();
        if (gameManager == null) gameManager = GetComponent<GameManager>();
        if (gameExitManager == null) gameExitManager = GetComponent<GameExitManager>();
        if (hudManager == null) hudManager = GetComponent<HudManager>();
        if (menuManager == null) menuManager = GetComponent<MenuManager>();
        if (pauseManager == null) pauseManager = GetComponent<PauseManager>();

        InitializeGlobalEventSystem();
        InitializeGlobalCameraSystem();
    }

    private void InitializeGlobalEventSystem()
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
    private void InitializeGlobalCameraSystem() 
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
}