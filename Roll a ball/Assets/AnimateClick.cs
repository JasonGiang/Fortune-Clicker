using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	GameObject currentSelected;
	private Vector3 originScale;
	
	void Update () {
		if (Mouse.isLeftButtonDown) {
			print ("ok");
			if (Mouse.onLeftButtonDown!=null && Mouse.onLeftButtonDown.tag == "Selectable") {
				if (currentSelected != null) currentSelected.transform.localScale = originScale;
				currentSelected = Mouse.onLeftButtonDown;
				originScale = currentSelected.transform.localScale;
				currentSelected.transform.localScale *= 1.5f;
				Debug.Log("You Select: " + currentSelected);
			}else {
				if (currentSelected != null) currentSelected.transform.localScale = originScale;
				currentSelected = null;
			}
		}
	}
}