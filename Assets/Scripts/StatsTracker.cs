using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : Singleton<StatsTracker>
{
    public float maxHealth = 15;
    public float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
}
