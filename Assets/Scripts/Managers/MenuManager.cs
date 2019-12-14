using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject buildingGenerator;

    [SerializeField] public bool movementEnabled { get; set; }

    Game gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.GetComponent<Game>();
        updateByGameState();
    }

    void updateByGameState() {
        updateByGameState(gameManager.GameState);
    }

    private void Update()
    {
        // If the user presses the escape key and is in the play mode Pause
        //if (Input.GetButtonDown("Cancel") && gameManager.GameState == GameStates.Play)
        //{
        //   toState("Pause");
        //}
    }

    public void updateByGameState(Game.GameStates gameState){
        disableAll();
        switch (gameState)
        {
            case Game.GameStates.GameOver:
                toggleGameOverMenu(true);
                break;
            case Game.GameStates.Play:
                gameManager.playerReset();
                togglePlaySceen(true);
                break;
            case Game.GameStates.Pause:
                Time.timeScale = 0;
                togglePauseMenu(true);
                break;
            case Game.GameStates.MainMenu:
            default:
                toggleMainMenu(true);
                break;
        }
    }

    public void toState(string state) {
        this.GetComponent<Game>().GameState = (Game.GameStates)System.Enum.Parse(typeof(Game.GameStates), state);
        updateByGameState();
    }

    public void toState(Game.GameStates state)
    {
        this.GetComponent<Game>().GameState = state;
        updateByGameState();
    }

    void disableAll(){
        // Reset Timescale
        Time.timeScale = 1.0f;
        // Disable Building Generator
        // Disable All Menus
        toggleGameOverMenu(false);
        togglePauseMenu(false);
        toggleMainMenu(false);
        // Disable Player Movement
        togglePlaySceen(false);
        // Disable Score and Lives UI
    }

    void toggleMainMenu(bool state){
        mainMenu.SetActive(state);
    }

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

    public void updateScore(int score)
    {
        gameUI.GetComponent<GUIManager>().updateScore(score);
    }
}
