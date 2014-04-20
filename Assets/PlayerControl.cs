using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject clone_prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay(transform.position, transform.forward, Color.red);
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			Debug.DrawRay(ray.origin, ray.direction * 100 , Color.green);
			Vector3 r = new Vector3(ray.origin.x - .5f, ray.origin.y, ray.origin.z);
			GameObject clone = (GameObject)Instantiate(clone_prefab , r, Quaternion.identity);
			clone.rigidbody.AddForce(ray.direction * 1000);
			//clone.rigidbody.velocity = transform.TransformDirection(Vector3.forward * 10);
		}
	}

}
