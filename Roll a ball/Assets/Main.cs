using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject currentSelected;
	private Vector3 originScale;

	//Declare Variables
	public int TotalScore =0;
	public GUIText Score; 
	public GUIText CurrentTime;
	public GUITexture Cookie;
	public int StartTime = 5;
	public int Timer = 5; 
	private int ClickRate = 10;

	//Initialize Store Variables



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//if (Timer != 0) {
		//}
			
		CurrentTime.text = "Timer: " + Timer;
		Score.text = "Score: " + TotalScore;
			CountDown ();

			if (Mouse.onLeftButtonDown == currentSelected) {
				originScale = currentSelected.transform.localScale;
				currentSelected.transform.localScale *= 0.8f;
			}
			
			if (Mouse.onLeftButtonUp != null){
				currentSelected.transform.localScale = originScale;
			}



	}

	void CountDown() {
		Timer = (int) Time.timeSinceLevelLoad;
	}

	void OnMouseDown(){
		TotalScore += ClickRate;
	}



}
