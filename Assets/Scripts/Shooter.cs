using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject bullet;

	private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		lastPosition = transform.position - transform.forward;
	}


	// Update is called once per frame
	void Update () {
		Vector3 direction = (transform.position - lastPosition).normalized;

		if (Input.GetKeyDown("space")){
			Debug.Log("space pressed");
			FireBullet(direction);
		}

		if (lastPosition != transform.position){
			lastPosition = transform.position;
		}
	}


	void FireBullet(Vector3 direction){
		GameObject g = Instantiate(bullet);
		g.GetComponent<BulletSwapper>().spawner = this;
		g.transform.position = this.transform.position;
		g.GetComponent<Rigidbody>().AddForce(direction * 1000f);
	}



}
