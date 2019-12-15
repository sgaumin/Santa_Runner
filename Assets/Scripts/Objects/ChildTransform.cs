using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTransform : MonoBehaviour
{
    private void Update()
    {
        Quaternion currentAngles = new Quaternion();
        currentAngles.eulerAngles = new Vector3(-90, transform.rotation.eulerAngles.y, 0);
        transform.rotation = currentAngles;
    }
}
