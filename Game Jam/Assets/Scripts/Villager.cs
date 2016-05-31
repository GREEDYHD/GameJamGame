using UnityEngine;
using System.Collections;

public class Villager : Unit 
{
	[SerializeField]
	protected int buildSkill;
	
	public BaseObject tmp;
	
	Resource[] inventory;
	
	[SerializeField]
	int inventoryCapacity;
	
	[SerializeField]
	int currentInventory;
	
	public int InventoryCapacity
	{
		get { return inventoryCapacity; }
	}
	
	public int CurrentInventory
	{
		get { return currentInventory; }
	}
	
	[SerializeField]
	protected float gatherRate;
	
	[SerializeField]
	float gatherProgress;
	
	[SerializeField]
	ResourceNode resourceNode;
	
	int gatherAmount = 1;
	
	public void Init(int buildSkill, float gatherRate, int inventorySize, int attackDamage, float attackSpeed, float movementSpeed, string name, int health, Vector3 position)
	{
		base.Init (attackDamage, attackSpeed, movementSpeed, name, health, position);
		
		this.buildSkill = buildSkill;
		this.gatherRate = gatherRate;
		
		inventory = new Resource[5];
		inventory[0] = new Resource(ResourceType.Food,0);
		inventory[1] = new Resource(ResourceType.Gold,0);
		inventory[2] = new Resource(ResourceType.Iron,0);
		inventory[3] = new Resource(ResourceType.Stone,0);
		inventory[4] = new Resource(ResourceType.Wood,0);
	}
	
	protected void Update()
	{
		base.Update ();
		
		if (GameManager.IsPaused)
		{
			
		}
	}
	
	protected override void StateBehaviour()
	{
		print (33);
		switch (state)
		{
			case State.Idle:
			{
				//Play idle animation
				return;
			}
			case State.Moving:
			{
				//Play moving animation
				//Move towards target
				return;
			}
			case State.Attacking:
			{
				//Attack
				return;
			}
			case State.Gathering:
			{
				resourceNode = targetObject.GetComponent<ResourceNode> ();//TODO: Remove this
				gatherProgress += gatherRate * Time.deltaTime;
				if (gatherProgress > 1.0f)
				{
					resourceNode.DepleteResource (gatherAmount);
					gatherProgress = 0.0f;
					CollectResource(resourceNode.Resource.Type,gatherAmount);
					if(CheckInventory())
					{
						MoveTo (NearestResourceDropOff());
						//targetObject = tmp;
						//MoveTo (targetObject);					
					}
				}
				return;
			}
		}
	}
	
	protected override void CheckCollision(Collider collider)
	{
		Debug.Log (collider.name);
		BaseObject collidedObject = collider.GetComponent<BaseObject> ();
		if (collidedObject == targetObject)
		{
			if (collidedObject.GetComponent<ResourceNode>())
			{
				state = State.Gathering;
				navAgent.Stop ();
			}
		}
		base.CheckCollision (collider);
	}
	
	bool CheckInventory()
	{
		int tmpInv = 0;
		for (int i = 0; i < inventory.Length; i++)
		{
			tmpInv += inventory[i].Quantity;
		}
		currentInventory = tmpInv;
		tmpInv = 0;
		if (currentInventory >= inventoryCapacity)
		{
			return true;
		}
		return false;
	}
	
	BaseObject NearestResourceDropOff()
	{
		float closestDist = 1.0f;
		float tempDist = 0.0f;
		int closestIndex = 0;
		for (int i = 0; i < GameManager.Instance.baseObjectList.Count; i++)
		{
			tempDist = Vector3.Distance(GameManager.Instance.baseObjectList[i].transform.position,transform.position);
			if(tempDist < closestDist && GameManager.Instance.baseObjectList[i] != this)
			{
				closestIndex = i;
				closestDist = tempDist;
			}
		}
		return GameManager.Instance.baseObjectList [closestIndex];
	}
	
	void CollectResource(ResourceType resourceType, int quantity)
	{
		for (int i = 0; i < inventory.Length; i++)
		{
			if(inventory[i].Type == resourceType)
			{
				inventory[i].Increase(quantity);
			}
		}
	}
}