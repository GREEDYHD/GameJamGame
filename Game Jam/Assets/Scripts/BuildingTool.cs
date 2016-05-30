using UnityEngine;
using System.Collections;

public class BuildingTool : MonoBehaviour {

	public GameObject[] availableBuildings;
	public bool isBuilding = false;
	public bool canBuild = false;
	public int selectedBuilding;
	GameObject ghostBuilding;
	GameObject newBuilding;

	void Start()
	{
		ghostBuilding = null;
	}

	void Update () 
	{
		if (!canBuild && ghostBuilding != null) 
		{
			Color ghostColor = new Color(1,0,0,0.5f);
			ghostBuilding.GetComponent<MeshRenderer> ().material.color = ghostColor;
		}

		if (isBuilding) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				//ghostBuilding.transform.position = hit.point + new Vector3(0f,2.5f,0f);
				ghostBuilding.transform.position = hit.point + new Vector3(0f,0f,0f);
			}

			if(Input.GetKeyDown (KeyCode.Mouse0) && canBuild)
			{
				PlaceBuilding (ghostBuilding.transform.position);
			}

			if(Input.GetKeyDown (KeyCode.Mouse1))
			{
				StopBuilding();
			}
		}
	}

	void SetGhost()
	{
		ghostBuilding = Instantiate(availableBuildings[selectedBuilding],transform.position,Quaternion.identity)as GameObject;
		Color ghostColor = new Color(0,0,1,0.5f);
		ghostBuilding.GetComponent<MeshRenderer> ().material.color = ghostColor;
	}

	public void SelectBuilding(int buildingNumber)
	{
		isBuilding = true;
		Destroy (ghostBuilding);
		selectedBuilding = buildingNumber;
		SetGhost ();
	}

	public void PlaceBuilding(Vector3 placePosition)
	{
		newBuilding = Instantiate (availableBuildings [selectedBuilding], placePosition, Quaternion.identity)as GameObject;
		newBuilding.GetComponent<Building> ().isPlaced = true;
		StopBuilding ();
	}

	public void StopBuilding()
	{
		Destroy (ghostBuilding);
		isBuilding = false;
	}
}
