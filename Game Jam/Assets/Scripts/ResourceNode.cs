using UnityEngine;
using System.Collections;

public class ResourceNode : BaseObject
{
	[SerializeField]
	Resource resourceType;

	public Resource ResourceType
	{
		get { return resourceType; }
	}

	[SerializeField]
	Inventory inventory;

	public void Init(Resource resourceType, string name, int health, Vector3 position)
	{
		base.Init(name, health, position);
		this.resourceType = resourceType;
		inventory = GetComponent<Inventory> ();
		inventory.Init (health);
		inventory.AddResourceEntry (resourceType, health);
		inventory.AddResource (resourceType, health);
	}
	
	public void DepleteResource(int quantity)
	{
		inventory.RemoveResource (resourceType, quantity);
//		if ()
//		{
//			Destroy(this.gameObject);
//			//Totally depleted
//		} 
//		else 
//		{
//			//Particle effect
//		}
	}
}