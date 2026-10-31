using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class EnemyTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyListText;
    [SerializeField] private TMP_Text enemyCountText;

    private List<string> activeEnemies = new List<string>();
    private int spawnCounter = 0;

    private void Start()
    {
        RefreshUI();
    }

    public void SpawnEnemy()
    {
        spawnCounter++;
        string enemyName = "Goblin " + spawnCounter;
        activeEnemies.Add(enemyName);
        Debug.Log("Spawned: " + enemyName);
        RefreshUI();
    }

    public void DefeatEnemy(string enemyName)
    {
        if (activeEnemies.Contains(enemyName))
        {
            activeEnemies.Remove(enemyName);
            Debug.Log("Defeated: " + enemyName);
        }
        else
        {
            Debug.LogWarning("Tried to remove an enemy that isn't in the list: " + enemyName);
        }
        RefreshUI();
    }

    public void DefeatLastEnemy()
    {
        if (activeEnemies.Count == 0)
        {
            Debug.LogWarning("No enemies left to defeat.");
            return;
        }
        DefeatEnemy(activeEnemies[activeEnemies.Count - 1]);
    }

    public void WipeWave()
    {
        activeEnemies.Clear();
        spawnCounter = 0;
        RefreshUI();
    }

    private void RefreshUI()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            sb.AppendLine((i + 1) + ". " + activeEnemies[i]);
        }

        enemyListText.text = activeEnemies.Count == 0 ? "No active enemies" : sb.ToString();
        enemyCountText.text = "Enemies: " + activeEnemies.Count;
    }
}