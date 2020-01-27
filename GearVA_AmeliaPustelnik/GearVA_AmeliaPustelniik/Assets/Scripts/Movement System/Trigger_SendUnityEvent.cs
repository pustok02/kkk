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
* plik utworzony dnia 2015.10.21
* przez Tomek 'Xaon'
*/
public class Trigger_SendUnityEvent: MonoBehaviour {
	#region Parameters
	
	[SerializeField]
	FilterType
		m_FilterBy = FilterType.None;

	[SerializeField]
	string[]
		m_TagFilters = new string[0];
	
	[SerializeField]
	LayerMask
		m_LayerFilter;
		
	[SerializeField]
	UnityEvent
		m_OnTriggerEnter;
	[SerializeField]
	UnityEvent
		m_OnTriggerExit;

	#endregion


	#region Fields

	#endregion



	#region Properties

	public FilterType FilterBy {
		get {
			return m_FilterBy;
		}
	}

	public string[] TagFilters {
		get {
			return m_TagFilters;
		}
	}

	public LayerMask LayerFilter {
		get {
			return m_LayerFilter;
		}
	}

	#endregion



	#region Unity Flow Events
	void OnTriggerEnter(Collider other) {
		if(CanBeTriggeredBy(other.gameObject))
		{
			m_OnTriggerEnter.Invoke();
		}
	}
	
	
	void OnTriggerExit(Collider other) {
		if(CanBeTriggeredBy(other.gameObject))
		{
			m_OnTriggerExit.Invoke();
		}
	}

	#endregion



	#region API - Public Methods

	#endregion




	#region Internal Methods

	bool CanBeTriggeredBy(GameObject other) {
		bool canBeTriggered = false;
		
		switch(FilterBy)
		{
		case FilterType.None:
			canBeTriggered = true;
			break;
		case FilterType.Layer:
			int othersLayerMask = (1 << other.layer);
			if((LayerFilter.value & othersLayerMask) > 0)//bitowe I (AND)
			{
				canBeTriggered = true;
			}
			break;
		case FilterType.Tag:
			foreach(string tag in TagFilters)
			{
				if(tag == other.tag)
				{
					canBeTriggered = true;
					break;
				}
			}
			break;
		}
		
		return canBeTriggered;
	}

	#endregion



	#region Nested Types

	public enum FilterType {
		None,
		Layer,
		Tag
	}

	#endregion
}