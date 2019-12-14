using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChunckGenerator : MonoBehaviour
{
	public static BuildingChunckGenerator Instance { get; private set; }

	[Header("Parameters")]
	[SerializeField] private float chunckMovementSpeed = 1f;

	[Header("References")]
	[SerializeField] private Transform spawner;
	[SerializeField] private BuildingChunck[] chuncks;

	public float ChunckMovementSpeed => chunckMovementSpeed;

	protected void Awake() => Instance = this;

	private void Start() => SpawnChunck();

	public void SpawnChunck() => Instantiate(chuncks[Random.Range(0, chuncks.Length)], spawner);
}
