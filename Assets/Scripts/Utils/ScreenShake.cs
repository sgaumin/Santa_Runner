using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
	public void Shake(float amplitude, float shakeDuration)
		=> StartCoroutine(shakeTheCamera(amplitude, shakeDuration));

	private IEnumerator shakeTheCamera(float amplitude, float shakeDuration)
	{
		Vector3 originalPos = Camera.main.transform.position;
		float elapsed = 0.0f;
		while (elapsed < shakeDuration)
		{
			float x = Random.Range(-amplitude, amplitude);
			float y = Random.Range(-amplitude, amplitude);

			Camera.main.transform.position = new Vector3(x, y, originalPos.z);

			elapsed += Time.deltaTime;
			yield return null;
		}

		Camera.main.transform.position = originalPos;
	}
}
