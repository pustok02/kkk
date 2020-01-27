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
* Komponent definiujący obiekt avatara gracza
*
* plik utworzony dnia 2015.10.19
* przez Tomek 'Xaon'
*/
[RequireComponent(typeof(CharacterController))]
public class PlayerAvatarFPP: MonoBehaviour {
	#region Parameters
	
	[SerializeField]
	Camera
		m_HeadCamera;
		
	[Space(10.0f)]
	[SerializeField]
	float
		m_MovementSpeed = 5.0f;

	#endregion


	#region Fields
	
	CharacterController m_CharacterControllerComponent;

	#endregion



	#region Properties

	public Camera HeadCamera {
		get {
			return m_HeadCamera;
		}
	}

	public float MovementSpeed {
		get { return m_MovementSpeed; }

		set { m_MovementSpeed = value; }
	}

	public CharacterController CharacterControllerComponent {
		get {
			if(m_CharacterControllerComponent == null)
			{
				m_CharacterControllerComponent = GetComponent<CharacterController>();
			}
		
			return m_CharacterControllerComponent;
		}
	}

	#endregion



	#region Unity Flow Events


	#endregion



	#region API - Public Methods

	public Vector3 GetGazeFrontDirection() {
		Vector3 moveForward = HeadCamera.transform.forward;
		moveForward.y = 0.0f;
		moveForward.Normalize();
		
		return moveForward;
	}

	#endregion




	#region Internal Methods

	#endregion



	#region Nested Types

	#endregion
}