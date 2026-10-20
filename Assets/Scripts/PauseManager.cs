using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;
#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Unity: Game Manager & Persistence
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations:
/// 
/// </summary>
#endregion
public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    private GameManager gameManager;
    private GameExitManager gameExitManager;
    private MenuManager menuManager;
   // private CharacterController characterController;
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
    private int ReturnIndex;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void Awake()
    {
        //OnSceneLoaded(Scene, LoadSceneMode);


        AutoHookupButtons();

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AutoHookupButtons();
    }
    private void AutoHookupButtons()
    {
        Button startButton = GameObject.Find("RestartGame")?.GetComponent<Button>();
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(onStart);
        }

        Button resumeButton = GameObject.Find("ResumeGame")?.GetComponent<Button>();
        if (resumeButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(onStart);
        }
        Button menuButton = GameObject.Find("Menu")?.GetComponent<Button>();
        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(onMenu);
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
        if (index >= 0 && index < SceneManager.sceneCountInBuildSettings) { SceneManager.LoadScene(index); }
    }

    public void onMenu()
    {
        LoadLevelByIndex(MAIN_INDEX);
        StartCoroutine(AddBaseMenuLayer(MAIN_INDEX));
        // LoadLevelByIndex(MENU_INDEX);

    }
    public void onResume(int targetReturnIndex)
    {

        //if (characterController == null)
        //{
        //    dude.SetActive(true);
        //}
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
     


        //StartCoroutine(AddSceneLayers(RETURNLEVEL_INDEX));

    }


    //public void onPause()
    //{
    //    if (characterController == null)
    //    { 
    //        dude.SetActive( false); 
    //    }
    //    ReturnIndex = SceneManager.GetActiveScene().buildIndex;
    //    LoadLevelByIndex(PAUSE_INDEX);
    //}
    public void onStart()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onResetStats();
            menuManager.onLevel1();
        }
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

    //public IEnumerator AddSceneLayers(int baseLevelIndex)
    //{
    //    yield return SceneManager.LoadSceneAsync(baseLevelIndex, LoadSceneMode.Single);// load active level and wait till complete        
    //    yield return SceneManager.LoadSceneAsync(MENU_INDEX, LoadSceneMode.Additive);// load scene layer fully then on to next
    //    yield return SceneManager.LoadSceneAsync(HUD_INDEX, LoadSceneMode.Additive);// load scene layer fully then on to next
    //    yield return SceneManager.LoadSceneAsync(PLAYER_INDEX, LoadSceneMode.Additive);// load scene layer fully then on to next
    //    yield return SceneManager.LoadSceneAsync(ENVIRONMENT_INDEX, LoadSceneMode.Additive);// load scene layer fully 
    //    Scene baseScene = SceneManager.GetSceneByBuildIndex(baseLevelIndex);// makse sure added objects  owned by base layer
    //    if (baseScene.IsValid())
    //    {
    //        SceneManager.SetActiveScene(baseScene);
    //    }
    //    yield return null;
    //}

}
