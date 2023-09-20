using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnimator : MonoBehaviour
{
	[SerializeField]
	private float scrollX;
	[SerializeField]
	private float scrollY;
	[SerializeField]
	private float scrollSpeed;
	
	private Material material;
	
	void Start()
	{
		material = GetComponent<Renderer>().material;
	}

	void Update()
	{
		Vector2 Offset = new Vector2(scrollX, scrollY) * Time.deltaTime * scrollSpeed;
		material.mainTextureOffset += Offset;
	}
}
