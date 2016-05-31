using UnityEngine;
using System.Collections;

public enum Relationship { Resource, Friendly, Hostile }

public class BaseObject : MonoBehaviour
{
	public Health objectHealth;

	protected bool isSelected;

	public bool IsSelected
	{
		get { return isSelected; }
	}

	[SerializeField]
	protected GameObject selectedRing;

	protected Collider objectCollider;

	protected int teamID;

	protected void Init(string name, int objectHealth, Vector3 position)
	{
		gameObject.name = name;

		this.objectHealth.Init (objectHealth);
		transform.position = position;

		objectCollider = GetComponent<Collider> ();
		DeSelect ();
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

	public void Select()
	{
		print ("Selected");
		isSelected = true;
		objectHealth.isSelected = true;
		objectHealth.ShowBar (true);
		selectedRing.SetActive (true);
	}

	public void DeSelect()
	{
		print ("DeSelected");
		isSelected = false;		
		objectHealth.isSelected = false;
		selectedRing.SetActive (false);
	}
}