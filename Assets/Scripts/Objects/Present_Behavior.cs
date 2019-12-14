using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present_Behavior : MonoBehaviour
{
    [SerializeField] private int points_increment = 1;
    [SerializeField] private string scoreColliderTag = "Chimney";
    [SerializeField] private GameObject refGM;

    public void SetGM(GameObject rGM)
    {
        refGM = rGM;
    }

    // Delete self when invisible to clear up memory resources
    private void OnBecameInvisible()
    {
        //Debug.Log("Destroying present");
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == scoreColliderTag && refGM != null)
        {
            refGM.GetComponent<MenuManager>().updateScore(points_increment);
            Destroy(this.gameObject);
        }
    }
}
