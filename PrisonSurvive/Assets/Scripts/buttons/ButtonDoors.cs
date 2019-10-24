using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoors : MonoBehaviour
{
    private bool isOpen = false;
    private bool isInRange = false;
    private List<Animator> cratesAnimators = new List<Animator>();

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

    
    
    private void Start()
    {
        GameObject[] crates = GameObject.FindGameObjectsWithTag("CrateToMoveByButton");
        foreach (GameObject crate in crates)
        {
            cratesAnimators.Add(crate.GetComponent<Animator>());
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetButtonUp("Action"))
        {
            if (cratesAnimators[1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                if (!isOpen)
                {
                    Open();
                }
                else
                {
                    Close();
                }
                isOpen = !isOpen;
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


    private void Open()
    {
        ChangeColor(Color.green);
        foreach (Animator a in cratesAnimators)
        {
            a.SetBool("open", true);
        }
    }

    private void Close()
    {
        ChangeColor(Color.red);
        foreach (Animator a in cratesAnimators)
        {
            a.SetBool("open", false);
        }
    }


    private void ChangeColor(Color c)
    {
        GetComponent<Renderer>().material.SetColor("_Color", c);
    }

    private void UpdateText()
    {
        if (isOpen)
        {
            msgText.GetComponent<Text>().text = textForClose;
        }
        else
        {
            msgText.GetComponent<Text>().text = textForOpen;
        }
    }

}
