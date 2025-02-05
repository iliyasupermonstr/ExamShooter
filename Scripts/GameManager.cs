using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public int killCount = 0; 
    [SerializeField] private TextMeshProUGUI killCounterText; 

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadKillCount(); 
    }

    
    public void AddKill()
    {
        killCount++;
        UpdateKillUI();
        SaveKillCount(); 
    }

    
    private void UpdateKillUI()
    {
        if (killCounterText != null)
        {
            killCounterText.text = "SCORE: " + killCount;
        }
    }

    
    private void SaveKillCount()
    {
        PlayerPrefs.SetInt("KillCount", killCount);
        PlayerPrefs.Save(); 
    }

    
    private void LoadKillCount()
    {
        killCount = PlayerPrefs.GetInt("KillCount", 0);
        UpdateKillUI();
    }

    
    public void ResetKillCount()
    {
        killCount = 0;
        PlayerPrefs.SetInt("KillCount", killCount);
        PlayerPrefs.Save();
        UpdateKillUI();
    }
}