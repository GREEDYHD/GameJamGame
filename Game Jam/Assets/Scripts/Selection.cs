using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selection : MonoBehaviour
{
	public List<BaseObject> selectedObjects;
	
	BaseObject newSelectedObject;
	
	public FocusOn unitCamera;
	
	void Start()
	{
		selectedObjects = new List<BaseObject> ();
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if(newSelectedObject = hit.collider.gameObject.GetComponent<BaseObject>())
				{  
					if(Input.GetKey(KeyCode.LeftControl))
					{
						if(newSelectedObject.IsSelected)
						{
							selectedObjects.Remove(newSelectedObject);
							newSelectedObject.DeSelect();
						}
						else
						{
							SelectObject(newSelectedObject);
						}
					}
					else
					{
						DeselectSelected();	
					}
				}
			}
		}
	}
	
	void DeselectSelected()
	{
		for (int i = 0; i < selectedObjects.Count; i++)
		{
			selectedObjects[i].DeSelect();
		}
		selectedObjects.Clear ();
	}
	
	void SelectObject(BaseObject selectObject)
	{
		selectObject.Select();
		selectedObjects.Add(selectObject);
		unitCamera.SetFocusObject (selectedObjects[0]);
	}
}