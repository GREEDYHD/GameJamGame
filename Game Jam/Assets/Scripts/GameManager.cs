using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	private static bool isPaused;

	public Villager villagerGO;

	public static GameManager Instance
	{
		get { return instance; }
	}

	public static bool IsPaused
	{
		get { return isPaused; }
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
		villagerGO.Init (10, 10, 10, 10, 100, "Villager", 100, new Vector3 (0, 1, 0));
		//Create resource nodes ect.
		//Create a town center
		//Create X villagers
		//Set camera to look at town center
	}
}