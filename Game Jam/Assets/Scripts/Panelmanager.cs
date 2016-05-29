using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panelmanager : MonoBehaviour {
	private static Panelmanager instance;

	public GameObject[] availablePanels;

	public static Panelmanager Instance {
		get { return instance; }
	}

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
		
		else
		{
			Destroy (gameObject);
		}
	}

	public void SwapPanel(int panelNumber)
	{
		foreach(GameObject panels in availablePanels)
		{
			panels.SetActive(false);
		}

		availablePanels [panelNumber].SetActive (true);
	}

}
