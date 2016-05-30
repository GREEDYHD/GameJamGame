using UnityEngine;
using System.Collections;

public enum State { Idle, Moving, Gathering, Attacking }

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

	[SerializeField]
	protected State state;

	[SerializeField]
	protected State previousState;
	
	[SerializeField]
	protected BaseObject targetObject;

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

		previousState = State.Idle;
		state = State.Idle;
	}

	protected void Update()
	{
		base.Update ();
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				state = State.Moving;
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
//				switch(hitObject.CheckRelationship(teamID))
//				{
//					case Relationship.Hostile:
//					{
//						Attack();
//						return;
//					}
//					case Relationship.Friendly:
//					{
//						FriendlyAction();
//						return;
//					}
			}
		}

		if(GameManager.IsDebug)
		{
			Debug.DrawLine(transform.position,targetObject.gameObject.transform.position);
		}

		StateBehaviour();

		if (GameManager.IsPaused)
		{
			
		}
	}

	protected virtual void StateBehaviour()
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
				if(previousState != State.Moving)
				{
					MoveTo(targetObject);
					previousState = State.Moving;
				}
				//Play moving animation
				//Move towards target
				return;
			}
			case State.Attacking:
			{
				//Attack
				return;
			}
		}
	}
	
	//call an action that this unit will perform on another BaseObject
	public void MoveTo(BaseObject target)
	{
		state = State.Moving;
		navAgent.Resume ();
		navAgent.SetDestination (target.transform.position);
	}

	public void MoveTo(Vector3 position)
	{
		state = State.Moving;
		navAgent.Resume ();
		navAgent.SetDestination (position);
	}

	void OnTriggerEnter(Collider collider)
	{
		CheckCollision (collider);
	}

	protected virtual void CheckCollision(Collider collider)
	{

	}
}