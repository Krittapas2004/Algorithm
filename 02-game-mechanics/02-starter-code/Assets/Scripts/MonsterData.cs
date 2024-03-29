using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterLevel
{
    public int cost; 
    public GameObject visualization;
}

public class MonsterData : MonoBehaviour
{
    public List<MonsterLevel> levels; 
    private MonsterLevel currentLevel; 

    public void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public MonsterLevel CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;

            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex) 
                  {
                    levels[i].visualization.SetActive(true);
                  }
                  else 
                  {
                    levels[i].visualization.SetActive(false);
                  }
                }
            }
        }
    }

    public MonsterLevel GetNextLevel()
    {
       
        int currentLevelIndex = levels.IndexOf(currentLevel);
       
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void IncreaseLevel()
    {
         int currentLevelIndex = levels.IndexOf(currentLevel);
        
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}