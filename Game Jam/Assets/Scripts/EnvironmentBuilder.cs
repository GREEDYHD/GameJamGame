﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentBuilder : MonoBehaviour
{
	public List <float> noiseValueList;

	public int terrainWidth;
	public int terrainHeight;

	public int xBoundry;
	public int yBoundry;

	public float xRand;
	public float yRand;

	public Transform environmentalObjects;
		
	public void Init(int terrainWidth, int terrainHeight)
	{
		this.terrainWidth = terrainWidth;
		this.terrainHeight = terrainHeight;
		environmentalObjects = GetComponent<Transform>();
		xRand = Random.Range (-1000, 1000);
		yRand = Random.Range (-1000, 1000);		
	}

	public void SpawnObjectGreaterThan(ResourceNode GO, float spawnChance)
	{
		//noiseValueList = new List<float> (terrainWidth * terrainHeight);

		for (int i = 0; i < terrainHeight; i++) {
			for (int j = 0; j < terrainWidth; j++) {
				//noiseValueList.Add(Mathf.PerlinNoise(j,i));
				if (Mathf.PerlinNoise (((float)j + xRand) / 10, ((float)i + yRand) / 10) > spawnChance) {
					Quaternion random = new Quaternion ();
					random.eulerAngles = new Vector3 (0, Random.Range (0, 360), 0);

					Vector2 randomOffset = new Vector2 (Random.Range (-3, 3), Random.Range (-3, 3));
					//ResourceNode newTree = Instantiate(GO,new Vector3(((j * (xBoundry/terrainWidth) - (xBoundry/2)) + randomOffset.x),0,((i * (yBoundry/terrainHeight) - (xBoundry/2))) + randomOffset.y),random);
					ResourceNode newTree = Instantiate (GO);
					newTree.Init (ResourceType.Wood, "Tree", 100, new Vector3 (((j * (xBoundry / terrainWidth) - (xBoundry / 2)) + randomOffset.x), -0.8f, ((i * (yBoundry / terrainHeight) - (xBoundry / 2))) + randomOffset.y));
					GameManager.Instance.baseObjectList.Add (newTree);
					newTree.transform.parent = environmentalObjects;
				}
			}
		}
	}

		public void SpawnObjectLessThan(ResourceNode GO, float spawnChance)
		{
			//noiseValueList = new List<float> (terrainWidth * terrainHeight);
			
			for (int i = 0; i < terrainHeight; i++)
			{
				for (int j = 0; j < terrainWidth; j++)
				{
					//noiseValueList.Add(Mathf.PerlinNoise(j,i));
					if(Mathf.PerlinNoise(((float)j + xRand) / 10,((float)i + yRand) / 10) < spawnChance)
					{
						Quaternion random = new Quaternion();
						random.eulerAngles = new Vector3(0,Random.Range(0,360),0);
						
						Vector2 randomOffset = new Vector2(Random.Range(-3,3),Random.Range(-3,3));
						//ResourceNode newTree = Instantiate(GO,new Vector3(((j * (xBoundry/terrainWidth) - (xBoundry/2)) + randomOffset.x),0,((i * (yBoundry/terrainHeight) - (xBoundry/2))) + randomOffset.y),random);
						ResourceNode newTree = Instantiate(GO);
						newTree.Init (ResourceType.Wood, "Tree", 100, new Vector3(((j * (xBoundry/terrainWidth) - (xBoundry/2)) + randomOffset.x),-0.0f,((i * (yBoundry/terrainHeight) - (xBoundry/2))) + randomOffset.y));
						GameManager.Instance.baseObjectList.Add (newTree);
						newTree.transform.parent = environmentalObjects;
					}
				}
			}
//		noiseValueList.Sort (delegate(float a, float b) {
//			return (a).CompareTo (b);
//		});
	}
}