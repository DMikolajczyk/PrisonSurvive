using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiMainController : MonoBehaviour
{

    [SerializeField]
    GameObject healthBar = null;
    

    public void UpdateHealthBar(float hp, float hp_max)
    {
        healthBar.GetComponent<Image>().fillAmount = hp / hp_max;
    }


}
