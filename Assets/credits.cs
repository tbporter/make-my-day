using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GUIText t = gameObject.GetComponent<GUIText>();
		t.text = "iamagamer Game Jam 2013\n\nTeam TravEve\n\nArt: Eve\nCode: Travis\nMusic: Clay\nSound: Rebecca\n\nThanks for playing!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
