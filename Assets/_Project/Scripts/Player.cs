using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private GameObject line;
	[SerializeField]
	private Transform canon;
	
	[Header("Projectile")]
	[SerializeField]
	private Transform projectileSpPoint;
	[SerializeField]
	private GameObject projectilePrefab;
	
	void Start()
	{
		line = GetComponentInChildren<ParticleSystem>().gameObject;
	}

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
				line.layer = LayerMask.NameToLayer("Default");
				LookAtFinger(firstTouch);	
			}
			
			if(firstTouch.phase == TouchPhase.Moved)
			{
				LookAtFinger(firstTouch);	
			}
			
			if(firstTouch.phase == TouchPhase.Ended)
			{
				line.layer = LayerMask.NameToLayer("DottedLine");
				Shoot();
			}
			
		}
	}
	
	void LookAtFinger(Touch touch)
	{
		Vector3 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);
		Vector2 direction = fingerPos - transform.position;
		float angle = Vector2.SignedAngle(Vector2.up, direction);
		transform.eulerAngles = Vector3.forward * angle;
	}
	
	void Shoot()
	{
		GameObject projectile = Instantiate(projectilePrefab, projectileSpPoint.position, Quaternion.identity);
		projectile.GetComponent<Projectile>().dir = projectileSpPoint.up;
	}
}
