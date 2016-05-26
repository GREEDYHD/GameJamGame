using UnityEngine;
using System.Collections;

public class Unit : BaseObject 
{
	[SerializeField]
	protected int attackDamage;

	[SerializeField]
	protected float attackSpeed;
	
	[SerializeField]
	protected float movementSpeed;

	public Unit(int attackDamage, float attackSpeed, float movementSpeed, string name, int health, Vector2 position) : base(name, health, position)
	{
		this.attackDamage = attackDamage;
		this.attackSpeed = attackSpeed;
		this.movementSpeed = movementSpeed;
	}
}