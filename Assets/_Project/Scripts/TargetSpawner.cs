using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject targetPrefab;
	
	[SerializeField]
	private float verticalTargetOffset;
	[SerializeField]
	private float horizontalTargetOffset;
	[SerializeField]
	private float targetSpawnY;
	private float [] targetScreenCoords = new float[5];
	private Vector3 [] targetXPos = new Vector3[5];
	public List<GameObject> targets = new List<GameObject>();
	
	[SerializeField]
	private float targetSpawnRate;
	private float timer;
	
	private void Start()
	{
		SetupPositionVariables();
		StartCoroutine(SpawnTargets());
	}
	
	private void Update()
	{
		if(GameManager.Instance.UiController.CurrentScene == "Game")
		{
			if(timer >= targetSpawnRate)
			{
				timer = 0f;
				StartCoroutine(SpawnTargets());
			}
			timer += Time.deltaTime;
		}
	}
	
	private void SetupPositionVariables()
	{
		float scrWidth = Screen.width;
		Camera cam = Camera.main;
		
		targetScreenCoords[0] = 0 + horizontalTargetOffset;
		targetScreenCoords[4] = scrWidth - horizontalTargetOffset;
		targetScreenCoords[2] = targetScreenCoords[4] /2f;
		targetScreenCoords[1] = targetScreenCoords[2] / 2f;
		targetScreenCoords[3] = targetScreenCoords[4] - targetScreenCoords[1];
		
		for (int i = 0; i < targetScreenCoords.Length; i++)
		{
			targetXPos[i] = cam.ScreenToWorldPoint(new Vector3(targetScreenCoords[i], 0, cam.nearClipPlane));
		}
	}
	
	private IEnumerator SpawnTargets()
	{
		if(targets.Count > 0)
		{
			//Move current targets down
			for (int i = 0; i < targets.Count; i++)
			{
				targets[i].transform.position += Vector3.down * verticalTargetOffset;
			}
		}
		
		//Spawn new targets
		for (int i = 0; i < 5; i++)
		{
			GameObject target = Instantiate(targetPrefab, new Vector3(targetXPos[i].x, targetSpawnY, 0f), Quaternion.identity);
			targets.Add(target);
		}
		
		yield return null;
	}
}
