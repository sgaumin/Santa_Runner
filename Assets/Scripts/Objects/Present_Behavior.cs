using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present_Behavior : MonoBehaviour
{
    // Delete self when invisible to clear up memory resources
    private void OnBecameInvisible()
    {
        Debug.Log("Destroying present");
        Destroy(this.gameObject);
    }
}
