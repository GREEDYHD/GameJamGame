using UnityEngine;
using System.Collections;

public class Villager : Unit 
{
	[SerializeField]
	protected int buildSkill;

	[SerializeField]
	protected float gatherRate;

	public Villager(int buildSkill, float gatherRate, int attackDamage, float attackSpeed, float movementSpeed, string name, int health, Vector2 position) : base(attackDamage, attackSpeed, movementSpeed, name, health, position)
	{
		this.buildSkill = buildSkill;
		this.gatherRate = gatherRate;
	}
}