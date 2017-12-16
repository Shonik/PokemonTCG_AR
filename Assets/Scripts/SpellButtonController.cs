using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellButtonController : MonoBehaviour {

	Button button;
	PokemonEventHandler pokemonEventHandler;

	public Spell.Type type;
	public int damage;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		button.onClick.AddListener (OnClick);

		pokemonEventHandler = GameObject.Find ("PokemonEvent").GetComponent<PokemonEventHandler> ();
	}

	void OnClick()
	{
		pokemonEventHandler.SpellButtonClicked (type, damage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
