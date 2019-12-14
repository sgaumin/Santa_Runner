using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : GameSystem
{
	public delegate void GameEventHandler();
	public event GameEventHandler OnStartGame;
	public event GameEventHandler OnGameOver;

	public static Game Instance { get; private set; }

	private GameStates gameState;

	public GameStates GameState
	{
		get => gameState;
		set
		{
			gameState = value;
			MenuManager.Instance.updateByGameState();

			if (gameState == GameStates.GameOver)
			{
				OnGameOver?.Invoke();
			}
		}
	}

	public enum GameStates
	{
		//MainMenu,
		Play,
		GameOver,
		Pause
	}

	protected override void Awake()
	{
		base.Awake();
		Instance = this;
	}

	protected void Start()
	{
		GameState = GameStates.Play;
		OnStartGame?.Invoke();
	}

	protected override void Update()
	{
		base.Update();
	}

	public void PlayAgain() => LevelLoader.ReloadLevel();

	public void LoadMenu() => LevelLoader.LoadLevelByIndex(0);
}
