using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCellCenter : MonoBehaviour
{
    private PrisonerEnemy prisoner = null;
    private float dist = 0.6f;

    private void OnTriggerEnter(Collider other)
    {
        prisoner = other.GetComponent<PrisonerEnemy>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (prisoner != null)
        {
            if (Vector3.Distance(transform.position, prisoner.transform.position) < dist)
            {                
                prisoner.TargetSet = false;
            }
        }
    }
}
