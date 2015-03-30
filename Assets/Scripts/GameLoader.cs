using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")){
			Application.LoadLevel(1);	//load the game scene
		}
	}

}