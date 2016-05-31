using UnityEngine;
using System.Collections;

public class FocusOn : MonoBehaviour
{
	public BaseObject focusObject;
	public Camera camera;

	void Update ()
	{
		if (focusObject != null) {
			camera.enabled = true;			
			camera.transform.position = focusObject.transform.position - new Vector3 (3, -1, 0);
			camera.transform.LookAt (focusObject.gameObject.transform.position);
			Panelmanager.Instance.UpdateInfoBox (focusObject.name, focusObject.GetComponent<Villager> () != null ? 0 : focusObject.GetComponent<Villager> ().CurrentInventory, focusObject.GetComponent<Villager> () != null ? 0 : focusObject.GetComponent<Villager> ().InventoryCapacity, focusObject.GetComponent<Health> ().CurrentHealth, focusObject.GetComponent<Health> ().MaxHealth);
		} else {
			camera.enabled = false;
		}
	}

	public void SetFocusObject(BaseObject focusObject)
	{
		this.focusObject = focusObject;
	}
}