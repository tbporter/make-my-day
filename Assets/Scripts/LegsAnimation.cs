using UnityEngine;
using System.Collections;

public class LegsAnimation : MonoBehaviour {
	//new Material mCharacter;
	public AnimeState myAnimation;

	public int iMaxCols;
	public int iMaxRows;
	public int iSpriteSize;
	float frameRate;
	Vector2 vOffset;
	float frame = 0;

	// Use this for initialization
	void Start () {
		vOffset.y = 0f;
	}
	
    
    void Update() {
		frameRate = myAnimation.fSpeed *.1f;
		float newFrame = Mathf.Floor ( Time.time / frameRate ) ;
		if (frame != newFrame) {
			if ( !myAnimation.isGrounded ) { // she's jumping
				//hard coded:
				renderer.material.SetTextureOffset("_MainTex", new Vector2 (.5f, .5f) ) ;	
			}
			else if ( myAnimation.isRunning ) {

				vOffset.x = .5f; // hard coded run column
				vOffset.y += ( 1f / iMaxRows );
				vOffset.y %= 1;  
		        renderer.material.SetTextureOffset("_MainTex", vOffset);	
			}
			else if (!myAnimation.isRunning && myAnimation.isShooting) {
				vOffset.x = .75f; // hard coded stand-shoot
				vOffset.y += ( 1f / iMaxRows );
				vOffset.y %= 1;
		        renderer.material.SetTextureOffset("_MainTex", vOffset);	
			}
			else { // is standing
				vOffset.x = .25f; // hard coded standing;
			}
				
		}
		frame = newFrame;
	
    } 
}
