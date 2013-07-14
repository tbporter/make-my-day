using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {
	public FadeIn BlackOut;
	public FadeIn Mission;

	// Use this for initialization
	void Start () {
		StartCoroutine (gameIntro());
	}
	
	IEnumerator gameIntro() {
		yield return null;
	}
}
