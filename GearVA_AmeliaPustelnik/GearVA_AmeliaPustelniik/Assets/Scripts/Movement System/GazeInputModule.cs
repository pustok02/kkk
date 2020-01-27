// Gaze Input Module by Peter Koch <peterept@gmail.com>
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

// To use:
// 1. Drag onto your EventSystem game object.
// 2. Disable any other Input Modules (eg: StandaloneInputModule & TouchInputModule) as they will fight over selections.
// 3. Make sure your Canvas is in world space and has a GraphicRaycaster (should by default).
// 4. If you have multiple cameras then make sure to drag your VR (center eye) camera into the canvas.
public class GazeInputModule : PointerInputModule {
	public enum Mode {
		Click = 0,
		Gaze }
	;
	public Mode mode;

	[Header("Click Settings")]
	public string
		ClickInputName = "Submit";
	[Header("Gaze Settings")]
	public float
		GazeTimeInSeconds = 2f;

	public RaycastResult CurrentRaycast;

	private PointerEventData pointerEventData;
	private GameObject currentLookAtHandler;
	private float currentLookAtHandlerClickTime;

	private float timeToClick;
	
	/*
	* Ignore layer functionality
	* added by Tomek 'Xaon'
	*/
	#region Parameters
	
	[SerializeField]
	LayerMask
		m_IgnoreLayers;
	
	#endregion

	public LayerMask IgnoreLayers {
		get {
			return m_IgnoreLayers;
		}
	}

	public float ActualTimeForActive {
		get {
			return timeToClick;
		}

	}

	public GameObject CurrentObj {
		get {
			return currentLookAtHandler;
		}
	}

	public override void Process() { 
		HandleLook();
		HandleSelection();

	}

	static public GazeInputModule Instance {
		get {
			if(s_Instance == null)
			{
				s_Instance = new GazeInputModule();
			}
			return s_Instance;
		}
	}

	private static GazeInputModule s_Instance;

	void HandleLook() {
		if(pointerEventData == null)
		{
			pointerEventData = new PointerEventData(eventSystem);
		}
		// fake a pointer always being at the center of the screen
		pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2);
		pointerEventData.delta = Vector2.zero;
		List<RaycastResult> raycastResults = new List<RaycastResult>();
		eventSystem.RaycastAll(pointerEventData, raycastResults);
		CurrentRaycast = pointerEventData.pointerCurrentRaycast = GetNearest(raycastResults);//FindFirstRaycast(raycastResults);
//		CurrentRaycast = pointerEventData.pointerCurrentRaycast = FindFirstRaycast(raycastResults);
		ProcessMove(pointerEventData);
	}
	
	void HandleSelection() {
		if(pointerEventData.pointerEnter != null)
		{
			// if the ui receiver has changed, reset the gaze delay timer
			GameObject handler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(pointerEventData.pointerEnter);
			if(currentLookAtHandler != handler)
			{
				currentLookAtHandler = handler;

				currentLookAtHandlerClickTime = Time.realtimeSinceStartup + GazeTimeInSeconds;

			}

			timeToClick = (currentLookAtHandlerClickTime - Time.realtimeSinceStartup) / GazeTimeInSeconds;
			LoadingCircleController.Instance.SetFillValue(timeToClick);
			// if we have a handler and it's time to click, do it now
			if(currentLookAtHandler != null && 
				(mode == Mode.Gaze && Time.realtimeSinceStartup > currentLookAtHandlerClickTime) || 
				(mode == Mode.Click && Input.GetButtonDown(ClickInputName)))
			{
				if(EventSystem.current.currentSelectedGameObject != null)
				{
					Debug.Log("old" + EventSystem.current.currentSelectedGameObject.name);
					//			ExecuteEvents.ExecuteHierarchy(EventSystem.current.currentSelectedGameObject, pointerEventData, ExecuteEvents.deselectHandler);
				}

				EventSystem.current.SetSelectedGameObject(currentLookAtHandler);

				ExecuteEvents.ExecuteHierarchy(currentLookAtHandler, pointerEventData, ExecuteEvents.pointerClickHandler);
				currentLookAtHandlerClickTime = float.MaxValue;
				ExecuteEvents.ExecuteHierarchy(EventSystem.current.currentSelectedGameObject, pointerEventData, ExecuteEvents.deselectHandler);
			}
		}
		else
		{
			currentLookAtHandler = null;
		}
	}

	//if this doesn't work, blame Tomek
	private RaycastResult GetNearest(List<RaycastResult> candidates) {
//		float minDistance = float.MaxValue;
		RaycastResult result = new RaycastResult();
		
		foreach(var resultCandidate in candidates)
		{
			if(IsInLayerMask(resultCandidate.gameObject, IgnoreLayers) == false)
			{
//				if(resultCandidate.distance < minDistance)
//				{
//					result = resultCandidate;
//					minDistance = resultCandidate.distance;
//				}
				// Odczytując kod źródłowy systemu UI, który jest na GitHubie widać,
				// że FindFirstRaycast zwraca pierwszy RaycastResult z listy,
				// który wskazuje na jakikolwiek GameObject
				if(resultCandidate.gameObject != null)
				{
					result = resultCandidate;
					break;
				}
			}
		}
		
		return result;
	}
	
	//this actually shoul be in static class named Tools, Utils or alike...
	private bool IsInLayerMask(GameObject obj, LayerMask mask) {
		return ((mask.value & (1 << obj.layer)) > 0);
	}
}