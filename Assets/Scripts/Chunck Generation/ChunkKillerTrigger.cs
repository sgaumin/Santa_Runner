using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkKillerTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("EndChunk"))
		{
			Destroy(other.transform.parent.gameObject);
		}
	}
}
