using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerEnemy : MonoBehaviour
{

    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private float moveSpeed = 2.0f,
                rotateSpeed = 5.0f,
                distBlocker = 5.0f,
                distThreshold = 0.2f;
    [SerializeField]
    private int cell_id = 1;



    private bool setTargetForPlayer = false;
    private bool setTargetForCell = false;
    private bool isWaitingForMove = false;
    private bool isMoving = false;
    private Transform player; 
    private Vector3 target;
    private Vector3 playerPositionCorrected;
    private float actualMoveSpeed = 0.0f,
        distToTarget = 0.0f;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Animation();
        if (!isWaitingForMove)
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                setTargetForPlayer = !setTargetForPlayer;
                if (setTargetForPlayer)
                {
                    target = new Vector3(player.position.x, transform.position.y, player.position.z);
                }
            }
            else if (Input.GetKeyUp(KeyCode.O))
            {
                setTargetForCell = !setTargetForCell;
                if (setTargetForCell)
                {
                    target = new Vector3(findCell(0, cell_id).x, transform.position.y, findCell(0, cell_id).z);
                }
            }
            if (setTargetForPlayer)
            {
                goToTarget(target, true, distBlocker);
            }
            else if (setTargetForCell)
            {
                goToTarget(target, false, distThreshold);
            }
            else
            {
                actualMoveSpeed = 0.0f;
                isMoving = false;
            }
        }
    }

    private Vector3 findCell (int floor, int cell_id)
    {
        string floorString = convertNumberToString(floor);
        string cell_idString = convertNumberToString(cell_id);
        GameObject cellPref = GameObject.Find("Cell_" + floorString + "_" + cell_idString);
        Transform frontOfCell = cellPref.transform.Find("PositionPoint_Front");
        Transform centerOfCell = cellPref.transform.Find("PositionPoint_Center");
        return frontOfCell.position;
    }

    private string convertNumberToString(int num)
    {
        if (num < 10)
        {
            return  ("0" + num);
        }
        else
        {
            return num.ToString();
        }
    }

    private void goToTarget(Vector3 pos, bool targetCanMove, float distanceToBlock)
    {
        if (targetCanMove)
        {
            target = new Vector3(player.position.x, transform.position.y, player.position.z);
        }

        distToTarget = Vector3.Distance(transform.position, target);
        if (distToTarget < distanceToBlock)
        {
            actualMoveSpeed = 0.0f;
            isMoving = false;
        }
        else
        {
            actualMoveSpeed = moveSpeed;
            isMoving = true;
        }
                
        RotateToTarget(target);
    }

    private void RotateToTarget(Vector3 t)
    {
        Quaternion rotation = Quaternion.LookRotation(t - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
    }

    private void Animation()
    {
        if(animator != null)
        {
            animator.SetFloat("speed", actualMoveSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PrisonerEnemy otherPrisoner = other.GetComponent<PrisonerEnemy>();
        if (otherPrisoner != null)
        {
            SolvePrisonersCollision(otherPrisoner);
        }
    }

    private void SolvePrisonersCollision(PrisonerEnemy p)
    {
        if((p.cell_id > cell_id) && p.isMoving)
        {
            isWaitingForMove = true;
            actualMoveSpeed = 0.0f;
            isMoving = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PrisonerEnemy otherPrisoner = other.GetComponent<PrisonerEnemy>();
        if (otherPrisoner != null)
        {
            isWaitingForMove = false;
        }
    }
}
