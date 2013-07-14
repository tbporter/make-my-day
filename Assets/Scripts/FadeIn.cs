using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	Color cAlpha ;
	public bool BFade = false;
	
	void Start () {
		cAlpha = renderer.material.color;
	}
	
	void Update () {
		if (BFade && cAlpha.a > 0) {
			cAlpha.a -= .005f;
			renderer.material.color = cAlpha;
		}
	}
}
