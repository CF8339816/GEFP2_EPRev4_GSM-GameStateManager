using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#region coder & project
/// <summary>
/// NSCC GAME2025 / 4086 / Game Programming III(B)/ Doucette,Matthew
/// Engine Programming Review 05  UI Management (UIManager)
/// Coder current script: Chris French Second Year NSCC Game Programming 
/// Additions / annotations:
/// 
/// </summary>
#endregion
public class HudManager : MonoBehaviour
{
    public static HudManager Instance { get; private set; }
    private GameManager gameManager;
    private GameExitManager gameExitManager;
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

    [Header("text output")]
    public TextMeshProUGUI textCurrentLevel;
    public TextMeshProUGUI textHealthText;
    public TextMeshProUGUI textInventoryAvaillabilityText;
    [Header("sliders")]
    [SerializeField] public Slider HealthBar;
    [SerializeField] public Slider InventoryCapacity;
    [Header("health")]
    public static int HealthBarMax = 100;
    public static int HealthBarMin = 0;
    [SerializeField] public int healingDone = 12;
    [SerializeField] public int DamageTaken = 21;
    public int currentHealthPercentage;
    public int healtBarOutput;
    public float currentHealth;
    [SerializeField] public float maxHealth;
    [Header("inventory")]
    [SerializeField] public int InventoryBarMax = 24;
    public static int InventoryBarMin = 0;
    public int InventoryslotsUsed;
    public int InventorySpaceAvailable;

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
        FindUIElementsInNewScene();

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void FindUIElementsInNewScene()// finds the ui entries after destroyed to re-valuate them
    {
        if (textHealthText == null) textHealthText = GameObject.Find("HealthText")?.GetComponent<TextMeshProUGUI>();
        if (textInventoryAvaillabilityText == null) textInventoryAvaillabilityText = GameObject.Find("InventoryAvaillabilityText")?.GetComponent<TextMeshProUGUI>();
        if (HealthBar == null) HealthBar = GameObject.Find("HealthBar")?.GetComponent<Slider>();
        if (InventoryCapacity == null) InventoryCapacity = GameObject.Find("InventoryCapacity")?.GetComponent<Slider>();
        if (textCurrentLevel == null) textCurrentLevel = GameObject.Find("CurrentLevel")?.GetComponent<TextMeshProUGUI>();

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AutoHookupButtons();
    }
    private void AutoHookupButtons()
    {
       
        if (HudManager.Instance != null)
        {
            Button takeDamageButton = GameObject.Find("takeDamage")?.GetComponent<Button>();
            if (takeDamageButton != null)
            {
                takeDamageButton.onClick.RemoveAllListeners();
                takeDamageButton.onClick.AddListener(HudManager.Instance.onTakeDamage);
            }
            Button HealButton = GameObject.Find("Heal")?.GetComponent<Button>();
            if (HealButton != null)
            {
                HealButton.onClick.RemoveAllListeners();
                HealButton.onClick.AddListener(HudManager.Instance.onTakeHealing);
            }
            Button AddItemButton = GameObject.Find("AddItem")?.GetComponent<Button>();
            if (AddItemButton != null)
            {
                AddItemButton.onClick.RemoveAllListeners();
                AddItemButton.onClick.AddListener(HudManager.Instance.onAddItem);
            }
            Button removeItemButton = GameObject.Find("removeItem")?.GetComponent<Button>();
            if (removeItemButton != null)
            {
                removeItemButton.onClick.RemoveAllListeners();
                removeItemButton.onClick.AddListener(HudManager.Instance.onRemoveItem);
            }
        }
    }
    public void UpdateCurrentLevelOutput()
    {
        if (textCurrentLevel != null)
        {
            string CurrentScene = SceneManager.GetActiveScene().name;
            textCurrentLevel.text = "Current Level Loaded: " + CurrentScene;
        }
    }
    public void UpdateBagSpace()
    {
        InventorySpaceAvailable = InventoryBarMax - InventoryslotsUsed;
        InventoryCapacity.value = InventoryslotsUsed;
        textInventoryAvaillabilityText.text = "Slots available" + InventorySpaceAvailable.ToString() + "\nInventory used: " + InventoryslotsUsed.ToString() + "/" + InventoryBarMax.ToString();
    }
    public void UpdateHealthBar()
    {
        healtBarOutput = currentHealthPercentage;
        HealthBar.value = healtBarOutput;
        textHealthText.text = "Health %: " + currentHealthPercentage.ToString() + "\nHealth: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }
    public void onTakeDamage()
    {
        currentHealth -= DamageTaken;
        if (currentHealth <= 0) { currentHealth = 0; }
        CalculateHealthPercentage();
    }
    public void onTakeHealing()
    {
        currentHealth += healingDone;
        if (currentHealth >= maxHealth) { currentHealth = maxHealth; }
        CalculateHealthPercentage();
    }
    public void CalculateHealthPercentage()
    {
        currentHealthPercentage = Mathf.RoundToInt((currentHealth / maxHealth) * 100);
    }
    public void onAddItem()
    {
        if (InventoryslotsUsed < InventoryBarMax) { InventoryslotsUsed++; }
    }
    public void onRemoveItem()
    {
        if (InventoryslotsUsed > 0) { InventoryslotsUsed--; }
    }
    public void onResetStats()
    {
        currentHealth = maxHealth;
        InventoryslotsUsed = 0;
        CalculateHealthPercentage();
        if (HealthBar != null) { HealthBar.value = currentHealthPercentage; }
        if (InventoryCapacity != null) { InventoryCapacity.value = InventoryslotsUsed; }
    }
    //---------------------------------------------------------------------------------------------------------------------------------------------------------
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
