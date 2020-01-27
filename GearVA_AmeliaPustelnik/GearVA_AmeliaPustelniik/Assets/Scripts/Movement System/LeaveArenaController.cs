using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;


/***
* Komponent
*
* plik utworzony dnia 2015.09.xx
* przez Artur "Laska" Loska
*/

public class LeaveArenaController: MonoBehaviour {
	#region Parameters

	#endregion
	
	#region Fields

	bool m_IsPlayerInPetTriggerArea;

	[SerializeField] GameObject m_InteractionMenuObject;

	[SerializeField] GameObject m_Kinect;

	[SerializeField] GameObject m_Padle;

	[SerializeField] GameObject m_PingPong;


	Test_SpeedUp m_PlayerAvatarScript;

	#endregion

	#region Properties


	#endregion
	
	#region Unity Flow Events

	protected virtual void Awake() {
		
	}
	
	protected virtual void Start() {
		
	}

	protected virtual void Update() {
		if(m_InteractionMenuObject == null)
		{
			return;
		}
		
		if(m_IsPlayerInPetTriggerArea == true && MoveCharacter.Instance.StateOfCharacterMove == MoveCharacter.StateOfCharacterControllerMovement.CharacterControllerStay)
		{
			m_InteractionMenuObject.SetActive(true);

		}
		else
		{
			m_InteractionMenuObject.SetActive(false);
			if (m_IsPlayerInPetTriggerArea == true) {
				LoadingCircleController.Instance.LoadingCircle.gameObject.SetActive (false);
			}
		
		}


	}

	#endregion



	#region API - Public Methods

	public void PlayerOnTriggerArea(bool PlayerOnTriggerArea) {
		if (PlayerOnTriggerArea) {
			m_PlayerAvatarScript = FindObjectOfType<Test_SpeedUp> ();
			m_IsPlayerInPetTriggerArea = PlayerOnTriggerArea;
			m_PlayerAvatarScript.AllowMovement = false;
			MoveCharacter.Instance.StateOfCharacterMove = MoveCharacter.StateOfCharacterControllerMovement.CharacterControllerStay;	
			m_Kinect.SetActive (true);
			m_Padle.SetActive (true);
			m_PingPong.SetActive (true);
		} else {
			m_PlayerAvatarScript = FindObjectOfType<Test_SpeedUp> ();
			m_IsPlayerInPetTriggerArea = PlayerOnTriggerArea;

			m_PlayerAvatarScript.AllowMovement = true;
			MoveCharacter.Instance.StateOfCharacterMove = MoveCharacter.StateOfCharacterControllerMovement.CharacterConstantMovement;
			LoadingCircleController.Instance.LoadingCircle.gameObject.SetActive (false);
			m_Kinect.SetActive (false);
			m_Padle.SetActive (false);
			m_PingPong.SetActive (false);

		}

	}

	#endregion




	#region Internal Methods

	#endregion



	#region Nested Types

	#endregion
}