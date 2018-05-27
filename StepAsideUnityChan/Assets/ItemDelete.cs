using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour {

	private GameObject unityChan;

	// Use this for initialization
	void Start () {
		unityChan = GameObject.Find("unitychan");
	}
	
	// Update is called once per frame
	void Update () {

		if ((unityChan.transform.position.z - 10f) > this.transform.position.z) {
			Destroy (this.gameObject);
		}
	}
}
