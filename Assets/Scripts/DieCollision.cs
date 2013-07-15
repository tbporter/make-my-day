using UnityEngine;
using System.Collections;

public class DieCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
		collision.transform.GetComponent<PlayerStatus>().die ();
	}
}
