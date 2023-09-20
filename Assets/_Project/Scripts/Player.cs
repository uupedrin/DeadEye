using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private GameObject line;
	[SerializeField]
	private Transform canon;
	// Start is called before the first frame update
	void Start()
	{
		line = GetComponentInChildren<ParticleSystem>().gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		PlayerInput();
	}
	
	void PlayerInput()
	{
		if(Input.touchCount > 0)
		{
			Touch firstTouch = Input.GetTouch(0);
			
			if(firstTouch.phase == TouchPhase.Began)
			{
				line.SetActive(true);
			}
			
			if(firstTouch.phase == TouchPhase.Moved)
			{
				Vector3 target = Camera.main.ScreenToWorldPoint(transform.position - new Vector3(firstTouch.position.x, firstTouch.position.y, 0));
				Vector3 lookPoint = new Vector3(target.x,target.y,transform.position.z);
				canon.transform.LookAt(lookPoint);
			}
			
			if(firstTouch.phase == TouchPhase.Ended)
			{
				line.SetActive(false);
			}
			
		}
	}
}
