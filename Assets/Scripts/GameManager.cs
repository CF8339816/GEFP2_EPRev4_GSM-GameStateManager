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
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static GameExitManager gameExitManager;
    public static ServiceHub serviceHub;
    public static Custom_sceneManager customSceneManager;
    public static MenuManager menuManager;
    public static HudManager hudManager;
    public static PauseManager pauseManager;

      
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    public void Update()
    {
        

    }
   
}