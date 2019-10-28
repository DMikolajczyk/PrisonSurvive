using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtCharacterInTrigger : MonoBehaviour
{
    [SerializeField]
    private float damage = 1.0f;
    [SerializeField]
    private float timeStep = 1.0f;

    //private Prisoner stats = null;
    private float timer = 0;
    private List<Prisoner> prisoners = new List<Prisoner>();

    private void Start()
    {
        timer = timeStep;
    }

    private void OnTriggerEnter(Collider other)
    {
        Prisoner p = other.GetComponent<Prisoner>();
        if (!prisoners.Contains(p))
        {
            p.SetIsHurting(true);
            prisoners.Add(p);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if((prisoners.Count > 0) && (timer > timeStep))
        {
            foreach(Prisoner p in prisoners)
            {
                p.ReduceHealth(damage);
            }
            timer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Prisoner p = other.GetComponent<Prisoner>();
        if (prisoners.Contains(p))
        {
            p.SetIsHurting(false);
            prisoners.Remove(p);
        }
    }

}
