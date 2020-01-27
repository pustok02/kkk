using UnityEngine;
using System.Collections;


public class MainObjectController : MonoBehaviour {

	public GameObject player;
	public GameObject MouseManager;
	public GameObject rm4_kolnierz_export;
	public GameObject selectedObject;
	public GameObject selectedObjectturnoff;
	public GameObject Seal;
	public GameObject GUIturnoff;
	public GameObject GUIturnoff2;
	public GameObject Collider;
	public GameObject welding;
	public GameObject GUILookHere;
	public GameObject GUIcollider;
	public Transform target;
	public Animator uszczelka;
	//public GameObject Player;
	public float smoothTime = 0.1F;
	private Vector3 velocity = Vector3.zero;
	public int licznik = 0;


	void Start() {
		

	}


	void Update() {
		if(GUIcollider.active == false)
		{
			StartCoroutine("wait");
		}
		else
		{
		
		}

		/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hitInfo;

		if(Physics.Raycast(ray, out hitInfo))
		{

			GameObject hitObject = hitInfo.transform.root.gameObject;
			if(licznik < 1)
				SelectObject(hitObject);
		}
		*/
	}


	/*
		if(selectedObject != null)
		{
			if(obj == selectedObject)
				return;
		}

		selectedObject = obj;
		if(Seal.GetComponent<BoxCollider>().isTrigger)
		{
			OnMouseDown();
		}
	}


	void OnMouseDown() {
		Debug.Log("Clicked");
		;

	}
	*/

	IEnumerator wait() {
		if(licznik < 16)
		{
			//player.GetComponent<MoveCharacter>().enabled = false;
			//	Vector3 oldpos = transform.position;
			//Vector3 newposition = new Vector3(1, 0, 0);
			Vector3 targetPosition = target.TransformPoint(new Vector3(15, 0, 0));
			GUIturnoff.SetActive(false);
			GUIturnoff2.SetActive(false);
			yield return new WaitForSeconds(1);
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
			licznik++;
			//MouseManager.GetComponent<MouseManager>().enabled = false;
			//ClearSelection();
			yield return new WaitForSeconds(1);
			rm4_kolnierz_export.GetComponent<Animator>().enabled = true;
			yield return new WaitForSeconds(12);
			uszczelka.GetComponent<Animator>().speed = 0;
			selectedObjectturnoff.SetActive(false);
			player.GetComponent<MoveCharacter>().enabled = false;
			player.GetComponent<Test_SpeedUp>().enabled = false;
			player.transform.position = new Vector3(-7.5f, 1.625285f, -1.578326f);
			selectedObject.SetActive(true);
			yield return new WaitForSeconds(3);
			selectedObject.GetComponent<Animation>().Stop();
			selectedObject.GetComponent<RotateObject>().enabled = true;
			yield return new WaitForSeconds(25);
			selectedObject.GetComponent<RotateObject>().enabled = false;
			selectedObject.transform.localRotation = Quaternion.identity;
			selectedObject.GetComponent<Animation>().Play("simpleforwardseal 1");
			yield return new WaitForSeconds((float)2.5);
			selectedObject.SetActive(false);
			selectedObjectturnoff.SetActive(true);
			player.GetComponent<MoveCharacter>().enabled = true;
			player.GetComponent<Test_SpeedUp>().enabled = true;
			uszczelka.GetComponent<Animator>().speed = 1;
			yield return new WaitForSeconds(9.5f);
			uszczelka.GetComponent<Animator>().speed = 0;
			welding.SetActive(true);
			yield return new WaitForSeconds(13);
			welding.SetActive(false);
			uszczelka.GetComponent<Animator>().speed = 1;
			yield return new WaitForSeconds(4.5f);
			rm4_kolnierz_export.GetComponent<Animator>().enabled = false;
			//targetPosition = target.TransformPoint(new Vector3(-4.6f,0,0));
			//transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity, smoothTime);
			transform.position = new Vector3(-13.849f, 3.491f, -1.504f);
			Collider.GetComponent<BoxCollider>().enabled = false;

			//player.GetComponent<MoveCharacter>().enabled = true;
			//}
		}


		/*void ClearSelection() {
		if(selectedObject == null)
			return;

		Renderer[] rs = selectedObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in rs)
		{
			if(selectedObject.name == "pf_SealsConnect")
			{
				Material newMat = Resources.Load("metall", typeof(Material)) as Material;
				r.material = newMat;
			}
		}

	}
	*/
	}
}