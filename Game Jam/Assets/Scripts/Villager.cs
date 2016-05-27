using UnityEngine;
using System.Collections;

public class Villager : Unit 
{
	[SerializeField]
	protected int buildSkill;

	[SerializeField]
	protected float gatherRate;

	Inventory inventory;

	[SerializeField]
	float gatherProgress;

	[SerializeField]
	ResourceNode resourceNode;

	public void Init(int buildSkill, float gatherRate, int inventorySize, int attackDamage, float attackSpeed, float movementSpeed, string name, int health, Vector3 position)
	{
		base.Init (attackDamage, attackSpeed, movementSpeed, name, health, position);
		this.buildSkill = buildSkill;
		this.gatherRate = gatherRate;
		inventory = GetComponent<Inventory> ();
		inventory.Init (50);
		inventory.AddResourceEntry (Resource.Food, inventorySize);
		inventory.AddResourceEntry (Resource.Gold, inventorySize);
		inventory.AddResourceEntry (Resource.Stone, inventorySize);
		inventory.AddResourceEntry (Resource.Wood, inventorySize);
		inventory.AddResourceEntry (Resource.Iron, inventorySize);
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
					resourceNode.DepleteResource (10);
				}
				return;
			}
		}
	}
	
	protected override void CheckCollision(Collider collider)
	{
		BaseObject collidedObject = collider.GetComponent<BaseObject> ();
		if (collidedObject == targetObject)
		{
			if (collidedObject.GetComponent<ResourceNode>())
			{
				navAgent.Stop ();
				state = State.Gathering;
			}
		}
		base.CheckCollision (collider);
	}
}