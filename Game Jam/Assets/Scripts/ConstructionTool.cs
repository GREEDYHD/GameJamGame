using UnityEngine;
using System.Collections;

public class ConstructionTool : MonoBehaviour {

	public GameObject[] availableBuildings;
	public bool isBuilding = false;
	int selctedBuilding = 0;
	GameObject ghostBuilding;
	GameObject newBuilding;
	//LayerMask mask = LayerMask.GetMask("TerrainLayer");
	


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.B)) 
		{
			isBuilding = !isBuilding;
			if(ghostBuilding != null)
			{
				Destroy(ghostBuilding);
			}

			isBuilding = true;
			ghostBuilding = Instantiate(availableBuildings[0], transform.position,Quaternion.identity) as GameObject;
			Color alphaColor = new Color(0,0,1,0.5f);
			ghostBuilding.GetComponent<MeshRenderer>().material.color = alphaColor;
			
		}

		if (isBuilding) 
		{
			if(ghostBuilding != null)
			{
				if(Input.GetKeyDown(KeyCode.Mouse0))
				{
					PlaceBuilding(0,ghostBuilding.transform.position);
				}
			}
		}

		if (isBuilding) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
				{
					ghostBuilding.transform.position = hit.point + new Vector3(0f,2.5f,0f);
				}
		}	
	}

	public void SelectBuilding(int buildingNumber)
	{

	}

	public void PlaceBuilding(int buildingNumber, Vector3 placePosition)
	{
		newBuilding = Instantiate(availableBuildings[buildingNumber], placePosition, Quaternion.identity)as GameObject;
		newBuilding.GetComponent<Building>().isPlaced = true;
	}

}
