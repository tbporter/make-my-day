using UnityEngine;
using System.Collections;

public class BaddieWalk : MonoBehaviour {
	public AnimeState myAnimation;

	public int iMaxCols;
	public int iMaxRows;
	public int iSpriteSize;
	public float fSetRow;
	float frameRate;
	Vector2 vOffset;
	float frame = 0;

	// Use this for initialization
	void Start () {
		vOffset.y = fSetRow;
	}
	
    
    void Update() {
		frameRate = 1f / myAnimation.fSpeed  ;
		float newFrame = Mathf.Floor ( Time.time / frameRate ) ;
		if (frame != newFrame) {
			vOffset.y = fSetRow;
			vOffset.x += .5f;
			vOffset.x %= 1;
		
			if (myAnimation.Facing > 0) { // facing left
				renderer.material.mainTextureScale = new Vector2 (-.5f, fSetRow);
				renderer.material.SetTextureOffset("_MainTex", new Vector2( vOffset.x +.5f, vOffset.y));
			}
			else {
				renderer.material.mainTextureScale = new Vector2 (.5f, fSetRow);
				renderer.material.SetTextureOffset("_MainTex", vOffset);
			}
				
		}	
		frame = newFrame;
    } 
}
