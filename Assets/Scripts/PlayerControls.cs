using UnityEngine;
using System.Collections;


public class PlayerControls : MonoBehaviour {

	public float forceMultiplier = 1000f;
	
	void playerPositionFix(float horizontal, float vertical) {

		switch((int)vertical) {
		case -1:
			if(transform.position.z < -4.8f) {
				transform.position = new Vector3(transform.position.x, transform.position.y, -4.7f);
				Debug.Log("Reset -z");
			}
			break;
		case 1:
			if(transform.position.z > 4.8f) {
				transform.position = new Vector3(transform.position.x, transform.position.y, 4.7f);
				Debug.Log("Reset +z");
			}
			break;
		}

		switch((int)horizontal) {
		case -1:
			if(transform.position.x < -3.9f) {
				transform.position = new Vector3(-3.8f, transform.position.y, transform.position.z);
				Debug.Log("Reset -x");
			}
			break;
		case 1:
			if(transform.position.x > 3.9f) {
				transform.position = new Vector3(3.8f, transform.position.y, transform.position.z);
				Debug.Log("Reset +x");
			}
			break;
		}

	}

	void Update () {
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");
		//Vector3 position = transform.position;
		if (vertical != 0) {
			vertical = vertical > 0 ? 1f : -1f;
			transform.rigidbody.AddForce(Vector3.forward * vertical * forceMultiplier);
			//position = new Vector3(position.x, position.y, position.z + vertical);		
		}

		if (horizontal != 0) {
			horizontal = horizontal > 0 ? 1f : -1f;
			transform.rigidbody.AddForce(Vector3.right * horizontal * forceMultiplier);
			//position = new Vector3(position.x + horizontal, position.y, position.z);		
		}

		playerPositionFix (horizontal, vertical);
		//z-4.8
		//x-3.8
		//Debug.Log (transform.position.ToString ()  +" (x,y,z)");
		//transform.position = position;
	}
}
