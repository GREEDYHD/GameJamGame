using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {

	public Camera mapCamera;

	public float xPos;
	public float yPos;
	public float width;
	public float height;

	// Use this for initialization
	void Start () 
	{
		mapCamera = GetComponent<Camera>();
		mapCamera.pixelRect = new Rect (Screen.width - xPos, Screen.height - yPos, width, height);
	}
	

}
