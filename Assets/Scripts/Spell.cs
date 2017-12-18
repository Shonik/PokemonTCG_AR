using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell {

	public enum Type {Fire, Water, Plant, Neutral, Psy, Lightning};

	public string name;
	public string description;
	public Spell.Type[] energyNeeded;
	public int damage;

	public Spell(string p_name, string p_description, Spell.Type[] p_energyNeeded, int p_damage)
	{
		name = p_name;
		description = p_description;
		energyNeeded = p_energyNeeded;
		damage = p_damage;
	}
}
