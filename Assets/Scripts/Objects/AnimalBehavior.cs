using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalBehavior : MonoBehaviour
{
    [SerializeField] private float minChangeTimeSeconds = 5f;
    [SerializeField] private float maxChangeTimeSeconds = 20f;

    private NavMeshAgent agent;
    private SphereCollider walkBoundCollider;
    private float randomChangeWait;
    private float lastChangeTime;

    private void SetWalkDestination()
    {
        randomChangeWait = Random.Range(minChangeTimeSeconds, maxChangeTimeSeconds);
        lastChangeTime = Time.time;

        // Select a location within the walkable zone and go there
        Vector3 newLoc = new Vector3(Random.Range(walkBoundCollider.bounds.min.x, walkBoundCollider.bounds.max.x), 0, 
            Random.Range(walkBoundCollider.bounds.min.z, walkBoundCollider.bounds.max.z));

        agent.SetDestination(newLoc);
    }

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //Debug.Log("Start" + this.transform.position);
        // Use collider for easy visualization
        walkBoundCollider = this.GetComponentInParent<SphereCollider>();

        SetWalkDestination();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.position);
        // Do this every so often, allows for mid-path changes and stalling at a location
        if ((Time.time - lastChangeTime) > randomChangeWait)
        {
            SetWalkDestination();
        }

        /* Testing with manual walk locations
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        */
    }
}
