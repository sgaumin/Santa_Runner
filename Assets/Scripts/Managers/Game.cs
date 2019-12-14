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
    [SerializeField] private Vector3 playerStartingPos;
    [SerializeField] private GameObject player;

    public static Game Instance { get; private set; }

	public GameStates GameState { get; set; } = GameStates.MainMenu;

    public enum GameStates
    {
        MainMenu,
        Play,
        GameOver,
        Pause
    }

    protected override void Awake()
	{
		base.Awake();
		Instance = this;
	}

	protected void Update()
	{

	}

    public void playerReset()
    {
        // Reset Player Position
        player.transform.position = playerStartingPos;
        // Remove Momentum
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // Delete Existing Present
        GameObject[] presents = GameObject.FindGameObjectsWithTag("Present");
        foreach (GameObject present in presents)
        {
            Destroy(present);
        }
        // TODO: Reset Building Generator
    }
}
