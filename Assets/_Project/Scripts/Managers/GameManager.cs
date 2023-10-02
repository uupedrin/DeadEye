using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private int score;
	
	public int Score 
	{
		get {return score;}
		set 
		{
			score += value;
		}
	}
	public UIController UiController;
	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		
	}
	public void RestartGame()
	{
		score = 0;
	}
	public void GameOver()
	{
		UiController.ChangeScene("EndGame");
	}
}
