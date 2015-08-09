using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	float NumClick =0;
	GUIText Score; 
	GUIText CurrentTime;
	GUITexture Cookie;
	float StartTime = 5;
	float Timer = 5; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Timer != 0) {
			CurrentTime.text = "Timer: " + Timer;
			Score.text = "Score: " + NumClick;
			CountDown();
		}
	
	}

	void CountDown() {
		Timer = StartTime - Time.timeSinceLevelLoad;

		if (Timer == 0) {
			CurrentTime.text = "Done";
		}
	}

	void OnMouseDown(){
		NumClick += 1;
	}



}
