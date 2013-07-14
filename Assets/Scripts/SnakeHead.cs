using UnityEngine;
using System.Collections;

public class SnakeHead : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void attackPlayer() {
		transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z); // lock x and z axis to zero
	}
}
