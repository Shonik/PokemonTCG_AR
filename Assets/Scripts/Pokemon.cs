using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon {

	public enum State {Normal, Paralyzed};

	public string name;
	public int lifePoints;
	public Spell.Type type;
	public Spell[] spells;
	public Pokemon.State state;
	public List<Spell.Type> energyAssigned;



	public Pokemon(string p_name, int p_lifePoints, Spell.Type p_type, Spell[] m_spells)
	{
		name = p_name;
		lifePoints = p_lifePoints;
		type = p_type;
		spells = m_spells;

		state = Pokemon.State.Normal;
		energyAssigned = new List<Spell.Type> ();

	}

	public Pokemon Clone()
	{
		return new Pokemon (name, lifePoints, type, spells);
	}

	public void addEnergy(Spell.Type energy)
	{
		energyAssigned.Add (energy);
	}

	public void removeEnergy(Spell.Type energy)
	{
		int index = -1;
		for (int i = 0; i < energyAssigned.Count; ++i)
		{
			if (energyAssigned[i] == energy)
			{
				index = i;
			}
		}

		if (index != -1)
		{
			energyAssigned.RemoveAt (index);
		}
	}

	public Spell[] GetAvailableSpells()
	{
		int nbSpells = 0;
		Spell.Type[] energyNeeded;
		bool found = false;
		int energyFound = 0;

		List<Spell.Type> remainingEnergy = new List<Spell.Type> (energyAssigned);

		for (int i = 0; i < spells.Length; ++i)
		{
			energyNeeded = spells[i].energyNeeded;

			for (int j = 0; j < energyNeeded.Length; ++j)
			{
				for (int k = 0; k < remainingEnergy.Count; ++k)
				{
					if (energyNeeded[j] == remainingEnergy[k])
					{
						found = true;
						remainingEnergy.RemoveAt (k);
					}
				}

				if (found)
				{
					energyFound++;
					found = false;
				}

			}

			if (energyFound == energyNeeded.Length)
			{
				nbSpells++;
			}

		}


		found = false;
		energyFound = 0;
		int index = 0;

		remainingEnergy = new List<Spell.Type> (energyAssigned);

		Spell[] toReturn = new Spell[nbSpells];


		for (int i = 0; i < spells.Length; ++i)
		{
			energyNeeded = spells[i].energyNeeded;

			for (int j = 0; j < energyNeeded.Length; ++j)
			{
				for (int k = 0; k < remainingEnergy.Count; ++k)
				{
					if (energyNeeded[j] == remainingEnergy[k])
					{
						found = true;
						remainingEnergy.RemoveAt (k);
					}
				}

				if (found)
				{
					energyFound++;
					found = false;
				}

			}

			if (energyFound == energyNeeded.Length)
			{
				toReturn [index] = spells [i];
				++index;

			}

			Debug.Log (energyNeeded.Length);
				

		}

		return toReturn;

	}


}
