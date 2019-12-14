using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckCreationTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("EndChunck"))
		{
			BuildingChunckGenerator.Instance.SpawnChunck();
		}
	}
}
