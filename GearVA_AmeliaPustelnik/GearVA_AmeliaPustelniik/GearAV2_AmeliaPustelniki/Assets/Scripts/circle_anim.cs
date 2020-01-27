using UnityEngine;
using System.Collections;

public class circle_anim : MonoBehaviour {

	public Vector3 center = new Vector3(0, 0, 0);
	public float radiusA = 1;
	public float radiusB = 1;
	public float speed = 1;

	private float angle;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		angle += speed * Time.deltaTime;

		// Calculates position with parametric form, explanation:
		// http://en.wikipedia.org/wiki/Ellipse#Parametric_form_in_canonical_position
		float x = radiusA * Mathf.Cos(angle);
		float y = radiusB * Mathf.Sin(angle);

		transform.position = center + new Vector3(x, y, 0);
	}
}