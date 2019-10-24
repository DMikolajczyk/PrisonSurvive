using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiMainController : MonoBehaviour
{

    [SerializeField]
    GameObject healthBar = null;

    [SerializeField]
    CharacterStatistics playerStats = null;

    private void Start()
    {
        UpdateHealthBar();
    }


    public void UpdateHealthBar()
    {
        healthBar.GetComponent<Image>().fillAmount = playerStats.GetCurrentHealth() / playerStats.GetMaxHealth();
    }


}
