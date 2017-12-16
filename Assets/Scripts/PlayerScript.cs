using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public Pokemon activePokemon;
	public List<Pokemon> banc;

	// Use this for initialization
	void Start () {

		banc = new List<Pokemon> ();
		
	}

	public void AddPokemonBancPlayer(Pokemon p)
	{
		banc.Add (p);
	}

	public void RemoveBancPokemon(Pokemon p)
	{
		banc.Remove (p);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
