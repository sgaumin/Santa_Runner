using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChunkGenerator : MonoBehaviour
{
	private enum GeneratorState
	{
		Activated,
		Deactivated
	}

	public static BuildingChunkGenerator Instance { get; private set; }

	[Header("Parameters")]
	[SerializeField] private float startChunckMovementSpeed = 1f;
	[SerializeField] private float durationBeforeStoping = 1f;

	[Header("References")]
	[SerializeField] private Transform spawner;
	[SerializeField] private BuildingChunk[] chuncks;

	private GeneratorState state;

	public float ChunckMovementSpeed { get; private set; }

	protected void Awake() => Instance = this;

	private void Start()
	{
		Game.Instance.OnStartGame += Init;
		Game.Instance.OnStartGame += SpawnChunk;

		Game.Instance.OnGameOver += StopGeneration;
	}

	private void Init()
	{
		state = GeneratorState.Activated;
		ChunckMovementSpeed = startChunckMovementSpeed;
	}

	public void SpawnChunk()
	{
		if (state == GeneratorState.Activated)
		{
			Instantiate(chuncks[Random.Range(0, chuncks.Length)], spawner);
		}
	}

	public void StopGeneration()
	{
		state = GeneratorState.Deactivated;
		DOTween.To(() => ChunckMovementSpeed, x => ChunckMovementSpeed = x, 0f, durationBeforeStoping).SetEase(Ease.InOutSine).Play();
	}

	private void OnDestroy()
	{
		Game.Instance.OnStartGame -= Init;
		Game.Instance.OnStartGame -= SpawnChunk;

		Game.Instance.OnGameOver -= StopGeneration;
	}
}
