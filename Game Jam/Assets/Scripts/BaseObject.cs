using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour
{
	[SerializeField]
	protected int objectHealth;

	[SerializeField]
	protected bool isSelected;

	public BaseObject(string name, int objectHealth, Vector3 position)
	{
		gameObject.name = name;
		this.objectHealth = objectHealth;
		transform.position = position;
	}
}