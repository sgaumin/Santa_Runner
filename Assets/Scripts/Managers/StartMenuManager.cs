using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : GameSystem
{
	private void Start() => FadScreen.Instance.FadIn(Color.black);

	public void LoadGame() => StartCoroutine(LoadGameCore());

	private IEnumerator LoadGameCore()
	{
		yield return FadScreen.Instance.FadOutCore(Color.black);
		LevelLoader.LoadNextLevel();
	}

	protected override void Update()
	{
		base.Update();
	}
}
