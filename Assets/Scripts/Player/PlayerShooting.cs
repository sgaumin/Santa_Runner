using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private GameObject presentPrefab;
    [SerializeField] private GameObject hitPlane;
    [SerializeField] private float presentSpeed;

    int layer_mask;

    void Start()
    {
       layer_mask = LayerMask.GetMask("HitPlane");
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layer_mask).OrderBy(h => h.distance).ToArray();
            Debug.Log("hits:" + hits.Length);
            // Debug.Log("hits:" + hits.Length);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.gameObject == hitPlane)
                {
                    Vector3 finalClickPos = hit.point;
                    // Debug.Log("finalClickPos " + finalClickPos);
                    GameObject present = Instantiate(presentPrefab, transform.position, Quaternion.LookRotation(finalClickPos));
                    present.GetComponent<Rigidbody>().AddForce((finalClickPos - present.transform.position) * presentSpeed);
                }
            }
        }
    }
}
