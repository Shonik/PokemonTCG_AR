

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
