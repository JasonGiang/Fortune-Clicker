using UnityEngine;
using System.Collections;
using Parse;


public class Click : MonoBehaviour {

	//this allows you to reference the bananas per click and the main banana display by dragging them into the inspector.
	public UnityEngine.UI.Text bpc;
	public UnityEngine.UI.Text bananaDisplay;
	public UnityEngine.UI.Text guiText;





	//this is your main total of bananas
	public float bananas = 0.00f;

	//this is the starting rate of bananas per click.
	public float bananasPerClick = 1;






	//this updates your total bananas constantly.
	void Update()
	{


		bananaDisplay.text = "Bananas: " + currencyConverter.Instance.GetCurrencyIntoString (bananas, false, false);
		bpc.text = currencyConverter.Instance.GetCurrencyIntoString (bananasPerClick, false, true);






	}

	//pretty simply when you click this happens and adds the bananas perclick to your total.
	public void Clicked()
	{
		bananas += bananasPerClick;
		StartCoroutine(ShowMessage("+" + bananasPerClick, 1));


	}

	IEnumerator ShowMessage (string message, float delay) {
		guiText.text = message;
		guiText.enabled = true;
		yield return new WaitForSeconds(delay);
		guiText.enabled = false;
	}



}
