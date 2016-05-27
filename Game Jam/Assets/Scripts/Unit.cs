using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Rigidbody))]
public class Unit : BaseObject 
{
	[SerializeField]
	protected int attackDamage;

	[SerializeField]
	protected float attackSpeed;
	
	[SerializeField]
	protected float movementSpeed;

	public NavMeshAgent navAgent;

	protected Rigidbody rigidBody;

	protected void Init(int attackDamage, float attackSpeed, float movementSpeed, string name, int health, Vector2 position)
	{
		base.Init (name, health, position);
		this.attackDamage = attackDamage;
		this.attackSpeed = attackSpeed;
		this.movementSpeed = movementSpeed;

		objectCollider = GetComponent<CapsuleCollider> ();

		//NavMeshAgent
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.radius = GetComponent<CapsuleCollider> ().radius;
		navAgent.height = GetComponent<CapsuleCollider> ().height;
		navAgent.baseOffset = navAgent.height * 0.5f;

		//RigidBody
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.isKinematic = true;
	}

	protected void Update()
	{
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
					navAgent.SetDestination(hit.point);
			}
		}

		if (GameManager.IsPaused)
		{
			
		}
	}
}