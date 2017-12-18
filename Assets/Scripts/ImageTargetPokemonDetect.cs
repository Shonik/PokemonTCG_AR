

using UnityEngine;

namespace Vuforia
{

	public class ImageTargetPokemonDetect : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;
		private PokemonEventHandler pokemonEventHandler;

		#endregion // PRIVATE_MEMBER_VARIABLES

		#region PUBLIC_MEMBER_VARIABLES

		public string pokemonName;

		#endregion // PUBLIC_MEMBER_VARIABLES



		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
			//pokemonEventHandler = GetComponent<PokemonEventHandler> ();
			pokemonEventHandler = GameObject.Find("PokemonEvent").GetComponent<PokemonEventHandler>();
		}

		#endregion // UNTIY_MONOBEHAVIOUR_METHODS



		#region PUBLIC_METHODS


		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}

		public void Update()
		{
			if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
			{
				Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				RaycastHit raycastHit;
				if (Physics.Raycast(raycast, out raycastHit))
				{
					
					if (raycastHit.collider.name == "ImageTargetChenipan")
					{
						pokemonEventHandler.PokemonTouched ("Chenipan");
					}
					else if (raycastHit.collider.name == "ImageTargetPtitard")
					{
						pokemonEventHandler.PokemonTouched ("Ptitard");
					}
					else if (raycastHit.collider.name == "ImageTargetVoltorbe")
					{
						pokemonEventHandler.PokemonTouched ("Voltorbe");
					}
					else if (raycastHit.collider.name == "ImageTargetFantominus")
					{
						pokemonEventHandler.PokemonTouched ("Fantominus");
					}
				}
			}
		}

		#endregion // PUBLIC_METHODS



		#region PRIVATE_METHODS


		private void OnTrackingFound()
		{
			if (pokemonEventHandler)
			{
				pokemonEventHandler.PokemonDetected(pokemonName);
			}

		}


		private void OnTrackingLost()
		{
			
		}

		#endregion // PRIVATE_METHODS
	}
}
