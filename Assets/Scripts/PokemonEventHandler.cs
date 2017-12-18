using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonEventHandler : MonoBehaviour {

	PokemonList pokemonList;
	string selectedPokemonForEnergy;
	public GameObject panel;
	public GameObject panelConfirmation;
	public GameObject buttonFinish;
	public GameObject energyButtonGroup;

	public GameObject buttonPokeBanc;
	public GameObject buttonEvolPoke;
	public GameObject buttonEnergy;
	public GameObject buttonTrainer;
	public GameObject buttonRetreat;
	public GameObject buttonSpecCap;
	public GameObject buttonPasser;

	public GameObject prefabButtonSpell;
	public GameObject spellPanel;
	public List<GameObject> spellList;

	public GameObject chenipanSpell;
	public GameObject ptitardSpell;
	public GameObject voltorbeSpell;
	public GameObject fantominusSpell;

	public void PokemonDetected(string pokemon)
	{
		Debug.Log (pokemon + " detected ! ");


		if ((PanelController.waitingForActivePokemonP1 && !panel.activeSelf) || (PanelController.waitingForActivePokemonP2 && !panel.activeSelf)) 
		{
			panelConfirmation.GetComponent<PanelConfirmationController> ().askForConfirmation (pokemon);
		}
		else if ((PanelController.waitingForBancPokemonP1 && !panel.activeSelf) || (PanelController.waitingForBancPokemonP2 && !panel.activeSelf))
		{
			panelConfirmation.GetComponent<PanelConfirmationController> ().askForConfirmation (pokemon);
		}
		else if (PanelController.addingBancPoke && !panel.activeSelf)
		{
			panelConfirmation.GetComponent<PanelConfirmationController> ().askForConfirmation (pokemon);
		}
	}

	public void AddActivePokemon(string pokemon)
	{
		if (PanelController.waitingForActivePokemonP1)
		{
			if (PanelConfirmationController.yesButtonPressed)
			{
				Pokemon p;
				if (pokemonList.list.TryGetValue(pokemon, out p))
				{
					GameObject.Find ("Player1").GetComponent<PlayerScript> ().activePokemon = p.Clone();
					PanelController.waitingForActivePokemonP1 = false;
					PanelController.askForActivePokemonP2= true;
					panel.GetComponent<PanelController> ().changeText ();
					panel.SetActive (true);

				}
				else
				{
					Debug.Log ("Pas de pokemon correspondant à : " + pokemon + " trouvé !");
				}
			}
			else if (PanelConfirmationController.noButtonPressed)
			{
				panel.SetActive (true);
			}

		}
		else if (PanelController.waitingForActivePokemonP2)
		{
			if (PanelConfirmationController.yesButtonPressed)
			{
				Pokemon p;
				if (pokemonList.list.TryGetValue(pokemon, out p))
				{
					GameObject.Find ("Player2").GetComponent<PlayerScript> ().activePokemon = p.Clone ();
					PanelController.waitingForActivePokemonP2 = false;
					PanelController.askForBancPokemonP1 = true;
					panel.GetComponent<PanelController> ().changeText ();
					panel.SetActive (true);
				}
				else
				{
					Debug.Log ("Pas de pokemon correspondant à : " + pokemon + " trouvé !");
				}	
			}
			else if (PanelConfirmationController.noButtonPressed)
			{
				panel.SetActive (true);
			}
				
		}
	}

	public void AddBancPokemon(string pokemon)
	{
		Debug.Log ("Add banc pokemon" + pokemon);

		// During the beginning phase
		if (PanelController.waitingForBancPokemonP1)
		{

			if (PanelConfirmationController.yesButtonPressed)
			{
				Pokemon p;
				if (pokemonList.list.TryGetValue(pokemon, out p))
				{
					GameObject.Find ("Player1").GetComponent<PlayerScript> ().AddPokemonBancPlayer (p.Clone());
				}
				else
				{
					Debug.Log ("Pas de pokemon correspondant à : " + pokemon + " trouvé !");
				}
			}
			else if (PanelConfirmationController.noButtonPressed)
			{
				panel.SetActive (true);
			}

		}
		else if (PanelController.waitingForBancPokemonP2)
		{

			if (PanelConfirmationController.yesButtonPressed)
			{
				Pokemon p;
				if (pokemonList.list.TryGetValue(pokemon, out p))
				{
					GameObject.Find ("Player2").GetComponent<PlayerScript> ().AddPokemonBancPlayer(p.Clone());
				}
				else
				{
					Debug.Log ("Pas de pokemon correspondant à : " + pokemon + " trouvé !");
				}	
			}
			else if (PanelConfirmationController.noButtonPressed)
			{
				panel.SetActive (true);
			}

		}
		// During a turn
		else if(PanelController.addingBancPoke)
		{
			if (PanelConfirmationController.yesButtonPressed)
			{
				Pokemon p;
				if (pokemonList.list.TryGetValue(pokemon, out p))
				{
					GameObject.Find (panel.GetComponent<PanelController>().activePlayer).GetComponent<PlayerScript> ().AddPokemonBancPlayer(p.Clone());
				}
				else
				{
					Debug.Log ("Pas de pokemon correspondant à : " + pokemon + " trouvé !");
				}	
			}
			else if (PanelConfirmationController.noButtonPressed)
			{
				panel.SetActive (true);
			}
		}
	}

	public void FinishButtonClicked()
	{
		if (PanelController.waitingForBancPokemonP1)
		{
			buttonFinish.SetActive (false);
			PanelController.waitingForBancPokemonP1 = false;
			PanelController.askForBancPokemonP2 = true;
			panel.GetComponent<PanelController> ().changeText ();
			panel.SetActive (true);
		}
		else if (PanelController.waitingForBancPokemonP2)
		{
			buttonFinish.SetActive (false);
			PanelController.waitingForBancPokemonP2 = false;
			PanelController.askForRewardCards = true;
			panel.GetComponent<PanelController> ().changeText ();
			panel.SetActive (true);
		}
		else if (PanelController.addingBancPoke)
		{
			buttonFinish.SetActive (false);
			PanelController.addingBancPoke = false;
			PanelController.askForAttacking = true;
			panel.GetComponent<PanelController> ().changeText ();
			panel.SetActive (true);
		}
	}

	public void PokeBancButtonClicked()
	{
		buttonPokeBanc.SetActive (false);
		buttonEvolPoke.SetActive (false);
		buttonEnergy.SetActive (false);
		buttonTrainer.SetActive (false);
		buttonRetreat.SetActive (false);
		buttonSpecCap.SetActive (false);
		buttonPasser.SetActive (false);

		buttonFinish.SetActive (true);

		PanelController.waitingForSelectAction = false;
		PanelController.addingBancPoke = true;
	}

	public void PasserButtonClicked()
	{
		buttonPokeBanc.SetActive (false);
		buttonEvolPoke.SetActive (false);
		buttonEnergy.SetActive (false);
		buttonTrainer.SetActive (false);
		buttonRetreat.SetActive (false);
		buttonSpecCap.SetActive (false);
		buttonPasser.SetActive (false);

		PanelController.waitingForSelectAction = false;
		PanelController.askForAttacking = true;

		panel.GetComponent<PanelController> ().changeText ();
		panel.SetActive (true);
	}

	public void EnergyButtonClicked()
	{
		buttonPokeBanc.SetActive (false);
		buttonEvolPoke.SetActive (false);
		buttonEnergy.SetActive (false);
		buttonTrainer.SetActive (false);
		buttonRetreat.SetActive (false);
		buttonSpecCap.SetActive (false);
		buttonPasser.SetActive (false);

		PanelController.waitingForSelectAction = false;
		PanelController.selectingPokemonForEnergy = true;
	}

	public void MakeEnergyButtonsApear(string pokemon)
	{
		if (PanelConfirmationController.yesButtonPressed)
		{
			selectedPokemonForEnergy = pokemon;
			energyButtonGroup.SetActive (true);
			PanelController.selectingPokemonForEnergy = false;
			PanelController.selectingEnergy = true;
		}
	}

	public void EnergySelected(Spell.Type type)
	{
		if (GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().activePokemon.name == selectedPokemonForEnergy)
		{
			GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().activePokemon.addEnergy (type);
			PanelController.selectingEnergy = false;
			PanelController.askForAttacking = true;
			energyButtonGroup.SetActive (false);
			panel.GetComponent<PanelController> ().changeText ();
			panel.SetActive (true);
		}
		else
		{
			for (int i = 0; i < GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().banc.Count; ++i)
			{
				if (selectedPokemonForEnergy == GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc[i].name)
				{
					GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().banc [i].addEnergy (type);
					PanelController.selectingEnergy = false;
					PanelController.askForAttacking = true;
					energyButtonGroup.SetActive (false);
					panel.GetComponent<PanelController> ().changeText ();
					panel.SetActive (true);
				}

			}	
		}

	}

	public void ShowFinishButton()
	{
		buttonFinish.SetActive (true);
	}

	public void ShowPokeBancButton()
	{
		buttonPokeBanc.SetActive (true);
	}

	public void ShowEvolPokeButton()
	{
		buttonEvolPoke.SetActive (true);
	}

	public void ShowEnergyButton()
	{
		buttonEnergy.SetActive (true);
	}

	public void ShowTrainerButton()
	{
		buttonTrainer.SetActive (true);
	}

	public void ShowRetreatButton()
	{
		buttonRetreat.SetActive (true);
	}

	public void ShowSpecCapButton()
	{
		buttonSpecCap.SetActive (true);
	}

	public void ShowPasserButton()
	{
		buttonPasser.SetActive (true);
	}

	public void MakeCapacityAppear()
	{

		spellPanel.SetActive (true);

		Spell[] toShow = GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().activePokemon.GetAvailableSpells();

		if (toShow.Length == 0)
		{
			spellPanel.SetActive (false);
			PanelController.selectingCapacity = false;
			PanelController.changingTurn = true;
			panel.GetComponent<PanelController> ().changeText ();	
		}

		for (int i = 0; i < toShow.Length; ++i)
		{
			GameObject goButtonSpell = Instantiate (prefabButtonSpell) as GameObject;
			goButtonSpell.transform.SetParent (spellPanel.transform);
			goButtonSpell.transform.localScale = new Vector3 (1, 1, 1);

			spellList.Add (goButtonSpell);

			Button buttonSpell = goButtonSpell.GetComponent<Button> ();
			buttonSpell.GetComponentInChildren<Text> ().text = toShow [i].name;
			buttonSpell.GetComponent<SpellButtonController>().type = GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().activePokemon.type;
			buttonSpell.GetComponent<SpellButtonController> ().damage = toShow [i].damage;
		}

	}

	public void SpellButtonClicked(Spell.Type m_type, int p_damage)
	{

		GameObject spell;
		switch (m_type)
		{

		case Spell.Type.Plant:
			DestroySpellButtons ();
			spell = chenipanSpell.transform.Find ("WaterShower").gameObject;
			StartCoroutine (Wait (spell));
			GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints -= p_damage;
			if (GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints <= 0)
			{
				PanelController.activePokemonDead = true;
				PanelController.nbPokemonDead++;
			}
			spellPanel.SetActive (false);
			PanelController.selectingCapacity = false;
			PanelController.changingTurn = true;
			panel.GetComponent<PanelController> ().changeText ();
			break;

		case Spell.Type.Water:
			DestroySpellButtons ();
			spell = ptitardSpell.transform.Find ("WaterShower").gameObject;
			StartCoroutine (Wait (spell));
			GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints -= p_damage;
			if (GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints <= 0)
			{
				PanelController.activePokemonDead = true;
				PanelController.nbPokemonDead++;
			}
			spellPanel.SetActive (false);
			PanelController.selectingCapacity = false;
			PanelController.changingTurn = true;
			panel.GetComponent<PanelController> ().changeText ();
			break;

		case Spell.Type.Psy:
			DestroySpellButtons ();
			spell = fantominusSpell.gameObject;
			StartCoroutine (Wait (spell));
			GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints -= p_damage;
			if (GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints <= 0)
			{
				PanelController.activePokemonDead = true;
				PanelController.nbPokemonDead++;
			}
			spellPanel.SetActive (false);
			PanelController.selectingCapacity = false;
			PanelController.changingTurn = true;
			panel.GetComponent<PanelController> ().changeText ();
			break;

		case Spell.Type.Lightning:
			DestroySpellButtons ();
			spell = voltorbeSpell.gameObject;
			StartCoroutine (Wait (spell));
			GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints -= p_damage;
			if (GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().activePokemon.lifePoints <= 0)
			{
				PanelController.activePokemonDead = true;
				PanelController.nbPokemonDead++;
			}
			spellPanel.SetActive (false);
			PanelController.selectingCapacity = false;
			PanelController.changingTurn = true;
			panel.GetComponent<PanelController> ().changeText ();
			break;
		}
	}

	IEnumerator Wait(GameObject spell)
	{
		spell.SetActive (true);
		yield return new WaitForSeconds (1);
		spell.SetActive (false);
	}

	public void DestroySpellButtons()
	{
		foreach(GameObject g in spellList)
		{
			Destroy (g);
		}

		spellList.Clear ();
	}

	public void WaitForNewActivePokemon()
	{
		if (GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc.Count == 0)
		{
			PanelController.gameFinished = true;
			panel.GetComponent<PanelController> ().changeText ();
		}

	}
		
	public void PokemonTouched(string name)
	{
		Debug.Log (name + " touched");
		bool found = false;
		if (PanelController.waitForNewActivePokemon)
		{
			Debug.Log ("Bon etat");
			for (int i = 0; i < GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc.Count; ++i)
			{
				Debug.Log ("Banc : " + GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc [i].name);
				Debug.Log ("Name : " + name);
				if (name == GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc[i].name)
				{
					found = true;
				}
					
			}

			if (found)
			{
				panelConfirmation.GetComponent<PanelConfirmationController> ().askForConfirmation (name);
			}
			else
			{
				PanelController.askForNewActivePokemon = true;
				panel.GetComponent<PanelController> ().changeText ();
			}
		}
		else if (PanelController.selectingPokemonForEnergy)
		{
			for (int i = 0; i < GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().banc.Count; ++i)
			{
				Debug.Log ("Banc : " + GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().banc [i].name);
				Debug.Log ("Name : " + name);
				if (name == GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().banc[i].name)
				{
					found = true;
				}

			}

			if (found || name == GameObject.Find (panel.GetComponent<PanelController> ().activePlayer).GetComponent<PlayerScript> ().activePokemon.name)
			{
				panelConfirmation.GetComponent<PanelConfirmationController> ().askForConfirmation (name);
			}
		}
	}

	public void AddNewActivePokemon(string pokemon)
	{
		if (PanelConfirmationController.yesButtonPressed)
		{
			Pokemon p = null;
			for (int i = 0; i < GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc.Count; ++i)
			{
				if (name == GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc[i].name)
				{
					p = GameObject.Find (panel.GetComponent<PanelController> ().enemyPlayer).GetComponent<PlayerScript> ().banc [i];
				}

			}

			GameObject.Find (panel.GetComponent<PanelController>().enemyPlayer).GetComponent<PlayerScript> ().AddPokemonBancPlayer(p);
			PanelController.waitForNewActivePokemon = false;
			PanelController.activePokemonDead = false;
			PanelController.askForNewActivePokemon = true;
			panel.GetComponent<PanelController> ().changeText ();


		}
		else if (PanelConfirmationController.noButtonPressed)
		{
			panel.GetComponent<PanelController> ().changeText ();
		}
	}

	// Use this for initialization
	void Start () {

		pokemonList = new PokemonList ();

		chenipanSpell.transform.Find ("WaterShower").gameObject.SetActive (false);
		ptitardSpell.transform.Find ("WaterShower").gameObject.SetActive (false);
		fantominusSpell.gameObject.SetActive (false);
		voltorbeSpell.gameObject.SetActive (false);

		spellList = new List<GameObject> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
