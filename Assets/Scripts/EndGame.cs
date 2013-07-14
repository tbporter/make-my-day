using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public bool CanWin;
	public GameObject Heart;
	public GameObject HelpBubble;
	public DialogScript SDialog;
	public FadeOut BlackOut;
	public FadeIn theEnd;
	bool bBubbleToggle = false;
	float countDown=3;
	bool hasWon = false;
	
	void Start() {
		Color cHeart = Heart.renderer.material.color;
		cHeart.a = 0;
		Heart.renderer.material.color = cHeart;
	}
	
	void Update() { // not won, cry for help
		if (!hasWon){
			if(Time.time > countDown){
				Color cHelp = HelpBubble.renderer.material.color;
				if (bBubbleToggle) {
					cHelp.a = 0;
					bBubbleToggle = false;
				}
				else {
					cHelp.a = 1;
					bBubbleToggle = true;
				}
				
				HelpBubble.renderer.material.color = cHelp;
				countDown = Time.time + 7f;
			}
		}
	}
	
	void OnTriggerEnter(Collider player) {

		if (player.CompareTag ("Player") && CanWin && !hasWon) StartCoroutine(EndSequence());

		Debug.Log (gameObject.tag);
		if (player.CompareTag ("Player") && CanWin && !hasWon) {
			StartCoroutine(EndSequence());
			Vector3 herPos = player.transform.position;
			herPos.z = -2f;
			player.transform.position = herPos;
		}
	}
	
	IEnumerator EndSequence() {
		hasWon = true;
		Destroy (HelpBubble);
		//show heart
		Color cHeart = Heart.renderer.material.color;
		cHeart.a = 1;
		Heart.renderer.material.color = cHeart;
		//show fiance
		renderer.material.SetTextureOffset("_MainTex", new Vector2(.5f, 0f));
		yield return new WaitForSeconds(2.0f);
		//break his heart
		SDialog.initDialog(1);
		yield return new WaitForSeconds(5.0f);
		SDialog.initDialog(2);
		yield return new WaitForSeconds(5.0f);
		SDialog.initDialog(3);
		yield return new WaitForSeconds(5.0f);
		Heart.renderer.material.SetTextureOffset("_MainTex", new Vector2(.5f, 0f));
		yield return new WaitForSeconds(1.0f);
		
		// the End.
		BlackOut.BFade = true;
		yield return new WaitForSeconds(2.0f);
		Destroy (Heart);
		theEnd.BFade = true;
		
		yield return null;
	}
	

}
