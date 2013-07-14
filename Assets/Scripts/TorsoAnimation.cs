using UnityEngine;
using System.Collections;

public class TorsoAnimation : MonoBehaviour {

	public AnimeState myAnimation;

	public int iMaxCols;
	public int iMaxRows;
	public int iSpriteSize;
	float frameRate;
	Vector2 vOffset;
	float frame = 0;
	Vector3 myPos;

	// Use this for initialization
	void Start () {
		vOffset.y = 0f;
	}
	
    
    void Update() {
		frameRate = 1f / myAnimation.fSpeed  ;
		float newFrame = Mathf.Floor ( Time.time / frameRate ) ;
		if (frame != newFrame) {

			if (myAnimation.isShooting) {
				if (myAnimation.Facing < 0) vOffset.x = .5f;
				else vOffset.x = 0f;
		
				myPos = transform.localPosition;
				myPos.y = .1f;
				transform.localPosition = myPos;
				vOffset.y += ( 1f / iMaxRows );
				vOffset.y %= 1; 
				renderer.material.mainTextureScale = new Vector2 ( ( myAnimation.Facing * .5f), ( 1f / iMaxRows ));
				renderer.material.SetTextureOffset("_MainTex", vOffset);
				
			}	
			else { //idle
				myPos = transform.localPosition;
				myPos.y = -.1f;
				transform.localPosition = myPos;
				
				if (myAnimation.Facing > 0) {
					renderer.material.SetTextureOffset("_MainTex", new Vector2(.5f, .5f));
				}
				else {
					renderer.material.SetTextureOffset("_MainTex", new Vector2(1f, .5f));
				}
				
				renderer.material.mainTextureScale = new Vector2 (myAnimation.Facing * .5f, .5f);
				
			}
		}	
		frame = newFrame;
    } 

}
