using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject currentSelected;
	private Vector3 originScale;

	//Declare Variables
	public int TotalScore = 98;
	public GUIText Score; 
	public GUIText CurrentTime;
	public GUITexture Cookie;
	public GUIText DisplayClickRate;
	public int StartTime = 5;
	public int Timer = 5; 
	private int ClickRate = 1;

	//Initialize Store Variables
	public GameObject Factory;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DisplayClickRate.text = "Points Per Tap: " + ClickRate;
		CurrentTime.text = "Timer: " + Timer;
		Score.text = "Score: " + TotalScore;

		CountDown ();

		if (Mouse.onLeftButtonDown == currentSelected) {
			originScale = currentSelected.transform.localScale;
			currentSelected.transform.localScale *= 0.8f;

		}
			
		if (Mouse.onLeftButtonUp != null && Mouse.onLeftButtonUp == currentSelected ) {
			currentSelected.transform.localScale = originScale;
		};

		Store ();


	}

	void CountDown() {
		Timer = (int) Time.timeSinceLevelLoad;
	}

	void OnMouseDown(){
		TotalScore += ClickRate;
	}

	void Store(){
		if (Mouse.onLeftButtonDown == Factory) {
			if (TotalScore > 100) {
				TotalScore -= 100;
				ClickRate += 10;
			} else {
				NotEnoughMinterals();
			}
		}
	}

	void NotEnoughMinterals(){

		Score.color = Color.red;

	}
	

}
