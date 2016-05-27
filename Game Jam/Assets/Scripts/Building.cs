using UnityEngine;
using System.Collections;

public enum BuildingState{Ghost, Placed, Build, FinishedBuilding};

public class Building : BaseObject
{
	Collider buildingCollider;
	Collider buildingTrigger;
	[SerializeField]
	protected BuildingState buildingState;
	public bool isPlaced;
	public bool underConstruction;
	public bool buildingComplete;


	public void Init(string name, int objectHealth, Vector3 position)
	{
		base.Init (name, objectHealth, position);
	}

	void Awake()
	{
		objectHealth = 1; 


	}

	// Use this for initialization
	void Start () 
	{
		buildingState = BuildingState.Ghost;
	}

	// Update is called once per frame
	void Update () 
	{
		if(isPlaced)
		{

			buildingState = BuildingState.Placed;
			switchState();
		}
	}

	void switchState()
	{
		switch (buildingState)
			{
				case BuildingState.Placed:
				{
					buildingCollider = GetComponent<BoxCollider> ();
					
					buildingCollider.enabled = true;
					buildingTrigger.enabled = true;
					return;
				}
				case BuildingState.Build:
				{
					return;
				}
				case BuildingState.FinishedBuilding:
				{
					return;
				}
					
				case BuildingState.Ghost:
				{
					buildingCollider = GetComponent<BoxCollider> ();
					buildingTrigger = GetComponentInChildren<Collider> ();
					buildingCollider.enabled = false;
					buildingTrigger.enabled = false;
					return;
				}
			}
	}
}
