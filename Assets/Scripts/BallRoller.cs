using UnityEngine;
using System.Collections;

public class BallRoller : MonoBehaviour {

	Rigidbody myRigidbody;


	// Use this for initialization
	void Start () {
		myRigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w")){
			myRigidbody.AddForce(Vector3.forward * 100f);
		}
		if (Input.GetKey("s")){
			myRigidbody.AddForce(Vector3.back * 100f);
		}
		if (Input.GetKey("a")){
			myRigidbody.AddForce(Vector3.left * 100f);
		}
		if (Input.GetKey("d")){
			myRigidbody.AddForce(Vector3.right * 100f);
		}
	}

}
