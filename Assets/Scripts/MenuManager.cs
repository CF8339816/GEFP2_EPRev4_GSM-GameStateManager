using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;
#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Unity: Game Manager & Persistence
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations:
/// 
/// </summary>
#endregion
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    private GameManager gameManager;
    private GameExitManager gameExitManager;
  //  private CharacterController characterController;
    [SerializeField] GameObject dude;

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
    private int RETURNLEVEL_INDEX;
    private int ReturnIndex;

    private int nextIndex;
    public void Awake()
    {
        //OnSceneLoaded(Scene, LoadSceneMode);
        Debug.Log("CustomSceneManager awakening...");
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // keeps script accessible across scene changes

        AutoHookupButtons();

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
   
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AutoHookupButtons();
    }
    private void AutoHookupButtons()
    {
        Button startButton = GameObject.Find("StartGame")?.GetComponent<Button>();
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(onStart);
        }
        Button nextButton = GameObject.Find("nextLevel")?.GetComponent<Button>();
        if (nextButton != null)
        {
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(onLoadNextLevel);
        }
        Button menuButton = GameObject.Find("Menu")?.GetComponent<Button>();
        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(onMenu);
        }
        Button level1Button = GameObject.Find("Level1")?.GetComponent<Button>();
        if (level1Button != null)
        {
            level1Button.onClick.RemoveAllListeners();
            level1Button.onClick.AddListener(onLevel1);
        }
        Button level2Button = GameObject.Find("level2")?.GetComponent<Button>();
        if (level2Button != null)
        {
            level2Button.onClick.RemoveAllListeners();
            level2Button.onClick.AddListener(onLevel2);
        }
        Button level3Button = GameObject.Find("level3")?.GetComponent<Button>();
        if (level3Button != null)
        {
            level3Button.onClick.RemoveAllListeners();
            level3Button.onClick.AddListener(onLevel3);
        }
        Button QuitButton = GameObject.Find("Quit")?.GetComponent<Button>();
     
        if (QuitButton != null)
        {
            QuitButton.onClick.RemoveAllListeners();


            if (GameExitManager.Instance != null)
            {
                QuitButton.onClick.AddListener(GameExitManager.Instance.Ongameexit);
            }
        }

    }
    public void LoadLevelByIndex(int index)
    {
        if (index >= 0 && index < 4) 
        {
            SceneManager.LoadScene(index);
    
        }
    }
    public void onLevel1()
    {
        LoadLevelByIndex(LEVEL_1_INDEX);
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(HUD_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(PLAYER_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(ENVIRONMENT_INDEX, LoadSceneMode.Additive);
        dude.SetActive(true);
      
    }
    public void onLevel2()
    {
        LoadLevelByIndex(LEVEL_2_INDEX);
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(HUD_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(PLAYER_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(ENVIRONMENT_INDEX, LoadSceneMode.Additive);
        dude.SetActive(true);

    
    }
    public void onLevel3()
    {
        LoadLevelByIndex(LEVEL_3_INDEX);
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(HUD_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(PLAYER_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(ENVIRONMENT_INDEX, LoadSceneMode.Additive);
        dude.SetActive(true);
     
    }
    public void onMenu()
    {
        LoadLevelByIndex(MAIN_INDEX);
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
     
    }
   
    public void onPause()
    {
      

        if (dude != null)
        {
            dude.SetActive(false); 
        }
        ReturnIndex = SceneManager.GetActiveScene().buildIndex;
        LoadLevelByIndex(PAUSE_INDEX);
    }

    public void onShopEnter()
    {
       
      
        ReturnIndex = SceneManager.GetActiveScene().buildIndex;
        LoadLevelByIndex(SHOP_INDEX);
    }

    public void onStart()
    {
        if (HudManager.Instance != null)
        {
            HudManager.Instance.onResetStats();
            onLevel1();
        }
    }
    public void onLoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 3)
        { 
            nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevelByIndex(nextIndex);
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(HUD_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(PLAYER_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(ENVIRONMENT_INDEX, LoadSceneMode.Additive);
         }
        else
        {
            onMenu();
        }
        
    }

  
}
