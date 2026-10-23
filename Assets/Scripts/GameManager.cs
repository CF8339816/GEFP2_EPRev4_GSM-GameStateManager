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
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static GameExitManager gameExitManager;
    public static ServiceHub serviceHub;
    public static Custom_sceneManager customSceneManager;
    public static MenuManager menuManager;
    public static HudManager hudManager;
    public static PauseManager pauseManager;

    //[Header("text output")]
    //public TextMeshProUGUI textCurrentLevel;
    //public TextMeshProUGUI textHealthText;
    //public TextMeshProUGUI textInventoryAvaillabilityText;
    //[Header("sliders")]
    //[SerializeField] private Slider HealthBar;
    //[SerializeField] private Slider InventoryCapacity;
    //[Header("health")]
    //public int HealthBarMax = 100;
    //private int HealthBarMin = 0;
    //[SerializeField] public int healingDone= 12 ;
    //[SerializeField] public int DamageTaken= 21;
    //private int currentHealthPercentage;
    //private int healtBarOutput;
    //public float currentHealth;
    //[SerializeField] public float maxHealth;
    //[Header("inventory")]
    //[SerializeField] public int InventoryBarMax = 24;
    //private int InventoryBarMin = 0;
    //public int InventoryslotsUsed = 0;
    //private int InventorySpaceAvailable;      
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // maintains data              
        // serviceHub = Object.FindFirstObjectByType<ServiceHub>();
        //customSceneManager = Object.FindFirstObjectByType<Custom_sceneManager>();
        //gameExitManager = Object.FindFirstObjectByType<GameExitManager>();
        //menuManager = Object.FindFirstObjectByType<MenuManager>();
        //hudManager = Object.FindFirstObjectByType<HudManager>();
        //pauseManager = Object.FindFirstObjectByType<PauseManager>();
        //onResetStats();
        //hudManager.onResetStats();
    }
    public void Update()
    {
        //FindUIElementsInNewScene();
        //UpdateBagSpace();
        //UpdateHealthBar();
        //UpdateCurrentLevelOutput();
        //hudManager.UpdateBagSpace();
        //hudManager.UpdateHealthBar();
        //hudManager.UpdateCurrentLevelOutput();
    }
    //public void FindUIElementsInNewScene()// finds the ui entries after destroyed to re-valuate them
    //{        
    //    if (hudManager.textHealthText == null) hudManager.textHealthText = GameObject.Find("HealthText")?.GetComponent<TextMeshProUGUI>();
    //    if (hudManager.textInventoryAvaillabilityText == null) hudManager.textInventoryAvaillabilityText = GameObject.Find("InventoryAvaillabilityText")?.GetComponent<TextMeshProUGUI>();
    //    if (hudManager.HealthBar == null) hudManager.HealthBar = GameObject.Find("HealthBar")?.GetComponent<Slider>();
    //    if (hudManager.InventoryCapacity == null) hudManager.InventoryCapacity = GameObject.Find("InventoryCapacity")?.GetComponent<Slider>();
    //    if (hudManager.textCurrentLevel == null) hudManager.textCurrentLevel = GameObject.Find("CurrentLevel")?.GetComponent<TextMeshProUGUI>();

    //}
    //    public void UpdateCurrentLevelOutput()
    //    {
    //        if (hudManager.textCurrentLevel != null)
    //        {
    //            string CurrentScene = SceneManager.GetActiveScene().name;
    //            hudManager.textCurrentLevel.text = "Current Level Loaded: " + CurrentScene;
    //        }
    //    }
    //    public void UpdateBagSpace()
    //    {
    //        hudManager.InventorySpaceAvailable = hudManager.InventoryBarMax - hudManager.InventoryslotsUsed;
    //        hudManager.InventoryCapacity.value = hudManager.InventoryslotsUsed;
    //        hudManager.textInventoryAvaillabilityText.text = "Slots available" + hudManager.InventorySpaceAvailable.ToString() + "\nInventory used: " + hudManager.InventoryslotsUsed.ToString() + "/" + hudManager.InventoryBarMax.ToString();
    //    }
    //    public void UpdateHealthBar()
    //    {
    //        hudManager.healtBarOutput = hudManager.currentHealthPercentage;
    //        hudManager.HealthBar.value = hudManager.healtBarOutput;
    //        hudManager.textHealthText.text = "Health %: " + hudManager.currentHealthPercentage.ToString() + "\nHealth: " + hudManager.currentHealth.ToString() + "/" + hudManager.maxHealth.ToString();
    //    }
    //    public void onTakeDamage()
    //    {
    //        hudManager.currentHealth -= hudManager.DamageTaken;
    //        if (hudManager.currentHealth <= 0) { hudManager.currentHealth = 0; }
    //        CalculateHealthPercentage();
    //    }
    //    public void onTakeHealing()
    //    {
    //        hudManager.currentHealth += hudManager.healingDone;
    //        if (hudManager.currentHealth >= hudManager.maxHealth) { hudManager.currentHealth = hudManager.maxHealth; }
    //        CalculateHealthPercentage();
    //    }
    //    public void CalculateHealthPercentage()
    //    {
    //        hudManager.currentHealthPercentage = Mathf.RoundToInt((hudManager.currentHealth / hudManager.maxHealth) * 100);
    //    }
    //    public void onAddItem()
    //    {
    //        if (hudManager.InventoryslotsUsed < hudManager.InventoryBarMax) { hudManager.InventoryslotsUsed++; }
    //    }
    //    public void onRemoveItem()
    //    {
    //        if (hudManager.InventoryslotsUsed > 0) { hudManager.InventoryslotsUsed--; }
    //    }
    //    public void onResetStats()
    //    {
    //        hudManager.currentHealth = hudManager.maxHealth;
    //        hudManager.InventoryslotsUsed = 0;
    //        CalculateHealthPercentage();
    //        if (hudManager.HealthBar != null) { hudManager.HealthBar.value = hudManager.currentHealthPercentage; }
    //        if (hudManager.InventoryCapacity != null) { hudManager.InventoryCapacity.value = hudManager.InventoryslotsUsed; }
    //    }
}












