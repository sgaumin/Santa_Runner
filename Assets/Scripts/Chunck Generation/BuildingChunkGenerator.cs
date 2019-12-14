using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChunkGenerator : MonoBehaviour
{
	public static BuildingChunkGenerator Instance { get; private set; }

	[Header("Parameters")]
	[SerializeField] private float chunckMovementSpeed = 1f;

    [Header("References")]
    [SerializeField] private Transform spawner;
	[SerializeField] private BuildingChunk[] chuncks;

	public float ChunckMovementSpeed => chunckMovementSpeed;

    protected void Awake() => Instance = this;

	private void Start() => SpawnChunk();

    public void SpawnChunk()
    {
        BuildingChunk newChunk = Instantiate(chuncks[Random.Range(0, chuncks.Length)], spawner);
    }
}
