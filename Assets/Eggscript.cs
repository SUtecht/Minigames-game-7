using UnityEngine;
using System.Collections;

public class Eggscript : MonoBehaviour {
	public GUIScript cam;
	public ParticleSystem explosion;
	//int ticks = 0;
	Vector3 targetA;
	Vector3 targetB;
	Vector3 my_point;
	// Use this for initialization
	void Start () {
		determineTargets();
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, my_point) < .5f){
			//Debug.Log("changing target");
			changeTarget();
		}
		transform.position = Vector3.MoveTowards( transform.position,  my_point , 2 * Time.deltaTime);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "bullet"){
			//Debug.Log("Egg hit");
			cam.score += 1;
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	void determineTargets(){
		int r = Random.Range(0,3);
		if( r == 0){
			targetA = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
		}else if(r == 1){
			targetA = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
		}else{
			targetA = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z);
		}
		targetB = transform.position;
		my_point = targetA;
	}

	void changeTarget(){
		if(my_point == targetA){
			my_point = targetB;
		}else{
			my_point = targetA;
		}
	}
}
