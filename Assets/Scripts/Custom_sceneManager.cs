using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Engine Programming Review 05  UI Management (UIManager)
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
    private const int SHOP_INDEX = 9;
    private int RETURNLEVEL_INDEX;
    private int ReturnIndex;

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
        //  AutoHookupButtons();
    }
}