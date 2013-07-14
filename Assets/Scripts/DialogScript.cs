using UnityEngine;
using System.Collections;

public class DialogScript : MonoBehaviour {
	//public Renderer rDialog;
	float fStep = .25f;
	
	// Use this for initialization
	void Start () {
		renderer.material.color = new Color (1,1,1,0);
	}
	
	public void initDialog (int msg) { // 0-3
		StartCoroutine (showDialog(msg));
		renderer.material.SetTextureOffset("_MainTex", new Vector2(0f, .75f-(.25f*msg) ) );	
	}
	
	public IEnumerator showDialog(int msg) {
		renderer.material.color = new Color (1,1,1,1);
		yield return new WaitForSeconds(5.0f);
	    if (msg !=3) renderer.material.color = new Color (1,1,1,0); // hold the last frame.
		
		yield return null;
	}
}
