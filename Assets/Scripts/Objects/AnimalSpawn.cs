using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    [SerializeField] private GameObject to_instantiate;

    private GameObject inst;

    private void Start()
    {
        // Needs to be in start, since NavMesh needs to be set
        inst = Instantiate(to_instantiate, this.transform.parent);
        //Debug.Log(inst.transform.position);

        // Deactivate this spawner after usage
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Destroy(inst);
    }
}
