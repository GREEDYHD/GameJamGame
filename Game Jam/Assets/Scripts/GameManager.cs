using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	private static bool isPaused;
	private static bool isDebug;	
	
	public Villager villagerGO;
	public ResourceNode goldMine;
	public ResourceNode stoneMine;
	public ResourceNode ironMine;
	public ResourceNode treeNode;
		
	public List<BaseObject> baseObjectList;
	
	public EnvironmentBuilder environmentBuilder;
	
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
		baseObjectList = new List<BaseObject> ();
		
		Villager tempVillager = Instantiate(villagerGO);
		tempVillager.Init (10, 10f, 50, 10, 10, 100, "Villager", 100, new Vector3 (0, 1, 0));
		baseObjectList.Add (tempVillager);
		
		ResourceNode gNode = Instantiate (goldMine);
		gNode.Init (ResourceType.Gold, "GoldMine", 100, new Vector3 (15, 1, 0));
		baseObjectList.Add (gNode);

		ResourceNode iNode = Instantiate (ironMine);
		iNode.Init (ResourceType.Gold, "IronMine", 100, new Vector3 (0, 1, 15));
		baseObjectList.Add (iNode);

		ResourceNode sNode = Instantiate (stoneMine);
		sNode.Init (ResourceType.Gold, "StoneMine", 100, new Vector3 (7, 1, 7));
		baseObjectList.Add (sNode);
		
		
		environmentBuilder = GetComponent<EnvironmentBuilder> ();
		
		environmentBuilder.Init (50,50);
		environmentBuilder.SpawnObjectGreaterThan (treeNode,0.5f);
		environmentBuilder.SpawnObjectLessThan (goldMine, 0.1f);

		//Create resource nodes ect.
		//Create a town center
		//Create X villagers
		//Set camera to look at town center
	}
}