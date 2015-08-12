using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class FBholder : MonoBehaviour {

	public GameObject UIFBIsLoggedIn;
	public GameObject UIFBNotLoggedIn;
	public GameObject UIFBAvatar;
	public GameObject UIFBUserName;


	private Dictionary<string, string> profile = null;

	void Awake(){
		FB.Init (SetInit, OnHideUnity);

	}

	private void SetInit(){
		Debug.Log ("FB Init Done!");

		if (FB.IsLoggedIn) {

			Debug.Log ("FB Logged In!");
			DealWithFBMenus(true);
		} else {
			DealWithFBMenus(false);



		}
	}

	private void OnHideUnity(bool isGameShown){
		if (!isGameShown) {

			Time.timeScale = 0;	
				} else {

			Time.timeScale = 1;
				
		}

	}

	public void FBlogin(){
		FB.Login ("email", AuthCallback );
	}

	void AuthCallback(FBResult result){

		if (FB.IsLoggedIn) {
			Debug.Log("FB Login Worked!");
			DealWithFBMenus(true);
		} else {
			Debug.Log("FB Login Failed!");
			DealWithFBMenus(false);
		}

	}

	void DealWithFBMenus(bool isLoggedIn){
		if (isLoggedIn) {

			UIFBIsLoggedIn.SetActive (true);
			UIFBNotLoggedIn.SetActive (false);

			// get profile picture code
			FB.API (Util.GetPictureURL("me", 128, 128),Facebook.HttpMethod.GET, DealWithProfilePicture);
			FB.API ("/me?fields=id,first_name",Facebook.HttpMethod.GET, DealWithUserName);
			//get user name code


		} else {

			UIFBIsLoggedIn.SetActive (false);
			UIFBNotLoggedIn.SetActive (true);

		}
	}

	void DealWithProfilePicture(FBResult result){

		if (result.Error != null) {

			Debug.Log("Problem With getting Profile Picture");
			FB.API (Util.GetPictureURL("me", 128, 128),Facebook.HttpMethod.GET, DealWithProfilePicture);
			return;


		}

		Image UserAvatar = UIFBAvatar.GetComponent<Image> ();
		UserAvatar.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 (0, 0));

	}

	void DealWithUserName(FBResult result){

		if (result.Error != null) {
			
			Debug.Log("Problem With getting User Name");

			FB.API ("/me?fields=id,first_name",Facebook.HttpMethod.GET, DealWithUserName);
			return;
			
			
		}

		profile = Util.DeserializeJSONProfile (result.Text);

		Text UserMsg = UIFBUserName.GetComponent<Text> ();
		UserMsg.text = "Hello, " + profile ["first_name"];




	}

	public void ShareWithFriends(){
		FB.Feed (

			linkCaption:"I'm Playing This Awesome Game!",
			picture:"http://retiredgamers.net/cover.png",
			linkName: "Check Out This Game!",
			link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")


			);
	}

	public void InviteFriends()
	{
		FB.AppRequest(
			message: "This Game is Awesome, Give it a Go!",
			title: "Invite your friends to join you"
			);
	}



}
