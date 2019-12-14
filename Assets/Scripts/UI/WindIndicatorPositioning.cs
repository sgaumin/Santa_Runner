using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindIndicatorPositioning : MonoBehaviour
{
    [SerializeField] private float screenOffset = 50;

    // Start is called before the first frame update
    void Start()
    {
        // Adjust positioning to upper left on screen
        this.GetComponent<RectTransform>().localPosition = new Vector3(-Screen.width + screenOffset, -screenOffset, 1);
    }
}
