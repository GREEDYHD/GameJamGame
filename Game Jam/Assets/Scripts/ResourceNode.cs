using UnityEngine;
using System.Collections;

public class ResourceNode : BaseObject
{
	Resource resource;

	public Resource Resource
	{
		get { return resource; }
	}
	
	public void Init(ResourceType resourceType, string name, int health, Vector3 position)
	{
		base.Init(name, health, position);
		this.resource = new Resource(resourceType, health);
	}

	public void DepleteResource(int quantity)
	{
		resource.Deplete (quantity);
		objectHealth.TakeDamage (quantity);
	}
}