using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {
	public static CameraFollower main;

	public GameObject objectToFollow;
	public Vector3 offset;

	void Start(){
		main = this;
	}


	// Update is called once per frame
	void Update () {
		if (objectToFollow != null){
			this.transform.position = objectToFollow.transform.position + offset;
			this.transform.LookAt(objectToFollow.transform);
		}
	}

	public void Track(GameObject g){
		objectToFollow = g;
	}

}
