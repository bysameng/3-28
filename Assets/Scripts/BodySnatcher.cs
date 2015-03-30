using UnityEngine;
using System.Collections;

public class BodySnatcher : MonoBehaviour {

	public BallRoller roller;
	public Transform myLight;

	//fancy property stuff
	private static int _snatches = 0;
	private static int snatches{
		get{return _snatches;}
		set{_snatches = value; if (snatches >= 50) {Application.LoadLevel(0); snatches = 0;}}
	}

	//reference to the renderer, for color changing
	Renderer renderer;


	//runs before start, instantly, when the gameobject is instantiated
	void Awake () {
		//get roller componenet
		roller = gameObject.GetComponent<BallRoller>();
		if (roller == null) roller = gameObject.AddComponent<BallRoller>();

		//get renderer
		renderer = this.GetComponent<Renderer>();
	}


	//runs after awake, but always before any updates or oncollisionenters
	void Start(){
		myLight = transform.FindChild("PointLight");
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
	public void Snatch(GameObject other){
		CameraFollower.main.Track(other.gameObject);	//follows new roller

		//disable snatchability
		other.tag = "Untagged";
		other.layer = 8;
		Invoke("SetSnatchable", 2f);

		//gets the bodysnatcher of the other, adds one if nonexistent
		BodySnatcher bs = other.GetComponent<BodySnatcher>();
		if (bs == null) bs = other.AddComponent<BodySnatcher>();

		bs.enabled = true;
		bs.EnableSnatcher();

		myLight.transform.parent = other.transform;
		myLight.transform.localPosition = Vector3.zero;

		this.DisableSnatcher();

		snatches++;
		Debug.Log(snatches);
	}


	//stops this object
	public void DisableSnatcher(){
		this.roller.enabled = false;
		this.enabled = false;
		renderer.material.color = Color.white;
	}


	//starts this snatcher
	public void EnableSnatcher(){
		this.roller.enabled = true;
		this.enabled = true;
		//set this renderer's color
		renderer.material.color = Color.red;
	}


	//used with our invoke
	//to set the tag with a delay
	void SetSnatchable(){
		this.tag = "Snatchable";
		gameObject.layer = 0;
	}


}
