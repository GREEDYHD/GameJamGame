using UnityEngine;
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
	}

	public void SpawnObject(GameObject GO, int spawnRate)
	{
		//noiseValueList = new List<float> (terrainWidth * terrainHeight);
		xRand = Random.Range (-1000, 1000);
		yRand = Random.Range (-1000, 1000);		

		for (int i = 0; i < terrainHeight; i++)
		{
			for (int j = 0; j < terrainWidth; j++)
			{
				Debug.Log (terrainWidth);
				//noiseValueList.Add(Mathf.PerlinNoise(j,i));
				if(Mathf.PerlinNoise(((float)j + xRand) / 10,((float)i + yRand) / 10) > 0.5f)
				{
					Quaternion random = new Quaternion();
					random.eulerAngles = new Vector3(0,Random.Range(0,360),0);

					Vector2 randomOffset = new Vector2(Random.Range(-3,3),Random.Range(-3,3));
					GameObject newTree = Instantiate(GO,new Vector3(((j * (xBoundry/terrainWidth) - (xBoundry/2)) + randomOffset.x),0,((i * (yBoundry/terrainHeight) - (xBoundry/2))) + randomOffset.y),random) as GameObject;
					newTree.transform.parent = this.transform.parent;
				}
			}
		}
//		noiseValueList.Sort (delegate(float a, float b) {
//			return (a).CompareTo (b);
//		});
	}
}