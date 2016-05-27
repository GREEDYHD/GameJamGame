using UnityEngine;
using System.Collections;

public class ResourceNode : BaseObject
{
	[SerializeField]
	Resource resourceType;

	protected void Init(Resource resourceType, string name, int health, Vector2 position)
	{
		base.Init(name, health, position);
		this.resourceType = resourceType;

		objectCollider = GetComponent<SphereCollider> ();
	}
}