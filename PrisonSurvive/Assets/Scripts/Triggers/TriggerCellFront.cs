using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCellFront : MonoBehaviour
{
    [SerializeField]
    private Transform centerOfCell = null;

    private PrisonerEnemy prisoner = null;
    private float dist = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        prisoner = other.GetComponent<PrisonerEnemy>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(prisoner != null)
        {
            if (Vector3.Distance(transform.position, prisoner.transform.position) < dist)
            {
                if((prisoner.GetActionState() == PrisonerEnemy.ActionState.GoingToCell) && (BlockManager.InstanceBM.IsOpen) && BlockManager.InstanceBM.TimeOpen > BlockManager.InstanceBM.GetAnimTime())
                {
                    prisoner.SetTarget(centerOfCell.position);
                }
                else if(!BlockManager.InstanceBM.IsOpen)
                {
                    prisoner.TargetSet = false;
                }                
            }
        }
    }

}
