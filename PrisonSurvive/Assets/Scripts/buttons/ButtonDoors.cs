using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoors : MonoBehaviour
{
    //private bool isOpen = false;
    private bool isInRange = false;

    [Header("Text to set")]
    [SerializeField]
    private string textForOpen = "Press E to open cells.";
    [SerializeField]
    private string textForClose = "Press E to close cells.";

    [SerializeField]
    [Header("Canvas fields")]
    private GameObject msgPanel = null;
    [SerializeField]
    private GameObject msgText = null;


    private void Update()
    {
        if (isInRange && Input.GetButtonUp("Action"))
        {
            if (BlockManager.InstanceBM.animIsFinished())
            {
                if (!BlockManager.InstanceBM.IsOpen)
                {
                    BlockManager.InstanceBM.OpenCells(true);
                    ChangeColor(Color.green);
                }
                else
                {
                    BlockManager.InstanceBM.OpenCells(false);
                    ChangeColor(Color.red);
                }
                //BlockManager.InstanceBM.IsOpen = !BlockManager.InstanceBM.IsOpen;
                UpdateText();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInRange = true;
            UpdateText();
            msgPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
            msgPanel.SetActive(false);
        }
    }


    private void ChangeColor(Color c)
    {
        GetComponent<Renderer>().material.SetColor("_BaseColor", c);
    }

    private void UpdateText()
    {
        if (BlockManager.InstanceBM.IsOpen)
        {
            msgText.GetComponent<Text>().text = textForClose;
        }
        else
        {
            msgText.GetComponent<Text>().text = textForOpen;
        }
    }

}
