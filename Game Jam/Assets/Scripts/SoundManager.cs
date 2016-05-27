using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager instance;
	public AudioClip[] avaliableSounds;

	public static SoundManager Instance {
		get { return instance; }
	}

	void Awake ()
	{

		if (instance == null) 
		{
			instance = this;
		}

		else
		{
			Destroy (gameObject);
		}
		
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
