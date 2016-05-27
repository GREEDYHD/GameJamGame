using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	Camera myCamera;
	[SerializeField]
	float cameraMoveSpeed = 5;
	[SerializeField]
	float cameraRotationSpeed = 500;

	Vector3 defaultCameraPos;
	Vector3 defaultCameraRot;

	//Mouse stuff
	private float mouseX;
	private float mouseY;

	//Edge scrolling stuff
	private int screenWidth = Screen.width;
	private int screenHeight = Screen.height;

	//Zoom stuff
	[SerializeField]
	private float cameraSpeed = 10f;

	[SerializeField]
	private float cameraZoomSpeed = 30f;

	[SerializeField]
	private float cameraZoomIn = 4f;

	[SerializeField]
	private float cameraZoomOut = 10f;

	//Camera border
	public float mapBorderForward = 5f;
	public float mapBorderBack = 5f;
	public float mapBorderLeft = 5f;
	public float mapBorderRight = 5f;

	//

	// Use this for initialization
	void Start () 
	{
		myCamera = GetComponentInChildren<Camera>();
		defaultCameraPos = myCamera.transform.position;
		defaultCameraRot = myCamera.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate(Vector3.forward * cameraMoveSpeed);
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate(Vector3.left * cameraMoveSpeed);
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate(Vector3.back * cameraMoveSpeed);
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate(Vector3.right * cameraMoveSpeed);
		}

		if(Input.GetKey(KeyCode.Mouse1))
		{
			mouseX = Input.GetAxis("Mouse X");
			mouseY = Input.GetAxis("Mouse Y");
			transform.eulerAngles += new Vector3(mouseY, mouseX, 0)* Time.deltaTime * cameraRotationSpeed;
		}

		//Edge scroll right
		if (Input.mousePosition.x >= screenWidth * 0.02f) 
		{
			transform.Translate(Vector3.right * cameraMoveSpeed, Space.World);
		}

		//Edge scroll left
		if (Input.mousePosition.x <= screenWidth * 0.98f) 
		{
			transform.Translate(Vector3.left * cameraMoveSpeed, Space.World);
		}

		//Edge scroll up
		if (Input.mousePosition.y >= screenHeight * 0.02f) 
		{
			transform.Translate(Vector3.forward * cameraMoveSpeed, Space.World);
		}

		//Edge scroll down
		if (Input.mousePosition.y <= screenHeight * 0.98f) 
		{
			transform.Translate(Vector3.back * cameraMoveSpeed, Space.World);
		}


	}
	
}
