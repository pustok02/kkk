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
* plik utworzony dnia 2016.02.23
* przez Artur 'Laska'
*/

public class LoadingCircleController: MonoBehaviour {
	
	#region Singleton

	static public LoadingCircleController Instance {
		get {
			return s_Instance;
		}
		private set {
			s_Instance = value;
		}
	}

	private static LoadingCircleController s_Instance;

	#endregion


	#region Fields

	[SerializeField]
	Image
		m_LoadingCircleBar;


	#endregion



	#region Properties

	public Image LoadingCircle {

		get {return m_LoadingCircleBar; }
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

	}

	#endregion



	#region API - Public Methods


	public void SetFillValue(float Size) {
		m_LoadingCircleBar.fillAmount = Size;
	}
	#endregion




	#region Internal Methods

	#endregion



	#region Nested Types

	#endregion
}