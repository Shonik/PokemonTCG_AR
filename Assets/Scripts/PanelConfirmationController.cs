using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelConfirmationController : MonoBehaviour {

	Text text;
	Button[] buttons;
	Button noButton;
	Button yesButton;
	string pokemon;

	public static bool yesButtonPressed;
	public static bool noButtonPressed;

	PokemonEventHandler pokemonEventHandler;

	// Use this for initialization
	void Start () {
		yesButtonPressed = false;
		noButtonPressed = false;
		pokemon = "";
		text = GetComponentInChildren<Text> ();
		buttons = GetComponentsInChildren<Button> ();
		pokemonEventHandler = GameObject.Find ("PokemonEvent").GetComponent<PokemonEventHandler> ();

		foreach (Button b in buttons)
		{
			if (b.name == "YesButton")
			{
				yesButton = b;
			}
			else if (b.name == "NoButton")
			{
				noButton = b;
			}
		}

		noButton.onClick.AddListener (noButtonClick);
		yesButton.onClick.AddListener (yesButtonClick);

		gameObject.SetActive (false);
	}

	void noButtonClick()
	{
		noButtonPressed = true;
		gameObject.SetActive (false);

		if (PanelController.waitingForActivePokemonP1 || PanelController.waitingForActivePokemonP2)
		{
			pokemonEventHandler.AddActivePokemon (pokemon);
		}
		else if (PanelController.waitingForBancPokemonP1 || PanelController.waitingForBancPokemonP2)
		{
			pokemonEventHandler.AddBancPokemon (pokemon);
		}
		else if (PanelController.waitForNewActivePokemon)
		{
			pokemonEventHandler.AddNewActivePokemon (pokemon);
		}
		else if (PanelController.selectingPokemonForEnergy)
		{
			pokemonEventHandler.MakeEnergyButtonsApear (pokemon);
		}
	}

	void yesButtonClick()
	{
		yesButtonPressed = true;
		gameObject.SetActive (false);

		if (PanelController.waitingForActivePokemonP1 || PanelController.waitingForActivePokemonP2)
		{
			pokemonEventHandler.AddActivePokemon (pokemon);
		}
		else if (PanelController.waitingForBancPokemonP1 || PanelController.waitingForBancPokemonP2)
		{
			pokemonEventHandler.AddBancPokemon (pokemon);
		}
		else if (PanelController.waitForNewActivePokemon)
		{
			pokemonEventHandler.AddNewActivePokemon (pokemon);
		}
		else if (PanelController.selectingPokemonForEnergy)
		{
			pokemonEventHandler.MakeEnergyButtonsApear (pokemon);
		}

	}

	public void askForConfirmation(string p)
	{
		yesButtonPressed = false;
		noButtonPressed = false;
		pokemon = p;

		text.text = "Avez vous selectionné : " + pokemon + " ?";
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
