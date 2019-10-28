using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrisonerPlayer : Prisoner
{

    [SerializeField]
    private GuiMainController gui = null;
    [SerializeField]
    private Image bloodScreenImage = null;
    [SerializeField]
    private Color bloodScreenColor;


    private float timeOfBloodScreen = 0.5f;
    private float threshold = 0.01f;


    protected override void UpdateGuiStats()
    {
        gui.UpdateHealthBar();
    }

    public override void ReduceHealth (float val)
    {
        base.ReduceHealth(val);
        bloodScreenImage.color = bloodScreenColor;
    }

    private void Update()
    {
        if (bloodScreenImage.color.a > threshold)
        {
            bloodScreenImage.color = Color.Lerp(bloodScreenImage.color, Color.clear, timeOfBloodScreen * Time.deltaTime);

        }
        else if (bloodScreenImage.color != Color.clear)
        {
            bloodScreenImage.color = Color.clear;
        }
    }

}
