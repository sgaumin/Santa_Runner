using System.Collections;
using UnityEngine;

public class PlayerVoice : MonoBehaviour
{
	[SerializeField] private AudioExpress[] voiceSounds;
	[MinMaxSlider(1f, 20f), SerializeField] private MinMax breakDuration = new MinMax(6f, 12f);

	private Coroutine voiceSoundPlaying;

	private void Awake()
	{
		Game.Instance.OnStartGame += PlaySound;
		Game.Instance.OnGameOver += StopSound;
	}

	public void PlaySound() => voiceSoundPlaying = StartCoroutine(PlaySoundCore());

	public void StopSound() => StopCoroutine(voiceSoundPlaying);

	private IEnumerator PlaySoundCore()
	{
		while (true)
		{
			yield return new WaitForSeconds(breakDuration.RandomValue);
			voiceSounds[Random.Range(0, voiceSounds.Length)].Play(gameObject);
		}
	}

	private void OnDestroy()
	{
		Game.Instance.OnStartGame -= PlaySound;
		Game.Instance.OnGameOver -= StopSound;
	}
}
