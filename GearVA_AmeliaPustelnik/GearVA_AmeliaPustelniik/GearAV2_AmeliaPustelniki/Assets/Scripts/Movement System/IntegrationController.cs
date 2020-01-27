using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;


/***
* Kontroller wywołania akcji na otrzymaniu zdarzenia przyciśnięcia przycisku interakcji 
*
* plik utworzony dnia 2015.11.03
* przez Artur "Laska" Loska
*/
public class IntegrationController: MonoBehaviour {
	#region Parameters
	
	

	
	#endregion
	
	
	#region Fields
	[SerializeField]
	UnityEvent m_MyClick;

	#endregion
	
	#region Properties
	

	
	#endregion
	
	
	
	#region Unity Flow Events
	
	
	protected virtual void Start()
	{

	}
	
	protected virtual void Update()
	{

 	}
	
	#endregion
	
	
	#region API - Public Methods
	
	public void MyPointerEnter ()
	{  

		LoadingCircleController.Instance.LoadingCircle.gameObject.SetActive (true);
		
	}
	
	public void MyPointerLeave ()
	{ 
		LoadingCircleController.Instance.LoadingCircle.gameObject.SetActive (false);
	}
	
	public void MyClick (GameObject obj) 
	{
		m_MyClick.Invoke();
		
	}
	
	#endregion
	
	
	#region Internal Methods
	
	#endregion
	
	#region Nested Types
	


	#endregion
}
