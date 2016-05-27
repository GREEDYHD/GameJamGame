using UnityEngine;
using System.Collections;

public class Building : BaseObject
{
	Collider buildingCollider;
	Collider buildingTrigger;
	public enum BuildingState {isBuilding, isBuilt};
	BuildingState buildingState;
	public void Init(string name, int objectHealth, Vector3 position)
	{
		base.Init (name, objectHealth, position);
		buildingState = BuildingState.isBuilding;
	}

	void Awake()
	{
		objectHealth = 1; 

	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (buildingState.isBuilding) 
		{
			Build();
		}


		if (buildingState.isBuilt) 
		{
			FinishBuilding();
		}
	}

	void FinishBuilding()
	{
		buildingCollider = GetComponent<BoxCollider> ();
		buildingTrigger = GetComponentInChildren<BoxCollider> ();
		buildingCollider.enabled = true;
		buildingTrigger.enabled = true;
	}

	void Place()
	{

	}

	void Build()
	{

	}
}
