using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	//public GameObject GOBlack;
	Color cAlpha ;
	public bool BFade = false;
	
	void Start () {
		cAlpha = renderer.material.color;
	}
	
	void Update () {
		if (BFade && cAlpha.a < 1) {
			cAlpha.a += .005f;
			renderer.material.color = cAlpha;
		}
	}
}
