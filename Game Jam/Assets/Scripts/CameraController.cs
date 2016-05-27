using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	Camera myCamera;
	[SerializeField]
	float cameraMoveSpeed;
	[SerializeField]
	float cameraRotationSpeed;
	
	Vector3 defaultControllerPos;
	Vector3 defaultControllerRot;
	float defaultZoom;
	public float focusZoom;

	//Mouse stuff
	private float mouseX;
	private float mouseY;

	//Edge scrolling stuff
	private int screenWidth = Screen.width;
	private int screenHeight = Screen.height;

	//Zoom stuff
	public float cameraSpeed;
	public float cameraZoomSpeed;
	public float cameraZoomIn;
	public float cameraZoomOut;
	

	//Camera border
	public float mapBorderForward = 5f;
	public float mapBorderBack = 5f;
	public float mapBorderLeft = 5f;
	public float mapBorderRight = 5f;


	// Use this for initialization
	void Start () 
	{
		myCamera = GetComponentInChildren<Camera>();
		defaultZoom = Vector3.Distance(transform.position, myCamera.transform.position);
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
			//myCamera.transform.RotateAround(this.transform.position, new Vector3 (0, mouseX, 0), Time.deltaTime * cameraRotationSpeed);
			transform.eulerAngles += new  Vector3 (0, mouseX, 0) * Time.deltaTime * cameraRotationSpeed;
		}

		//Edge scroll right
//		if (Input.mousePosition.x >= screenWidth * 0.02f) 
//		{
//			transform.Translate(Vector3.right * cameraMoveSpeed, Space.World);
//		}
//
//		//Edge scroll left
//		if (Input.mousePosition.x <= screenWidth * 0.98f) 
//		{
//			transform.Translate(Vector3.left * cameraMoveSpeed, Space.World);
//		}
//
//		//Edge scroll up
//		if (Input.mousePosition.y >= screenHeight * 0.02f) 
//		{
//			transform.Translate(Vector3.forward * cameraMoveSpeed, Space.World);
//		}
//
//		//Edge scroll down
//		if (Input.mousePosition.y <= screenHeight * 0.98f) 
//		{
//			transform.Translate(Vector3.back * cameraMoveSpeed, Space.World);
//		}

		//Zoom
		if (Input.GetKey (KeyCode.E)) {

		}

		//Mouse wheel scroll in//
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			Vector3 camDown = transform.position - myCamera.transform.position;// new Vector3(0, 1, 0);
			if(camDown.magnitude > cameraZoomIn)
			{
				myCamera.transform.Translate(camDown.normalized * cameraZoomSpeed * Time.deltaTime, Space.World);
				if (transform.position.y < cameraZoomIn)
				{
					Vector3 camZoomInMax = transform.position;
					camZoomInMax.y = cameraZoomIn;
					//transform.position = camZoomInMax;
				}
			}
		}
		
		//Mouse wheel scroll out//
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			Vector3 camUp = myCamera.transform.position - transform.position;// new Vector3(0, 1, 0);
			if(camUp.magnitude < cameraZoomOut)
			{
				myCamera.transform.Translate(camUp.normalized * cameraZoomSpeed * Time.deltaTime, Space.World);
				if (transform.position.y > cameraZoomOut)
				{
					Vector3 camZoomOutMax = transform.position;
					camZoomOutMax.y = cameraZoomOut;
					//transform.position = camZoomOutMax;
				}
			}
		}

		//Reset camera position
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			transform.localPosition = Vector3.zero;
			transform.eulerAngles = Vector3.zero;
			myCamera.transform.position = transform.position + ((myCamera.transform.position - transform.position).normalized * defaultZoom);
		}
	}

	public void FocusOn(GameObject selectedUnit)
	{
		transform.localPosition = selectedUnit.transform.position;
		myCamera.transform.position = transform.position + ((myCamera.transform.position - transform.position).normalized * focusZoom);
	}
}