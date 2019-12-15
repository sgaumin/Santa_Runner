using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyBehavior : MonoBehaviour
{
    [SerializeField] private bool useRandom = false; // If true, make held random between 1 and "presentsCap"
    [SerializeField] private bool unlimitedPresents = false;
    [SerializeField] private int presentsCap = 1; // Make 0 to hold unlimited

    private int numPresents;
    private int currentCount;

    // Return true if present was accepted
    public bool AddPresent(int amount)
    {
        bool accepted = (currentCount < numPresents);
        currentCount += amount;

        if (!unlimitedPresents && presentsCap > 0)
        {
            return accepted;
        }

        return true;
    }

    private void Start()
    {
        currentCount = 0;

        numPresents = presentsCap;
        if (useRandom)
        {
            numPresents = Random.Range(1, presentsCap);
        }
    }
}
