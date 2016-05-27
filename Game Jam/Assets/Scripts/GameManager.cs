using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	private static bool isPaused;
	private static bool isDebug;	

	public Villager villagerGO;
	public ResourceNode resourceNodeGO;
	

	public static GameManager Instance
	{
		get { return instance; }
	}

	public static bool IsPaused
	{
		get { return isPaused; }
	}

	public static bool IsDebug
	{
		get { return isDebug; }
	}
	
	public void Awake()
	{
		instance = this;
		isPaused = false;
		CreateGameObjects ();
	}

	void CreateGameObjects()
	{
		Instantiate(villagerGO);
		villagerGO.Init (10, 10, 50, 10, 10, 100, "Villager", 100, new Vector3 (0, 1, 0));

		Instantiate (resourceNodeGO);
		resourceNodeGO.Init (Resource.Gold, "GoldMine", 1000, new Vector3 (15, 1, 0));
		//Create resource nodes ect.
		//Create a town center
		//Create X villagers
		//Set camera to look at town center
	}
}