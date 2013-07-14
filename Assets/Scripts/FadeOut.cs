using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	//public GameObject GOBlack;
	Color cAlpha = new Color (0,0,0,0);
	public bool BFade = false;
	
	void Update () {
		if (BFade && cAlpha.a < 1) {
			cAlpha.a += .005f;
			renderer.material.color = cAlpha;
		}
	}
}
