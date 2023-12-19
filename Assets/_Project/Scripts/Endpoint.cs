using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Endpoint : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Target"))
		{
			if(GameManager.Instance.Score > 0 )
			{
				GameManager.Instance.Score = 2 * -GameManager.Instance.Score;
			}
			GameManager.Instance.EndGame();
		}
	}
}
