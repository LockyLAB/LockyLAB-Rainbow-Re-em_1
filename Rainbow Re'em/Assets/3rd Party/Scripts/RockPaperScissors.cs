using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPaperScissors : MonoBehaviour {

	private int playerLives;
	private int enemyLives;
	private int randomNumber;

	public Text gameOutputText;
	public Text playerLifeCounter;
	public Text enemyLifeCounter;

	void Start () {
		playerLives = 3;
		enemyLives = 3;
		SetUpGame ();
	}

	private void DoBattle(int playerChoice,int enemyChoice){
		if (playerChoice == enemyChoice) {
			gameOutputText.text += "\nThe enemy chose the same and you have dawn!";
		} else if (playerChoice == 2 && enemyChoice == 1) {
			gameOutputText.text += "\nThe enemy chose Rock and you have won!";
			enemyLives--;
		} else if (playerChoice == 1 && enemyChoice == 2) {
			gameOutputText.text += "\nThe enemy chose Paper and you have lost!";
			playerLives--;
		} else if (playerChoice == 1 && enemyChoice == 3) {
			gameOutputText.text += "\nThe enemy chose Scissors and you have won!";
			enemyLives--;
		} else if (playerChoice == 2 && enemyChoice == 3) {
			gameOutputText.text += "\nThe enemy chose Scissors and you have lost!";
			playerLives--;
		} else if (playerChoice == 3 && enemyChoice == 1) {
			gameOutputText.text += "\nThe enemy chose Rock and you have lost!";
			playerLives--;
		} else if (playerChoice == 3 && enemyChoice == 2) {
			gameOutputText.text += "\the enemy chose Paper and you have won!";
			enemyLives--;
		}

		gameOutputText.text += "\n\n Choose a move to make: Rock, Paper, Scissors";
		playerLifeCounter.text = playerLives.ToString ();
		enemyLifeCounter.text = enemyLives.ToString ();
	}
		
	private void SetUpGame(){
		gameOutputText.text = "Choose a move to make: Rock, Paper, Scissors";
		playerLifeCounter.text = playerLives.ToString ();
		enemyLifeCounter.text = enemyLives.ToString ();
	}

	public void ClickButton(int buttonClicked){

		randomNumber = Random.Range (1, 4);

		if (buttonClicked == 1) {
			gameOutputText.text = "You chose Rock";
		
		} else if (buttonClicked == 2) {
			gameOutputText.text = "You chose Paper";
		
		} else if (buttonClicked == 3) {
			gameOutputText.text = "You chose Scissors";
		}
		DoBattle (buttonClicked, randomNumber);
	}
}
