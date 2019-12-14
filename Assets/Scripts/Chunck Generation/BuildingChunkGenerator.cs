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
	[SerializeField] private float difficultyFactor = 0.04f;
	[SerializeField] private int[] difficultyLadder = new int[3];

	[Header("References")]
	[SerializeField] private Transform spawner;
	[SerializeField] private BuildingChunk[] chuncks;

	private GeneratorState state;
	private int nbLoop;

	public float ChunckMovementSpeed { get; private set; }

	public int CurrentDifficultyLadder { get; private set; }

	protected void Awake()
	{
		Instance = this;

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

			ChunckMovementSpeed += Mathf.Log(++nbLoop, 2f) * difficultyFactor;
			CurrentDifficultyLadder = nbLoop > difficultyLadder[CurrentDifficultyLadder] ? 1 : 0;
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
