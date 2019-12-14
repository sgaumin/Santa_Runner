using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
	private void Start() => FadScreen.Instance.FadIn(Color.black);

	public void LoadGame() => StartCoroutine(LoadGameCore());

	private IEnumerator LoadGameCore()
	{
		yield return FadScreen.Instance.FadOutCore(Color.black);
		LevelLoader.LoadNextLevel();
	}
}
