using UnityEngine;
using System.Collections;

public class BulletSwapper : MonoBehaviour {

	public Shooter spawner{get; set;}



	//called when bullet hits a collision
	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Snatchable"){
			//only here do we switch
			Debug.Log("spawner is null is " + spawner == null);
			spawner.GetComponentInParent<BodySnatcher>().Snatch(other.gameObject);
		}

		Destroy (this.gameObject, 5f);
	}

}
