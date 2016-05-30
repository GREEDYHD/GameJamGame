using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panelmanager : MonoBehaviour {
	private static Panelmanager instance;

	public GameObject[] availablePanels;

	public static Panelmanager Instance {
		get { return instance; }
	}

	//###################################################

	//Selected panel variables
	public Image unitImage;
	public Text unitName;
	public Text inventoryText;
	public Image healthFill;
	public Color thresholdOne;
	public Color thresholdTwo;
	public Color thresholdThree;

	//###################################################

	//ToolTip Panel
	public GameObject toolTipPanel;
	public Text toolTipName;
	public Text toolTipInfo;
	private bool isActive = false;

	void Awake()
	{
		toolTipPanel.SetActive (isActive);
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

	public void updateInfoBox(Image image, string name, int currentCap, int maxCap, int currentHealth, int maxHealth)
	{
		unitImage = image;
		unitName.text = name;
		inventoryText.text = "Inventory : " + currentCap + "/" + maxCap;

			healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
			if( healthFill.fillAmount > 0.5f)
			{
			healthFill.color = thresholdOne;
				return;
			}
			else if( healthFill.fillAmount > 0.1f)
			{
			healthFill.color = thresholdTwo;
				return;
			}
			else if( healthFill.fillAmount > 0.0f)
			{
			healthFill.color = thresholdThree;
				return;
			}

	}

	public void MultipleSelectionHud()
	{

	}

	public void UpdateToolTip()
	{
		isActive = !isActive;
		toolTipPanel.SetActive (isActive);
	}

	public void UpdateToolText(string tipName, string tipText)
	{
		toolTipName.text = tipName;
		toolTipInfo.text = tipText;
	}
}
