using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private GameObject presentPrefab;
    [SerializeField] private GameObject hitPlane;
    [SerializeField] private float presentSpeed;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.gameObject == hitPlane) {
                    Vector3 finalClickPos = hit.point;
                    // Debug.Log("finalClickPos " + finalClickPos);
                    GameObject present = Instantiate(presentPrefab, transform.position, Quaternion.LookRotation(finalClickPos));
                    present.GetComponent<Rigidbody>().AddForce((finalClickPos - present.transform.position) * presentSpeed);
                }
            }
        }
    }
}
