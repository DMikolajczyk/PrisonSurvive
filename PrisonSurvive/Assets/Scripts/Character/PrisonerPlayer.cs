﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private float hitTimer = 0.0f;


    protected override void UpdateGuiStats()
    {
        gui.UpdateHealthBar(health, healthMax);
    }

    public override void ReduceHealth (float val)
    {
        base.ReduceHealth(val);
        bloodScreenImage.color = bloodScreenColor;
    }

    protected new void Update()
    {
        base.Update();
        if (bloodScreenImage.color.a > threshold)
        {
            bloodScreenImage.color = Color.Lerp(bloodScreenImage.color, Color.clear, timeOfBloodScreen * Time.deltaTime);

        }
        else if (bloodScreenImage.color != Color.clear)
        {
            bloodScreenImage.color = Color.clear;
        }
        HitOther();
    }


    private void HitOther()
    {
        hitTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && hitTimer > timeToNextHit)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                Transform obj = hit.transform;
                if (Vector3.Distance(obj.position, transform.position) < hitRange)
                {
                    PrisonerEnemy prisoner = obj.gameObject.GetComponent<PrisonerEnemy>();
                    if (prisoner != null)
                    {
                        prisoner.ReduceHealth(damage);
                        hitTimer = 0.0f;
                    }
                }
            }
        }
    }

    protected override void Die()
    {
        base.Die();
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

}
