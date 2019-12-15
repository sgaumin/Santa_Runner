using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildingChunk : MonoBehaviour
{
    [SerializeField] private bool enableMovement = true;
    [SerializeField] private NavMeshData navMesh;
    [SerializeField] private NavMeshData navMesh_temp;
    [SerializeField] private DifficultyLadderName difficulty;
    public DifficultyLadderName Difficulty => difficulty;

    private NavMeshDataInstance navMeshInst;

    private void Update()
	{
        if (enableMovement)
        {
            Vector3 currentPosition = transform.position;
            Vector3 nextPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - BuildingChunkGenerator.Instance.ChunckMovementSpeed);
            transform.position = nextPosition;
        }

        // Move NavMesh with self
        navMesh_temp.position = this.transform.position;
	}

    private void Awake()
    {
        navMesh_temp = navMesh;
        navMeshInst = NavMesh.AddNavMeshData(navMesh_temp);
    }

    private void OnDestroy()
    {
        NavMesh.RemoveNavMeshData(navMeshInst);
    }
}
