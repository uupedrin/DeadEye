using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	Rigidbody rb;
	[SerializeField]
	private float projectileSpeed;
	[SerializeField]
	private float projectileDestroyTime;
	
	public Vector3 dir;
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	private void Start()
	{
		rb.AddForce(dir * projectileSpeed, ForceMode.VelocityChange);
		Destroy(gameObject,projectileDestroyTime);
	}
}
