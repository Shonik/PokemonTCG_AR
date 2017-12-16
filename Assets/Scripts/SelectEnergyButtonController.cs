using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEnergyButtonController : MonoBehaviour {

	public Spell.Type type;
	Button button;
	PokemonEventHandler pokemonEventHandler;

	// Use this for initialization
	void Start () {

		button = GetComponent<Button> ();
		button.onClick.AddListener (OnClick);
		pokemonEventHandler = GameObject.Find ("PokemonEvent").GetComponent<PokemonEventHandler> ();
		
	}

	void OnClick()
	{
		pokemonEventHandler.EnergySelected (type);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
