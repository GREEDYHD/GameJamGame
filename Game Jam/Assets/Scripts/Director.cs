using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour
{
	public Selection selectionObject;

	void Update()
	{
		if (Input.GetMouseButtonDown (1) && selectionObject.selectedObjects.Count > 0)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			BaseObject hitObject = null;
			if (Physics.Raycast(ray, out hit))
			{
				if(hit.collider.GetComponent<BaseObject>())
				{
					hitObject = hit.collider.GetComponent<BaseObject>();
				}
			}

			for (int i = 0; i < selectionObject.selectedObjects.Count; i++)
			{
				if(selectionObject.selectedObjects[i].GetComponent<Unit>())
				{
					if(hitObject != null)
					{
						selectionObject.selectedObjects[i].GetComponent<Unit>().MoveTo(hitObject); 
					}
					else
					{
						selectionObject.selectedObjects[i].GetComponent<Unit>().MoveTo(hit.point); 
					}
				}
			}			
		}
	}
}