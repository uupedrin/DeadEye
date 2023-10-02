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
	private Text timer;
	private Text score;
	
	// EndGame
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
	}
	
	public void EndSetup()
	{
		int gmScore = GameManager.Instance.Score;
		if(gmScore > 1000)
		{
			gameState.text = "You Win!";
		}
		else
		{
			gameState.text = "You Lose!";
		}
		score.text = gmScore.ToString();
	}
}
