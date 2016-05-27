using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour
{
	[SerializeField]
	protected int objectHealth;

	[SerializeField]
	protected bool isSelected;

	protected Collider objectCollider;

	protected void Init(string name, int objectHealth, Vector3 position)
	{
		gameObject.name = name;
		this.objectHealth = objectHealth;
		transform.position = position;

		objectCollider = GetComponent<Collider> ();
	}

	protected void Update()
	{
		if (GameManager.IsPaused)
		{
			
		}
	}
}