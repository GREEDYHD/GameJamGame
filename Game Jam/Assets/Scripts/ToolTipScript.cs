using UnityEngine;
using System.Collections;

public class ToolTipScript : MonoBehaviour {

	public string tipName;
	public string tipText;

	public void UpdateToolTip()
	{
		Panelmanager.Instance.UpdateToolText (tipName, tipText);
	}
}
