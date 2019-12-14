using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
	public void LoadGame() => LevelLoader.LoadNextLevel();
}
