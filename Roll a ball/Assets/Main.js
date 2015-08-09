#pragma strict
var clicks : Transform; // brackets for multiple objects
var score : GUIText;
var cookie : GUITexture;
var clicked : boolean = false; 
var click : int = 0;
var starttime : int = 5;
var timer : int = starttime;
var time : GUIText;


function Start () {

}

function Update () {


	if (timer !=0){
	time.text = "Timer: " + timer;
	score.text = "Clicks: " + click ; 
	countdown();
	}
}


function OnMouseDown() {
click += 1;
//AnimateCookie();
//cookie.pixelInset.size.x += 10;


}



function AnimateCookie() {
// Starting from the origin, move this object to 5 units along X by 10 units along Z, at 2.5 units per second
yield MoveObject.use.Translation(transform, Vector3.zero, Vector3(0.1, 0.0, 0.0), 2.5, MoveType.Speed);

// When that's done, simultaneously move up one unit and flip 180 degrees along the Z axis, doing both in half a second
//MoveObject.use.Translation(transform, Vector3.up, .5, MoveType.Time);
//MoveObject.use.Rotation(transform, Vector3.forward * 180.0, .5);
}

function countdown(){
timer = starttime - Time.timeSinceLevelLoad;

	if ( timer == 0){
	time.text = "Done";
	}
}