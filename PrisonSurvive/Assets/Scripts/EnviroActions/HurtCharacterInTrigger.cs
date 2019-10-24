using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtCharacterInTrigger : MonoBehaviour
{
    [SerializeField]
    private float damage = 1.0f;

    private CharacterStatistics stats = null;

    private void OnTriggerEnter(Collider other)
    {
        stats = other.GetComponent<CharacterStatistics>();
        stats.SetIsHurting(true);
    }

    private void FixedUpdate()
    {
        if(stats != null)
        {
            stats.reduceHealth(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stats.SetIsHurting(false);
        stats = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
