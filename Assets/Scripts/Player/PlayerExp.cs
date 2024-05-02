using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            AddExp(300);
        }
    }

    public void AddExp(float amount)
    {
        stats.CurrentExp += amount;
        while (stats.CurrentExp > stats.NextLevelExp)
        {
            stats.CurrentExp -= stats.NextLevelExp;
            NextLevel();        }    
    }

    private void NextLevel()
    {
        stats.Level++;
        float currentExprequired = stats.NextLevelExp;
        float newNextLevelExp = 
            Mathf.Round(currentExprequired + stats.NextLevelExp 
            * (stats.ExpMultiplier / 100));
        stats.NextLevelExp = newNextLevelExp;
    }
}
