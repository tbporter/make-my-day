using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {
	public FadeIn BlackOut;
	public FadeIn Mission;
	//public DialogScript ShowMission;

	// Use this for initialization
	void Start () {
		StartCoroutine (gameIntro());
	}
	
	IEnumerator gameIntro() {
		//ShowMission.initDialog (0);
		BlackOut.BFade = true;
		yield return new WaitForSeconds(2.0f);
		Mission.BFade = true;
		
		yield return null;
	}
}
