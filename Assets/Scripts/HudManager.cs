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
    //public void UpdateCurrentLevelOutput()
    //{
    //    if (textCurrentLevel != null)
    //    {
    //        string CurrentScene = SceneManager.GetActiveScene().name;
    //        textCurrentLevel.text = "Current Level Loaded: " + CurrentScene;
    //    }
    //}
    //public void UpdateBagSpace()
    //{
    //    InventorySpaceAvailable = InventoryBarMax - InventoryslotsUsed;
    //    InventoryCapacity.value = InventoryslotsUsed;
    //    textInventoryAvaillabilityText.text = "Slots available" + InventorySpaceAvailable.ToString() + "\nInventory used: " + InventoryslotsUsed.ToString() + "/" + InventoryBarMax.ToString();
    //}
    //public void UpdateHealthBar()
    //{
    //    healtBarOutput = currentHealthPercentage;
    //    HealthBar.value = healtBarOutput;
    //    textHealthText.text = "Health %: " + currentHealthPercentage.ToString() + "\nHealth: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    //}
    //public void onTakeDamage()
    //{
    //    currentHealth -= DamageTaken;
    //    if (currentHealth <= 0) { currentHealth = 0; }
    //    CalculateHealthPercentage();
    //}
    //public void onTakeHealing()
    //{
    //    currentHealth += healingDone;
    //    if (currentHealth >= maxHealth) { currentHealth = maxHealth; }
    //    CalculateHealthPercentage();
    //}
    //public void CalculateHealthPercentage()
    //{
    //    currentHealthPercentage = Mathf.RoundToInt((currentHealth / maxHealth) * 100);
    //}
    //public void onAddItem()
    //{
    //    if (InventoryslotsUsed < InventoryBarMax) { InventoryslotsUsed++; }
    //}
    //public void onRemoveItem()
    //{
    //    if (InventoryslotsUsed > 0) { InventoryslotsUsed--; }
    //}
    //public void onResetStats()
    //{
    //    currentHealth = maxHealth;
    //    InventoryslotsUsed = 0;
    //    CalculateHealthPercentage();
    //    if (HealthBar != null) { HealthBar.value = currentHealthPercentage; }
    //    if (InventoryCapacity != null) { InventoryCapacity.value = InventoryslotsUsed; }
    //}
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
