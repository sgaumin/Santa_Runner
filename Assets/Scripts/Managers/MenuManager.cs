using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public static MenuManager Instance { get; private set; }

	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject gameOverMenu;
	[SerializeField] private GameObject gameUI;

	[SerializeField] public bool movementEnabled { get; set; }

	private void Awake()
	{
		Instance = this;
		updateByGameState();
	}

	private void Update()
	{
		// If the user presses the escape key and is in the play mode Pause
		//if (Input.GetButtonDown("Cancel") && gameManager.GameState == GameStates.Play)
		//{
		//   toState("Pause");
		//}
	}

	public void updateByGameState()
	{
		disableAll();

		if (Game.Instance != null)
		{
			switch (Game.Instance.GameState)
			{
				case Game.GameStates.GameOver:
					toggleGameOverMenu(true);
					break;
				case Game.GameStates.Play:
					togglePlaySceen(true);
					break;
				case Game.GameStates.Pause:
					Time.timeScale = 0;
					togglePauseMenu(true);
					break;
					//case Game.GameStates.MainMenu:
					//default:
					//    toggleMainMenu(true);
					//    break;
			}
		}
	}

	void disableAll()
	{
		// Reset Timescale
		Time.timeScale = 1.0f;
		// Disable Building Generator
		// Disable All Menus
		toggleGameOverMenu(false);
		togglePauseMenu(false);
		//toggleMainMenu(false);
		// Disable Player Movement
		togglePlaySceen(false);
		// Disable Score and Lives UI
	}

	//void toggleMainMenu(bool state){
	//    mainMenu.SetActive(state);
	//}

	void togglePauseMenu(bool state)
	{
		pauseMenu.SetActive(state);
	}

	void toggleGameOverMenu(bool state)
	{
		gameOverMenu.SetActive(state);
	}

	void togglePlaySceen(bool state)
	{
		gameUI.SetActive(state);
		movementEnabled = state;
	}
}
