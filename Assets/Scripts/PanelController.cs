using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {

	Text text;
	Button button;
	PokemonEventHandler pokemonEventHandler;
	int turn;
	public string activePlayer;
	public string enemyPlayer;
	string displayName;
	Color textColor;
	Color enemyTextColor;

	[HideInInspector]
	public bool setupGame = true;
	public bool welcomeState = true;
	public bool beginGame = false;
	public bool showPokemon = false;
	public static bool waitingForActivePokemonP1 = false;
	public static bool askForActivePokemonP2 = false;
	public static bool waitingForActivePokemonP2 = false;
	public static bool askForBancPokemonP1 = false;
	public static bool waitingForBancPokemonP1 = false;
	public static bool askForBancPokemonP2 = false;
	public static bool waitingForBancPokemonP2 = false;
	public static bool askForRewardCards = false;
	public static bool waitingForRewardCards = false;

	public static bool askForPickCard = true;
	public static bool selectAction = false;
	public static bool waitingForSelectAction = false;
	public static bool addingBancPoke = false;
	public static bool selectingPokemonForEnergy = false;
	public static bool selectingEnergy = false;
	public static bool askForAttacking = false;
	public static bool selectingCapacity = false;
	public static bool changingTurn = false;
	public static bool activePokemonDead = false;
	public static int nbPokemonDead = 0;

	public static bool askForNewActivePokemon = true;
	public static bool waitForNewActivePokemon = false;

	public static bool gameFinished = false;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
		button = GetComponentInChildren<Button> ();
		button.onClick.AddListener (changeText);
		pokemonEventHandler = GameObject.Find ("PokemonEvent").GetComponent<PokemonEventHandler> ();
		turn = 1;
		activePlayer = "Player1";
		enemyPlayer = "Player2";
		displayName = "Joueur 1";
		textColor = Color.blue;
	}

	public void changeText()
	{
		if (setupGame)
		{
			SettingUpGame ();
		}
		else if (gameFinished || nbPokemonDead == 6)
		{
			FinishGame ();
		}
		else if (activePokemonDead)
		{
			ChangeActivePokemon ();
		}
		else 
		{
			GameTurn ();
		}
	}

	void SettingUpGame()
	{
		if (welcomeState)
		{
			welcomeState = false;
			text.text = "Nous allons commencer une partie.";
			beginGame = true;
		}
		else if (beginGame)
		{
			beginGame = false;
			text.text = "Tout d'abord mélangez votre deck et piochez les 7 cartes du dessus.";
			showPokemon = true;
		}
		else if (showPokemon)
		{
			showPokemon = false;
			text.color = Color.blue;
			text.text = "Joueur 1 : présentez votre Pokemon actif. Si vous n'en avez pas, repiochez.";
			waitingForActivePokemonP1 = true;
		}
		else if (waitingForActivePokemonP1)
		{
			gameObject.SetActive (false);
		}
		else if (askForActivePokemonP2)
		{	
			askForActivePokemonP2 = false;
			text.color = Color.red;
			text.text = "Joueur 2 : présentez votre Pokemon actif. Si vous n'en avez pas, repiochez.";
			waitingForActivePokemonP2 = true;
		}
		else if (waitingForActivePokemonP2)
		{
			gameObject.SetActive (false);
		}
		else if (askForBancPokemonP1)
		{
			askForBancPokemonP1 = false;
			text.color = Color.blue;
			text.text = "Joueur 1 : présentez vos Pokemons de banc et appuyer sur Terminer.";
			waitingForBancPokemonP1 = true;
		}
		else if (waitingForBancPokemonP1)
		{
			gameObject.SetActive (false);
			pokemonEventHandler.ShowFinishButton ();
		}
		else if (askForBancPokemonP2)
		{
			askForBancPokemonP2 = false;
			text.color = Color.red;
			text.text = "Joueur 2 : présentez vos Pokemons de banc et appuyer sur Terminer.";
			waitingForBancPokemonP2 = true;
		}
		else if (waitingForBancPokemonP2)
		{
			gameObject.SetActive (false);
			pokemonEventHandler.ShowFinishButton ();
		}
		else if (askForRewardCards)
		{
			askForRewardCards = false;
			setupGame = false;
			text.color = Color.black;
			text.text = "Piochez les 6 cartes du dessus de votre deck et placez les en tant que cartes recompenses face cachée.";
			waitingForRewardCards = true;
		}
		else if (waitingForRewardCards)
		{
			changeText ();
		}
	}

	void ChangeActivePokemon()
	{
		if (askForNewActivePokemon)
		{
			gameObject.SetActive (true);
			askForNewActivePokemon = false;
			text.color = enemyTextColor;
			text.text = enemyPlayer + " : selectionnez un de vos Pokemon de banc pour en faire votre Pokemon actif.";
			waitForNewActivePokemon = true;
		}
		else if (waitForNewActivePokemon)
		{
			gameObject.SetActive (false);
			pokemonEventHandler.WaitForNewActivePokemon ();
		}
	}

	void FinishGame()
	{
		gameObject.SetActive (true);
		text.color = textColor;
		text.text = displayName + " : vous remportez la partie !";
	}

	void GameTurn()
	{
		activePlayer = turn == 1 ? "Player1" : "Player2";
		enemyPlayer = turn == 1 ? "Player2" : "Player1";
		displayName = turn == 1 ? "Joueur 1" : "Joueur 2";
		textColor = turn == 1 ? Color.blue : Color.red;
		enemyTextColor = turn == 1 ? Color.red : Color.blue;


		if (askForPickCard)
		{
			gameObject.SetActive (true);
			askForPickCard = false;
			text.color = textColor;
			text.text = displayName + " : piochez une carte et placez la dans votre main.";
			selectAction = true;
		}
		else if (selectAction)
		{
			selectAction = false;
			text.color = textColor;
			text.text = displayName + " : selectionnez une action à effectuer.";
			waitingForSelectAction = true;
		}
		else if (waitingForSelectAction)
		{
			gameObject.SetActive (false);
			pokemonEventHandler.ShowPokeBancButton ();
			pokemonEventHandler.ShowEvolPokeButton ();
			pokemonEventHandler.ShowEnergyButton ();
			pokemonEventHandler.ShowTrainerButton ();
			pokemonEventHandler.ShowRetreatButton ();
			pokemonEventHandler.ShowSpecCapButton ();
			pokemonEventHandler.ShowPasserButton ();
		}
		else if (askForAttacking)
		{
			askForAttacking = false;
			text.color = textColor;
			text.text = displayName + " : selectionnez une capacitée pour attaquer.";
			selectingCapacity = true;
		}
		else if (selectingCapacity)
		{
			gameObject.SetActive (false);
			pokemonEventHandler.MakeCapacityAppear ();
		}
		else if (changingTurn)
		{
			turn = turn == 1 ? 2 : 1;
			askForPickCard = true;
			changeText ();
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
