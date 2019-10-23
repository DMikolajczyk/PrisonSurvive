using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoors : MonoBehaviour
{
    private bool isOpen = false;
    private bool isInRange = false;
    private List<Animator> cratesAnimators = new List<Animator>();
    
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
            updateIsOpen();
            if (!isOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }

    private void Open()
    {
        changeColor(Color.green);
        foreach (Animator a in cratesAnimators)
        {
            a.SetTrigger("Open");
        }
    }

    private void Close()
    {
        changeColor(Color.red);
        foreach (Animator a in cratesAnimators)
        {
            a.SetTrigger("Close");
        }
    }

    private void updateIsOpen()
    {
        if (cratesAnimators[0].GetCurrentAnimatorStateInfo(0).IsName("CrateOpen"))
        {
            isOpen = true;
        }
        else if (cratesAnimators[0].GetCurrentAnimatorStateInfo(0).IsName("CrateClose"))
        {
            isOpen = false;
        }
    }

    private void changeColor(Color c)
    {
        GetComponent<Renderer>().material.SetColor("_Color", c);
    }

}
