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
* Skrypt poruszający CharacterController
* 
* Umieszczać na obiekcie który zawiera CharacterController
*
*
* plik utworzony dnia 2015.10.03
* przez Artur "Laska"
*/

public class MoveCharacter: MonoBehaviour {
	#region Singleton

	static public MoveCharacter Instance {
		get {
			return s_Instance;
		}
		private set {
			s_Instance = value;
		}
	}


	private static MoveCharacter s_Instance;

	#endregion

	#region Parameters

	[SerializeField] bool m_ConstantMovement;

	#endregion


	#region Fields

	CharacterController m_CharacterController;

	StateOfCharacterControllerMovement m_State;
	Vector3 m_TargetPosition;

	AudioSource m_PlayerAudioSource;

	Vector3 m_MovDiff;
	Vector3 m_MovDir;



	PlayerAvatarFPP m_PlayerAvatar;

	#endregion

	#region Properties

	public StateOfCharacterControllerMovement StateOfCharacterMove {
		get { return m_State; }
		set { m_State = value; }
	}

	PlayerAvatarFPP PlayerAvatar {
		get {
			if(m_PlayerAvatar == null)
			{
				m_PlayerAvatar = GetComponent<PlayerAvatarFPP>();
			}
			return m_PlayerAvatar;
		}
	}

	#endregion


	#region Unity Flow Events

	protected virtual void Awake() {
		if((Instance == null) == false)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}


	protected virtual void Start() {
		m_CharacterController = gameObject.GetComponent<CharacterController>();
		if (m_ConstantMovement == true) {
			m_State = StateOfCharacterControllerMovement.CharacterConstantMovement;
		}
	}



	protected virtual void Update() {
		switch(m_State)
		{
		case StateOfCharacterControllerMovement.CharacterControllerStay:
			break;
		case StateOfCharacterControllerMovement.CharacterControllerMove:
			Move(m_TargetPosition);
			break;
		case StateOfCharacterControllerMovement.CharacterConstantMovement:
			ConstantMove ();
			break;
		default:
			break;
		}
	}

	#endregion


	#region API - Public Methods

	void Move(Vector3 targetPosition) {
		m_MovDiff = targetPosition - transform.position;
		m_MovDir = m_MovDiff.normalized * PlayerAvatar.MovementSpeed * Time.deltaTime;
		if(m_MovDir.sqrMagnitude < m_MovDiff.sqrMagnitude)
		{
			m_CharacterController.Move(m_MovDir);
		}
		else
		{
			m_State = StateOfCharacterControllerMovement.CharacterControllerStay;
		}

	}


	public void MovePlayerToPoint(Vector3 targetPosition) {
		m_State = StateOfCharacterControllerMovement.CharacterControllerMove;
		m_TargetPosition = targetPosition;
	}

	void ConstantMove()
	{
		PlayerAvatar.CharacterControllerComponent.SimpleMove(PlayerAvatar.GetGazeFrontDirection() * PlayerAvatar.MovementSpeed);

	}


	public void StopCharacter() {
		StateOfCharacterMove = StateOfCharacterControllerMovement.CharacterControllerStay;
	}


	#endregion

	#region Internal Methods

	#endregion

	#region Nested Types

	public enum StateOfCharacterControllerMovement {
		CharacterControllerStay,
		CharacterControllerMove,
		CharacterConstantMovement
	}

	#endregion
}