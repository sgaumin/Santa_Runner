using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : GameSystem
{
	[SerializeField] private AudioExpress clickSound;

	private void Start() => FadScreen.Instance.FadIn(Color.black);

	public void LoadGame() => StartCoroutine(LoadGameCore());

	private IEnumerator LoadGameCore()
	{
		clickSound.Play(gameObject);
		yield return FadScreen.Instance.FadOutCore(Color.black);
		LevelLoader.LoadNextLevel();
	}

	protected override void Update()
	{
		base.Update();
	}
}
