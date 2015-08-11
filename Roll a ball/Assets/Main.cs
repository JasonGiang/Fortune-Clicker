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
	public GUIText DisplayPointsPerSecond;
	public int StartTime = 5;
	public int Timer = 5; 
	private int ClickRate = 1;
	private int PointsPerSecond = 0;
	private float TimerNew;
	private float TimerOld = 0;

	//Initialize Store Variables
	public GameObject Factory;
	public GameObject PowerClick;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DisplayClickRate.text = "Points Per Tap: " + ClickRate;
		CurrentTime.text = "Timer: " + Timer;
		Score.text = "Score: " + TotalScore;
		DisplayPointsPerSecond.text = "Points Per Second: " + PointsPerSecond;

		CountDown ();
		Store ();
		UpdatePointsPerSecond ();

		if (Mouse.onLeftButtonDown == currentSelected) {
			originScale = currentSelected.transform.localScale;
			currentSelected.transform.localScale *= 0.8f;

		}
			
		if (Mouse.onLeftButtonUp != null && Mouse.onLeftButtonUp == currentSelected ) {
			currentSelected.transform.localScale = originScale;
		};




	}

	void CountDown() {
		Timer = (int) Time.timeSinceLevelLoad;
	}

	void OnMouseDown(){
		TotalScore += ClickRate;
	}

	void Store(){
		if (Mouse.onLeftButtonDown == PowerClick) {
			if (TotalScore > 100) {
				TotalScore -= 100;
				ClickRate += 10;
			} else {
				NotEnoughMinterals();
			}
		}

		if (Mouse.onLeftButtonDown == Factory) {
			if (TotalScore > 100) {
				TotalScore -= 100;
				PointsPerSecond += 10;
			} else {
				NotEnoughMinterals();
			}
		}

	}

	void NotEnoughMinterals(){

		Score.color = Color.red;

	}

	void UpdatePointsPerSecond(){
		TimerNew = Time.time;
		if (TimerNew > TimerOld) {
			TimerOld = Time.time + 1;
			TotalScore += PointsPerSecond;
		}
	}
	 

}
