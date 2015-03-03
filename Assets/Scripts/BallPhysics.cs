using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision collision) {
		Transform gameObj = collision.transform;
		Vector3 force;
		if (gameObj.tag == "walls") {
			force = transform.position;
			if(gameObj.name == "wallz") {
				force.Set(force.x, force.y, force.z * (-2f));
				Debug.Log("vertical");
			}
			else {
				force.Set(force.x * (-2f), force.y, force.z);
			}
			//transform.rigidbody.AddExplosionForce(50000f, force, 10f, 0f, ForceMode.Impulse);
			transform.rigidbody.AddForce(force);
			Debug.Log(force.ToString() + " Force");
		}
		else if(gameObj.tag == "Player") {
			force = transform.position;
			force.Set(force.x, force.y, force.z * (-4f));
			//transform.rigidbody.AddExplosionForce(100000f, force, 10f, 0f, ForceMode.Impulse);
			//Debug.Log(force.ToString() + " Force");
			transform.rigidbody.AddForce(force);
		}
	}

	void Start () {
		transform.rigidbody.AddForce(new Vector3(transform.position.x, transform.position.y, transform.position.z * 3f));

	}
}
