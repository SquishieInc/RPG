using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log("Player Took Damage!!");
            TakeDamage(1f);
        }
    }

   public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if(stats.Health <= 0)
        {
            stats.Health = Mathf.Max(stats.Health -= amount, 0f);
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();

    }
}
