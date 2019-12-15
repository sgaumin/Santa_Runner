using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrosshairController : MonoBehaviour
{
	public static CrosshairController Instance { get; private set; }

	[SerializeField] private GameObject crosshair;
	[SerializeField] private Canvas canvas;
	public float MouseSensitivity = 0.1f;

	[Header("Animation Parameters")]
	[SerializeField] private float targetScale = 1.5f;
	[SerializeField] private float animationDuration = 0.02f;

	protected void Awake() => Instance = this;

	private void Start() => Cursor.visible = false;

	void Update()
	{
		Vector2 pos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
		crosshair.transform.position = canvas.transform.TransformPoint(pos);
	}

	public void ClickAnimation()
		=> transform.DOScale(targetScale, animationDuration).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).Play();
}
