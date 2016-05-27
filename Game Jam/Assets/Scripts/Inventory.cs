using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{	
	public Dictionary<Resource,int> resourceStorage;

	[SerializeField]
	int capacity;

	[SerializeField]
	int currentQuantity;

	public void Init(int capacity)
	{
		resourceStorage = new Dictionary<Resource, int>();
		this.capacity = capacity;
		this.currentQuantity = 0;
	}

	public void AddResourceEntry(Resource resource, int quantity)
	{
		//Debug.Log (quantity + " " + resource + " Added");
		resourceStorage.Add (resource, quantity);
	}

	void LateUpdate()
	{
		Debug.Log (resourceStorage.Count);
	}

	public bool AddResource(Resource resource, int quantity)
	{
//		if (currentQuantity + quantity <= capacity)
//		{
//			//resourceStorage[resource] += quantity;
//			currentQuantity += quantity;
//			return true;
//		}
//		else
//		{
//			return false;
//		}	}
		return true;
	}

	public void RemoveResource(Resource resource, int quantity)
	{
//		if (resourceStorage == null) {
//			Debug.LogError ("as dasd");
//		}
//		
//		if (currentQuantity - quantity >= 0)
//		{
//			resourceStorage [resource] -= quantity;
//			currentQuantity -= quantity;
//			//return true;
//		}
//		else
//		{
//			//return false;
//		}	}
	}
}