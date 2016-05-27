using UnityEngine;
using System.Collections;

public class Villager : Unit 
{
	[SerializeField]
	protected int buildSkill;

	[SerializeField]
	protected float gatherRate;

	public void Init(int buildSkill, float gatherRate, int attackDamage, float attackSpeed, float movementSpeed, string name, int health, Vector3 position)
	{
		base.Init (attackDamage, attackSpeed, movementSpeed, name, health, position);
		this.buildSkill = buildSkill;
		this.gatherRate = gatherRate;
	}

	protected void Update()
	{
		base.Update ();
		if (GameManager.IsPaused)
		{
			
		}
	}
}