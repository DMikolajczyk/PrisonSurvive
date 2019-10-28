using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prisoner : MonoBehaviour
{
    [SerializeField]
    private float healthMax = 100.0f;
    [SerializeField]
    private float healthSpeedRegeneration = 1.0f;
    
    private float health = 100.0f;
    private bool isHurting = false;
    
    private void FixedUpdate()
    {
        RegenerateHealth();
    }

    protected void RegenerateHealth()
    {
        if ((health < healthMax) && (!isHurting))
        {
            health += healthSpeedRegeneration * 0.05f;
            UpdateGuiStats();
        }
    }

    protected virtual void UpdateGuiStats()
    {

    }

    private void Update()
    {
        
    }

    public virtual void ReduceHealth(float val)
    {
        health -= val;
        UpdateGuiStats();
        
    }


    public float GetMaxHealth()
    {
        return healthMax;
    }
    public float GetCurrentHealth()
    {
        return health;
    }
    public void SetIsHurting(bool isHurting)
    {
        this.isHurting = isHurting;
    }

}
