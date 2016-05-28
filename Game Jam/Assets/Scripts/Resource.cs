using UnityEngine;
using System.Collections;

public enum ResourceType { Wood, Iron, Gold, Food, Stone }

public class Resource
{
	[SerializeField]
	ResourceType resourceType;

	[SerializeField]
	int quantity;

	public Resource(ResourceType type, int quantity)
	{
		this.resourceType = type;
		this.quantity = quantity;
	}

	public Resource(ResourceType type)
	{
		this.resourceType = type;
		this.quantity = 0;
	}
	
	public ResourceType Type
	{
		get { return resourceType; }
	}

	public int Quantity 
	{
		get { return quantity; }
	}

	public void Deplete(int quantity)
	{
		this.quantity -= quantity;
	}

	public void Increase(int quantity)
	{
		this.quantity += quantity;
	}	
}