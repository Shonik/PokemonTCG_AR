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
		list.Add ("Chenipan", chenipan);


		spells = new Spell[1];
		eNeeded = new Spell.Type[2];
		eNeeded [0] = Spell.Type.Water;
		eNeeded [1] = Spell.Type.Water;
		Spell pistoletAO = new Spell ("Pistolet à O", "", eNeeded, 30);
		spells [0] = pistoletAO;
		Pokemon ptitard = new Pokemon ("Ptitard", 60, Spell.Type.Water, spells);
		list.Add ("Ptitard", ptitard);

		spells = new Spell[1];
		eNeeded = new Spell.Type[1];
		eNeeded [0] = Spell.Type.Lightning;
		Spell bouleElek = new Spell ("Boule Elek", "", eNeeded, 10);
		spells [0] = bouleElek;
		Pokemon voltorbe = new Pokemon ("Voltorbe", 60, Spell.Type.Lightning, spells);
		list.Add ("Voltorbe", voltorbe);

		spells = new Spell[1];
		eNeeded = new Spell.Type[1];
		eNeeded [0] = Spell.Type.Psy;
		Spell regardMenancant = new Spell ("Regard Menaçant", "Placez un marqueur de dégats sur l'un des Pokémon de votre adversaire", eNeeded, 10);
		spells [0] = regardMenancant;
		Pokemon fantominus = new Pokemon ("Fantominus", 50, Spell.Type.Psy, spells);
		list.Add ("Fantominus", fantominus);
	}
}
