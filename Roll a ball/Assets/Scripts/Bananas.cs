using UnityEngine;
using System.Collections;

public class Bananas : MonoBehaviour {

	public float delay = 0.1f;

	public GameObject bananap;



	// Use this for initialization
	void Start () {


			InvokeRepeating ("Spawn", delay, delay);



	
	}
	
	// Update is called once per frame
	public void Spawn () {

		Instantiate (bananap, new Vector3 (Random.Range (25, 1020), 500 ,524 ), Quaternion.identity);
	
	}
}
