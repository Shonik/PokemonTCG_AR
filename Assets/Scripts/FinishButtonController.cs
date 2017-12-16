using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishButtonController : MonoBehaviour {

	Button button;
	PokemonEventHandler pokemonEventHandler;

	// Use this for initialization
	void Start () {

		gameObject.SetActive (false);
		button = GetComponent<Button> ();
		button.onClick.AddListener (OnClick);

		pokemonEventHandler = GameObject.Find ("PokemonEvent").GetComponent<PokemonEventHandler> ();
		
	}

	void OnClick()
	{
		pokemonEventHandler.FinishButtonClicked ();
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
