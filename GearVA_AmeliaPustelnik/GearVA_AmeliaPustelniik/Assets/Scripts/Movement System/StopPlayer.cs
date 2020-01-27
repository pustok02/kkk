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
* plik utworzony dnia 2016.02.26
* przez Artur 'Laska'
*/
public class StopPlayer: MonoBehaviour {
	#region Parameters

	#endregion


	#region Fields

	[SerializeField] GameObject m_KinectSetup;

	#endregion



	#region Properties


	#endregion



	#region Unity Flow Events

	protected virtual void Awake()
	{
	}
	
	protected virtual void Start()
	{
	}

	#endregion



	#region API - Public Methods

	#endregion




	#region Internal Methods

	void OnTriggerEnter(Collider Player)
	{
		Player.GetComponent<PlayerAvatarFPP> ().MovementSpeed = 0;
		m_KinectSetup.SetActive (true);
	}

	#endregion



	#region Nested Types

	#endregion
}