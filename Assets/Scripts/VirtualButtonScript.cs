using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

	private VirtualButtonBehaviour vbButton;
	private PokemonEventHandler pokemonEventHandler;

	private GameObject vbButtonGo;

	private string pokemonName;

	// Use this for initialization
	void Start () {

		vbButtonGo = GameObject.Find ("VirtualButton");
		vbButtonGo.GetComponent<VirtualButtonAbstractBehaviour> ().RegisterEventHandler (this);
		//vbButton = GetComponentInChildren<VirtualButtonBehaviour> ();
		//vbButton.RegisterEventHandler (this);
		pokemonName = GetComponent<ImageTargetPokemonDetect> ().pokemonName;
		pokemonEventHandler = GameObject.Find ("PokemonEvent").GetComponent<PokemonEventHandler> ();
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		Debug.Log ("Virtuel");
		pokemonEventHandler.VirtualButtonPressed (pokemonName);
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
