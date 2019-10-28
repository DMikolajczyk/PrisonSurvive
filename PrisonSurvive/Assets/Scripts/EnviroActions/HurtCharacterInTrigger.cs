using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtCharacterInTrigger : MonoBehaviour
{
    [SerializeField]
    private float damage = 1.0f;
    [SerializeField]
    private float timeStep = 1.0f;

    private Prisoner stats = null;
    private float timer = 0;

    private void Start()
    {
        timer = timeStep;
    }

    private void OnTriggerEnter(Collider other)
    {
        stats = other.GetComponent<Prisoner>();
        stats.SetIsHurting(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if((stats != null) && (timer > timeStep))
        {
            stats.ReduceHealth(damage);
            timer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        stats.SetIsHurting(false);
        stats = null;
    }

}
