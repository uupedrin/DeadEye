using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	private string currentScene;
	public string CurrentScene 
	{
		get {return currentScene;}
	}
	
	// Game
	[SerializeField]
	private Text timer;
	public int Timer
	{
		get{return int.Parse(timer.text);}
		set
		{
			timer.text = value.ToString();
		}
	}
	[SerializeField]
	private Text score;
	public int Score
	{
		set
		{
			score.text = GameManager.Instance.Score.ToString();
		}
	}
	
	// EndGame
	[SerializeField]
	private Text gameState;
	
	
	private void Start()
	{
		GameManager.Instance.UiController = this;
		SceneContext();
	}
	
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	
	private void SceneContext()
	{
		currentScene = SceneManager.GetActiveScene().name;
		
		if(currentScene == "Game") RestartGame();
		if(currentScene == "EndGame") EndSetup();
	}
	public void RestartGame()
	{
		GameManager.Instance.RestartGame();
		if(currentScene != "Game")
		{
			ChangeScene("Game");
		}
	}
	
	public void EndSetup()
	{
		int gmScore = GameManager.Instance.Score;
		if(gmScore >= 7350)
		{
			gameState.text = "You Win!";
		}
		else
		{
			gameState.text = "You Lose!";
		}
		score.text = gmScore.ToString();
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
