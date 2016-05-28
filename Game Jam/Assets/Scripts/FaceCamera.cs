using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour
{
	public Camera camera;

	void Start()
	{
		camera = Camera.main;
	}

	void Update ()
	{
		transform.LookAt (transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
	}
}