using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public bool CanWin;
	public GameObject Heart;
	public GameObject HelpBubble;
	bool bBubbleToggle = false;
	float countDown=1;
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
				countDown = Time.time + 1f;
			}
		}
	}
	
	void OnTriggerEnter(Collider player) {
		if (player.CompareTag ("Player") && CanWin && !hasWon) StartCoroutine(EndSequence());
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
		Heart.renderer.material.SetTextureOffset("_MainTex", new Vector2(.5f, 0f));
		
		yield return null;
	}
	

}
