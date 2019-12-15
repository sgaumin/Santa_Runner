using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingChunkGenerator : MonoBehaviour
{
	private enum GeneratorState
	{
		Activated,
		Deactivated
	}

	[System.Serializable]
	private struct DifficultyLadder
	{
		public DifficultyLadderName name;
		public int loopCount;
	}

	public static BuildingChunkGenerator Instance { get; private set; }

	[Header("Parameters")]
	[SerializeField] private float startChunckMovementSpeed = 1f;
	[SerializeField] private float durationBeforeStoping = 1f;
	[SerializeField] private float difficultyFactor = 0.04f;
	[SerializeField] private DifficultyLadder[] difficultyLadder = new DifficultyLadder[3];
	[SerializeField] private int maxLoopSpeed = 4;

	[Header("References")]
	[SerializeField] private Transform spawner;
	[SerializeField] private BuildingChunk[] chuncks;

	private GeneratorState state;
	private int nbLoop;
	private int currentDifficultyLevel;
	private List<BuildingChunk> currentPool = new List<BuildingChunk>();

	public float ChunckMovementSpeed { get; private set; }

	public DifficultyLadderName? CurrentDifficultyLadder { get; private set; } = null;

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
			if (currentDifficultyLevel < difficultyLadder.Length)
			{
				if (nbLoop >= difficultyLadder[currentDifficultyLevel].loopCount &&
					CurrentDifficultyLadder != difficultyLadder[currentDifficultyLevel].name)
				{
					CurrentDifficultyLadder = difficultyLadder[currentDifficultyLevel].name;
					currentDifficultyLevel++;

					BuildingChunk[] currentLevelPool = chuncks.Where(x => x.Difficulty == CurrentDifficultyLadder).ToArray();
					foreach (BuildingChunk building in currentLevelPool)
					{
						currentPool.Add(building);
					}
				}
			}

			Instantiate(currentPool[Random.Range(0, currentPool.Count)], spawner);

			if (nbLoop < maxLoopSpeed)
			{
				ChunckMovementSpeed += Mathf.Log(++nbLoop, 2f) * difficultyFactor;
			}
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
