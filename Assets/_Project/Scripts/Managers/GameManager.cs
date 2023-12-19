using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private int score = 0;
	
	[SerializeField]
	private float maxTime;
	public float MaxTime
	{
		get{return maxTime;}
	}
	private float timer;
	public float Timer
	{
		get{return timer;}
	}
	public int Score 
	{
		get {return score;}
		set 
		{
			score += value;
			UiController.Score = score;
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
	
	private void Update()
	{
		if(UiController.CurrentScene == "Game")
		{
			if(timer >= maxTime)
			{
				EndGame();
			}
			timer += Time.deltaTime;
			UiController.Timer = (int)(maxTime - timer);
		}
		
	}
	
	public void RestartGame()
	{
		score = 0;
		timer = 0;
	}
	public void EndGame()
	{
		UiController.ChangeScene("EndGame");
	}
}
