using UnityEngine;
using System.Collections;

class Mouse : MonoBehaviour {
	public static bool isLeftButton = false;
	public static bool isRightButton = false;
	public static bool isMiddleButton = false;
	
	public static bool isLeftButtonDown = false;
	public static bool isRightButtonDown = false;
	public static bool isMiddleButtonDown = false;
	
	public static GameObject onLeftButtonDown;
	public static GameObject onRightButtonDown;
	public static GameObject onMiddleButtonDown;
	
	public static GameObject onLeftButtonUp;
	public static GameObject onRightButtonUp;
	public static GameObject onMiddleButtonUp;
	
	public static GameObject onLeftButton;
	public static GameObject onRightButton;
	public static GameObject onMiddleButton;
	
	public static GameObject onEnter;
	public static GameObject onOver;
	public static GameObject onExit;
	
	public static bool isMove = false;
	public static Vector3 incrementPositionInWorld;
	public static Vector3 absolutePositionInWorld;
	
	private Ray mouseRay;
	private RaycastHit hit;
	
	
	void Update() {
		if (Camera.main) {
			isLeftButton = Input.GetMouseButton(0);
			isRightButton = Input.GetMouseButton(1);
			isMiddleButton = Input.GetMouseButton(2);
			
			isLeftButtonDown = Input.GetMouseButtonDown(0);
			isRightButtonDown = Input.GetMouseButtonDown(1);
			isMiddleButtonDown = Input.GetMouseButtonDown(2);
			
			mouseRay = Camera.main.ScreenPointToRay( new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f) );
			Physics.Raycast(mouseRay,out hit);
			
			Vector3 mousePos = Input.mousePosition;
			if (hit.collider) {
				mousePos.z = hit.collider.gameObject.transform.position.z - Camera.main.transform.position.z;
			}else mousePos.z = -0.05f;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			incrementPositionInWorld = mousePos - absolutePositionInWorld;
			if ( incrementPositionInWorld.magnitude > 0f ) isMove = true;
			else isMove = false;
			absolutePositionInWorld = mousePos;
			
			
			onExit = null;
			if ( (hit.collider && onOver != hit.collider.gameObject) || !hit.collider ) onExit = onOver;
			
			
			if ( hit.collider ) {
				if (onOver != hit.collider.gameObject) onEnter = hit.collider.gameObject;
				else onEnter = null;
				onOver = hit.collider.gameObject;
			}else {
				onEnter = null;
				onOver = null;
			}
			
			
			if ( Input.GetMouseButton(0) ) onLeftButton = onOver;
			else onLeftButton = null;
			
			if ( Input.GetMouseButton(1) ) onRightButton = onOver;
			else onRightButton = null;
			
			if ( Input.GetMouseButton(2) ) onMiddleButton = onOver;
			else onMiddleButton = null;
			
			
			
			if ( Input.GetMouseButtonDown(0) ) onLeftButtonDown = onOver;
			else onLeftButtonDown = null;
			
			if ( Input.GetMouseButtonDown(1) ) onRightButtonDown = onOver;
			else onRightButtonDown = null;
			
			if ( Input.GetMouseButtonDown(2) ) onMiddleButtonDown = onOver;
			else onMiddleButtonDown = null;
			
			
			
			if ( Input.GetMouseButtonUp(0) ) onLeftButtonUp = onOver;
			else onLeftButtonUp = null;
			
			if ( Input.GetMouseButtonUp(1) ) onRightButtonUp = onOver;
			else onRightButtonUp = null;
			
			if ( Input.GetMouseButtonUp(2) ) onMiddleButtonUp = onOver;
			else onMiddleButtonUp = null;

	
		}
	}
}