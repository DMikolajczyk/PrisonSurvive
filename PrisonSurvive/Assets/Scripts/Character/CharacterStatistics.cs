using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float timeOfBloodScreen = 0.5f;
    private float threshold = 0.01f;


    [SerializeField]
    private Image bloodScreenImage = null;
    
    [SerializeField]
    private Color bloodScreenColor;

    private void FixedUpdate()
    {
        if ((health < healthMax) && (!isHurting))
        {
            health += healthSpeedRegeneration * 0.05f;
            gui.UpdateHealthBar();
        }
    }

    private void Update()
    {
        if (bloodScreenImage.color.a > threshold)
        {
            bloodScreenImage.color = Color.Lerp(bloodScreenImage.color, Color.clear, timeOfBloodScreen * Time.deltaTime);
            
        }
        else if(bloodScreenImage.color != Color.clear)
        {
            bloodScreenImage.color = Color.clear;
        }
    }

    public void reduceHealth(float val)
    {
        health -= val;
        gui.UpdateHealthBar();
        bloodScreenImage.color = bloodScreenColor;
        
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
