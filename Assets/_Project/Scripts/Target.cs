using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField]
	private Material[] materials = new Material[2];
	
	[SerializeField]
	private float convertTime;
	private float timer = 0;
	private int score = 200;
	
	private bool isBad;
	
	void Start()
	{
		isBad = Random.Range(0,100) > 60;
		
		if(isBad)
		{
			GetComponent<Renderer>().material = materials[1];
			score *= -1;
		}
		else
		{
			GetComponent<Renderer>().material = materials[0];
		}
	}
	
	void Update()
	{
		if(isBad)
		{
			if(timer >= convertTime)
			{
				score *= -1;
				GetComponent<Renderer>().material = materials[0];
				isBad = false;
			}
			timer += Time.deltaTime;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		switch(other.tag)
		{
			case "Projectile":
				GameManager.Instance.Score = score;
				Destroy(other.gameObject);
				Destroy(gameObject);
				break;
			case "Endpoint":
				GameManager.Instance.EndGame();
				break;
		}
	}
	
	void OnDestroy()
	{
		FindObjectOfType<TargetSpawner>().targets.Remove(gameObject);
	}
}
