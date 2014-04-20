using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
	public int score = 0;
	private int max_score = 10;
	private int my_time;
	static int best_time;
	// Use this for initialization
	void Start () {
		StartCoroutine(countTime());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUI.Label(new Rect(10,10, 200, 40), "Score " + score + ". Time: " + my_time);
		if(best_time != 0){
			GUI.Label(new Rect(10,40, 200, 40), "Best Time: " + best_time);
		}

		if(score == max_score){
			if(my_time < best_time || best_time == 0){
				best_time = my_time;
			}
			//GUI.Label(new Rect(60, -72, 200, 40), "VICTORY");
			if(GUI.Button(new Rect(10, 80, 200, 100), "VICTORY! Play Again?")){

				Application.LoadLevel("eggs");
			}
		}
	}

	IEnumerator countTime(){

		yield return new WaitForSeconds(1);
		if(score != max_score){
		my_time++;
		StartCoroutine(countTime());
		}
	}
}
