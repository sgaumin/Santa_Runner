using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Canvas canvas;
    private Vector3 MouseCoords;

    public float MouseSensitivity = 0.1f;

    private void Start()
    {
            Cursor.visible = false;
    }

    void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
        crosshair.transform.position = canvas.transform.TransformPoint(pos);
    }
}
