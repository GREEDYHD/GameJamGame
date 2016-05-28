using UnityEngine;
using System.Collections;

public enum Relationship { Resource, Friendly, Hostile }

public class BaseObject : MonoBehaviour
{
	public Health objectHealth;

	protected bool isSelected;

	protected Collider objectCollider;

	protected int teamID;

	protected void Init(string name, int objectHealth, Vector3 position)
	{
		gameObject.name = name;

		this.objectHealth.Init (objectHealth);
		transform.position = position;

		objectCollider = GetComponent<Collider> ();
	}

	protected void Update()
	{
		if (GameManager.IsPaused)
		{
			
		}
	}

	public Relationship CheckRelationship(int ID)
	{
//		if (ID == 0)
//		{
		return Relationship.Hostile;
//		}
//		if (ID == teamID)
//		{
//			return Relationship.Friendly;
//		}
//		if(ID != teamID)
//		{
//			return Relationship.Hostile;
//		}
	}
}