using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonList {

	public Dictionary<string, Pokemon> list;

	public PokemonList()
	{
		list = new Dictionary<string, Pokemon> ();

		Spell.Type[] eNeeded;
		Spell[] spells;

		eNeeded = new Spell.Type[1];
		eNeeded [0] = Spell.Type.Plant;
		spells = new Spell[1];
		Spell secretion = new Spell ("Sécrétion", "Lancez une pièce. Si c'est face le Pokémon Actif de votre adversaire est maintenant Paralysé.", eNeeded, 10);
		spells [0] = secretion;
		Pokemon chenipan = new Pokemon ("Chenipan", 40, Spell.Type.Plant, spells);
		list.Add ("chenipan", chenipan);


		spells = new Spell[1];
		eNeeded = new Spell.Type[2];
		eNeeded [0] = Spell.Type.Water;
		eNeeded [1] = Spell.Type.Water;
		Spell pistoletAO = new Spell ("Pistolet à O", "", eNeeded, 30);
		spells [0] = pistoletAO;
		Pokemon ptitard = new Pokemon ("Ptitard", 60, Spell.Type.Water, spells);
		list.Add ("ptitard", ptitard);
	}
}
