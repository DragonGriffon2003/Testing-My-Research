using UnityEngine;
using TMPro;

public class ScreenController : MonoBehaviour
{
	//have to input the three screens for a quiz
	public GameObject startScreen;
	public GameObject gameScreen;
	public GameObject endScreen;
	public Animator obstaclesAnimator;
	public GameController gameManager;
	//Sets all the screens off in the start of the game
	private void Start()
	{
		startScreen.SetActive(false);
		gameScreen.SetActive(false);
		endScreen.SetActive(false);
	}

	public void SetStartActive()
	{
		startScreen.SetActive(true);
		gameScreen.SetActive(false);
		endScreen.SetActive(false);
	}

	public void CloseGame()
	{
		startScreen.SetActive(false);
		gameScreen.SetActive(false);
		endScreen.SetActive(false);
		if (gameManager.passedStage == true)
		{
			obstaclesAnimator.SetInteger("Stage", 3);
		}
		else
		{
			obstaclesAnimator.SetInteger("Stage", 1);
		}
	}

	public void SetGameActive()
	{
		startScreen.SetActive(false);
		gameScreen.SetActive(true);
		endScreen.SetActive(false);
	}
	
	public void SetEndActive()
	{
		startScreen.SetActive(false);
		gameScreen.SetActive(false);
		endScreen.SetActive(true);
	}
}
