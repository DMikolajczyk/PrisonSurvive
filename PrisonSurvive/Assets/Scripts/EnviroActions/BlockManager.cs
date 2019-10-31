using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private static BlockManager blockManager;

    public static BlockManager InstanceBM { get { return blockManager; } }

    private void Awake()
    {
        if(blockManager != null && blockManager != this )
        {
            Destroy(gameObject);
        }
        else
        {
            blockManager = this;
        }
    }


    private List<Animator> cratesAnimators = new List<Animator>();
    public bool IsOpen { get; set; }
    public float TimeOpen { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] crates = GameObject.FindGameObjectsWithTag("CrateToMoveByButton");
        foreach (GameObject crate in crates)
        {
            cratesAnimators.Add(crate.GetComponent<Animator>());
        }
        OpenCells(true);
    }

    private void Update()
    {
        TimeOpen += Time.deltaTime;
    }

    public void OpenCells(bool open)
    {
        foreach (Animator a in cratesAnimators)
        {
            a.SetBool("open", open);
        }
        if (open)
        {
            TimeOpen = 0.0f;
        }
        IsOpen = open;
        
    }

    public bool animIsFinished()
    {
        if(cratesAnimators[1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            return true;
        }
        return false;
    }

    public float GetAnimTime()
    {
        return cratesAnimators[1].GetCurrentAnimatorStateInfo(0).length;
    }

}
