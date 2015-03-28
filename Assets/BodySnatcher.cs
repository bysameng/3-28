using UnityEngine;
using System.Collections;

public class BodySnatcher : MonoBehaviour {

	public BallRoller roller;

	// Use this for initialization
	void Awake () {
		roller = gameObject.GetComponent<BallRoller>();
		if (roller == null) roller = gameObject.AddComponent<BallRoller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Snatchable"){
			Debug.Log("snatched " + other.gameObject.name);
			this.Snatch(other.gameObject);
		}
	}

	void Snatch(GameObject other){

		CameraFollower.main.Track(other.gameObject);	//follows new roller

		//gets the bodysnatcher of the other, adds one if nonexistent
		BodySnatcher bs = other.GetComponent<BodySnatcher>();
		if (bs == null) bs = other.AddComponent<BodySnatcher>();

		bs.EnableSnatcher();

		this.DisableSnatcher();
	}


	public void DisableSnatcher(){
		this.roller.enabled = false;
		this.enabled = false;
	}

	public void EnableSnatcher(){
		this.roller.enabled = true;
		this.enabled = true;
	}



}
