using UnityEngine;
using System.Collections;

public class ResourceNode : BaseObject
{
	[SerializeField]
	Resource resourceType;

	public ResourceNode(Resource resourceType, string name, int health, Vector2 position) : base(name, health, position)
	{
		this.resourceType = resourceType;
	}
}