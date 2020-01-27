using UnityEngine;
using System.Collections;

public class fps_counte : MonoBehaviour {

	float deltaTime = 0.0f;

	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0, 250, w, h);
		style.alignment = TextAnchor.UpperCenter;
		style.fontSize = h * 10 / 100;
		style.normal.textColor = new Color (215f, 40f, 40f, 0.9f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
	}
}
