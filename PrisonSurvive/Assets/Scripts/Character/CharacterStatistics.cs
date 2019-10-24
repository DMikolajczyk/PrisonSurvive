using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatistics : MonoBehaviour
{
    [SerializeField]
    private float healthMax = 100.0f;
    [SerializeField]
    private float healthSpeedRegeneration = 1.0f;
    [SerializeField]
    private GuiMainController gui = null;
    
    private float health = 100.0f;
    private bool isHurting = false;

    private void FixedUpdate()
    {
        if ((health < healthMax) && (!isHurting))
        {
            health += healthSpeedRegeneration * 0.05f;
            gui.UpdateHealthBar();
        }
    }



    public void reduceHealth(float val)
    {
        health -= val;
        gui.UpdateHealthBar();
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
