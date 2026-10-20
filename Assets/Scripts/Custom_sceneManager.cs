using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Unity: Game Manager & Persistence
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations:
/// 
/// </summary>
#endregion
public class Custom_sceneManager : MonoBehaviour
{

    public static Custom_sceneManager Instance { get; private set; }
    private GameManager gameManager;
    private GameExitManager gameExitManager;
    private MenuManager menuManager;
    private HudManager hudManager;
    private PauseManager pauseManager;

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
    private int RETURNLEVEL_INDEX;
    public int ReturnIndex;

    void Awake()
    {
        Debug.Log("CustomSceneManager awakening...");
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // keeps script accessible across scene changes
       
        Debug.Log(" Menu  awakening...");
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
        Debug.Log(" menu loaded...");
        //SceneManager.LoadScene(ENVIRONMENT_INDEX, LoadSceneMode.Additive);
        //SceneManager.LoadScene(HUD_INDEX, LoadSceneMode.Additive);
        //SceneManager.LoadScene(PLAYER_INDEX, LoadSceneMode.Additive);
        //Debug.Log("Scenemanager  done.");
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
        if (GameManager.Instance != null)
        {
            Button takeDamageButton = GameObject.Find("takeDamage")?.GetComponent<Button>();
            if (takeDamageButton != null)
            {
                takeDamageButton.onClick.RemoveAllListeners();
                takeDamageButton.onClick.AddListener(GameManager.Instance.onTakeDamage);
            }
            Button HealButton = GameObject.Find("Heal")?.GetComponent<Button>();
            if (HealButton != null)
            {
                HealButton.onClick.RemoveAllListeners();
                HealButton.onClick.AddListener(GameManager.Instance.onTakeHealing);
            }
            Button AddItemButton = GameObject.Find("AddItem")?.GetComponent<Button>();
            if (AddItemButton != null)
            {
                AddItemButton.onClick.RemoveAllListeners();
                AddItemButton.onClick.AddListener(GameManager.Instance.onAddItem);
            }
            Button removeItemButton = GameObject.Find("removeItem")?.GetComponent<Button>();
            if (removeItemButton != null)
            {
                removeItemButton.onClick.RemoveAllListeners();
                removeItemButton.onClick.AddListener(GameManager.Instance.onRemoveItem);
            }
        }
    }
    public void LoadLevelByIndex(int index)
    {
        if (index >= 0 && index < SceneManager.sceneCountInBuildSettings) { SceneManager.LoadScene(index); }
    }
    public void onLevel1()
    {
        LoadLevelByIndex(LEVEL_1_INDEX);
        StartCoroutine(AddSceneLayers(LEVEL_1_INDEX));
    }
    public void onLevel2()
    {
        LoadLevelByIndex(LEVEL_2_INDEX);
        StartCoroutine(AddSceneLayers(LEVEL_2_INDEX));
    }
    public void onLevel3()
    {
        LoadLevelByIndex(LEVEL_3_INDEX);
        StartCoroutine(AddSceneLayers(LEVEL_3_INDEX));
    }
   
    public void onMenu()
    {
        LoadLevelByIndex(MAIN_INDEX);
        StartCoroutine(AddBaseMenuLayer(MAIN_INDEX));
      

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

    public void onResume(int targetReturnIndex)
    {

      
        if (targetReturnIndex > 0)
        {
            if (dude != null)
            {
                dude.SetActive(true);
            }
        }
        else
        {
            dude.SetActive(false);
        }

        RETURNLEVEL_INDEX = ReturnIndex;
        LoadLevelByIndex(RETURNLEVEL_INDEX);


    }        
    public void onStart()
    {
        if (GameManager.Instance != null) ;
        GameManager.Instance.onResetStats();
        onLevel1();
    }
    public void onLoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevelByIndex(nextIndex);
    }
    public IEnumerator AddBaseMenuLayer(int baseLevelIndex)
    {
        yield return SceneManager.LoadSceneAsync(baseLevelIndex, LoadSceneMode.Single);// load active level and wait till complete        
        yield return SceneManager.LoadSceneAsync(MENU_INDEX, LoadSceneMode.Additive);// load scene layer fully then on to next

        Scene baseScene = SceneManager.GetSceneByBuildIndex(baseLevelIndex);// makse sure added objects  owned by base layer
        if (baseScene.IsValid())
        {
            SceneManager.SetActiveScene(baseScene);
        }
        yield return null;

    }
    public IEnumerator AddSceneLayers(int baseLevelIndex)
    {
        yield return SceneManager.LoadSceneAsync(baseLevelIndex, LoadSceneMode.Single);// load active level and wait till complete        
        yield return SceneManager.LoadSceneAsync(MENU_INDEX, LoadSceneMode.Additive);// load scene layer fully then on to next
        yield return SceneManager.LoadSceneAsync(HUD_INDEX, LoadSceneMode.Additive);// load scene layer fully then on to next
        yield return SceneManager.LoadSceneAsync(PLAYER_INDEX, LoadSceneMode.Additive);// load scene layer fully then on to next
        yield return SceneManager.LoadSceneAsync(ENVIRONMENT_INDEX, LoadSceneMode.Additive);// load scene layer fully 
        Scene baseScene = SceneManager.GetSceneByBuildIndex(baseLevelIndex);// makse sure added objects  owned by base layer
        if (baseScene.IsValid())
        {
            SceneManager.SetActiveScene(baseScene);
        }
        yield return null;
    }
}

