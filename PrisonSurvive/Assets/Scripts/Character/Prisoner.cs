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

    [SerializeField]
    protected float damage = 10.0f;
    [SerializeField]
    protected float timeToNextHit = 1.5f;


    protected float hitRange = 1.5f;
    private float health = 100.0f;
    private bool isHurting = false;

    protected void Start()
    {
        UpdateGuiStats();
    }

    protected void Update()
    {
        RegenerateHealth();
    }

    protected void RegenerateHealth()
    {
        if ((health < healthMax) && (!isHurting))
        {
            health += healthSpeedRegeneration * Time.deltaTime;
            UpdateGuiStats();
        }
    }

    protected virtual void UpdateGuiStats()
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
    public void SetIsHurting(bool isHurt)
    {
        this.isHurting = isHurt;
    }

}
