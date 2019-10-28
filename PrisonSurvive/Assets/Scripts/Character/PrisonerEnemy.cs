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
                distBlocker = 5.0f;



    private bool setTargetForPlayer = false;
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
        if(Input.GetKeyUp(KeyCode.P))
        {
            setTargetForPlayer = !setTargetForPlayer;
            if (setTargetForPlayer)
            {
                target = new Vector3(player.position.x, transform.position.y, player.position.z);
            }
        }
        if (setTargetForPlayer)
        {
            goToTarget(target, true);
            //actualMoveSpeed = moveSpeed;
        }
        else
        {
            actualMoveSpeed = 0.0f;
        }
    }

    private void goToTarget(Vector3 pos, bool targetCanMove)
    {
        if (targetCanMove)
        {
            target = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
        distToTarget = Vector3.Distance(transform.position, target);
        if (distToTarget > distBlocker)
        {
            actualMoveSpeed = moveSpeed;
        }
        else
        {
            actualMoveSpeed = 0.0f;
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
}
