using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
	public static ScreenShake Instance { get; private set; }

	protected void Awake() => Instance = this;

	public void Shake(float amplitude, float shakeDuration)
		=> StartCoroutine(shakeTheCamera(amplitude, shakeDuration));

	private IEnumerator shakeTheCamera(float amplitude, float shakeDuration)
	{
		Vector3 originalPos = Camera.main.transform.localPosition;
		float elapsed = 0.0f;
		while (elapsed < shakeDuration)
		{
			float x = originalPos.x + Random.Range(-amplitude, amplitude);
			float y = originalPos.y + Random.Range(-amplitude, amplitude);
			float z = originalPos.z + Random.Range(-amplitude, amplitude);

			Camera.main.transform.localPosition = new Vector3(x, y, z);

			elapsed += Time.deltaTime;
			yield return null;
		}

		Camera.main.transform.localPosition = originalPos;
	}
}
