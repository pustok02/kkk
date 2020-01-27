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
* Komponent przyspieszajacy gracza 
*
* plik utworzony dnia 2016.02.04
* przez Artur 'Laska'
*/
public class Test_SpeedUp: MonoBehaviour {
	#region Parameters

	#endregion


	#region Fields

	PlayerAvatarFPP m_PlayerAvatarScript;

	float m_StartSpeed;

	[SerializeField] float m_SpeedUpSpeed;

	bool m_AllowMovement;

	#endregion



	#region Properties

	public bool AllowMovement 
	{
		set { m_AllowMovement = value; }
	}


	#endregion



	#region Unity Flow Events

	protected virtual void Update ()
	{
		if (m_AllowMovement) {
			
			if (Input.GetKey (KeyCode.Mouse0)) {
				m_PlayerAvatarScript.MovementSpeed = m_SpeedUpSpeed;
			} else
				m_PlayerAvatarScript.MovementSpeed = m_StartSpeed;

			if (Input.GetKey (KeyCode.Escape)) 
				m_PlayerAvatarScript.MovementSpeed = -m_SpeedUpSpeed;
		}

	}
	
	protected virtual void Start()
	{
		m_PlayerAvatarScript = GetComponent<PlayerAvatarFPP> ();
		m_StartSpeed = m_PlayerAvatarScript.MovementSpeed;
		m_AllowMovement = true;
	}

	#endregion



	#region API - Public Methods

	#endregion




	#region Internal Methods

	#endregion



	#region Nested Types

	#endregion
}