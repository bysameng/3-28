using UnityEngine;
using System.Collections;

public class BodySnatcher : MonoBehaviour {

	public BallRoller roller;

	void Awake () {
		//get roller componenet
		roller = gameObject.GetComponent<BallRoller>();
		if (roller == null) roller = gameObject.AddComponent<BallRoller>();
	}

	//called when i collide with something
	void OnCollisionEnter(Collision other){
		//only switch if other object is snatchable
		if (other.gameObject.tag == "Snatchable"){
			Debug.Log("snatched " + other.gameObject.name);
			this.Snatch(other.gameObject);
		}
	}

	//does the actual snatching
	void Snatch(GameObject other){
		CameraFollower.main.Track(other.gameObject);	//follows new roller

		//disable snatchability
		other.tag = "Untagged";
		Invoke("SetSnatchable", 2f);

		//gets the bodysnatcher of the other, adds one if nonexistent
		BodySnatcher bs = other.GetComponent<BodySnatcher>();
		if (bs == null) bs = other.AddComponent<BodySnatcher>();

		bs.enabled = true;
		bs.EnableSnatcher();

		this.DisableSnatcher();
	}

	//stops this object
	public void DisableSnatcher(){
		this.roller.enabled = false;
		this.enabled = false;
	}

	//starts this snatcher
	public void EnableSnatcher(){
		this.roller.enabled = true;
		this.enabled = true;
	}

	//used with our invoke
	//to set the tag with a delay
	void SetSnatchable(){
		this.tag = "Snatchable";
	}

}
