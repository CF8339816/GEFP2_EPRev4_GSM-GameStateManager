using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Unity: Game Manager & Persistence
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations:
/// 
/// </summary>
#endregion
public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }
    private GameManager gameManager;
    private GameExitManager gameExitManager;
    private ServiceHub serviceHub;
    //private SceneManager sceneManager;
    private Custom_sceneManager customSceneManager;
    private HudManager hudManager;
    private MenuManager menuManager;
    //private ShopManager shopManager;
    private int targetReturnIndex;
    [SerializeField] private Button Buy;
    [SerializeField] private Button Sell;
    [SerializeField] private Button ExitShop;

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
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // keeps script accessable accross scene changes

    }
    public void AutoHookupButtonsShop()
    {
        if (ShopManager.Instance == null)
        {
            Debug.LogError("InterfaceManager: Scenemanager.Instance is null! Cannot hook up buttons.");
            return;
        }

        ShopManager shopManager = ShopManager.Instance;// reinitalize the scene manager

        if (Buy != null)
        {
            Buy.onClick.RemoveAllListeners();
            Buy.onClick.AddListener(HudManager.Instance.onAddItem);
            Debug.Log("🎯 Found and linked: Buy");
        }
        else
        {
            Debug.LogWarning("❌ Could NOT find Button GameObject named: Buy");
        }
        if (Sell != null)
        {
            Sell.onClick.RemoveAllListeners();
            Sell.onClick.AddListener(HudManager.Instance.onRemoveItem);
            Debug.Log("🎯 Found and linked: Sell");
        }
        else
        {
            Debug.LogWarning("❌ Could NOT find Button GameObject named: Sell");
        }                
       
        if (GameExitManager.Instance != null)
        {
            GameExitManager.Instance.ConnectExitUI();
        }
    }

    public void onExitShop()
    {
        RETURNLEVEL_INDEX = ReturnIndex;
        menuManager.LoadLevelByIndex(RETURNLEVEL_INDEX);
        SceneManager.LoadScene(MENU_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(HUD_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(PLAYER_INDEX, LoadSceneMode.Additive);
        SceneManager.LoadScene(ENVIRONMENT_INDEX, LoadSceneMode.Additive);

      
    }

    /// comment made to ensure a difference in order to force a push to new github branch as  changes don't seem to be commiting


}