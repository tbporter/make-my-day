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
	float column; // 0=n/a, 1=stand, 2=run, 3=stand/shoot;

	// Use this for initialization
	void Start () {
		vOffset.y = 0f;
	}
	
    
    void Update() {
		frameRate = 1f / myAnimation.fSpeed;
		float newFrame = Mathf.Floor ( Time.time / frameRate ) ;
		if (frame != newFrame) {

			column = myAnimation.Facing;
			
			//else renderer.material.mainTextureScale = new Vector2 (  (1f/iMaxCols), ( 1f / iMaxRows ));	
				
			if ( !myAnimation.isGrounded ) { // she's jumping
				
				column *= 2;
				vOffset.x = column * (1f/iMaxCols); 
				vOffset.y = .5f;
				if (column < 0) vOffset.x = (Mathf.Abs (column) * (1f/iMaxCols)) - .75f ;
				else vOffset.x = column * (1f/iMaxCols); 
					
				renderer.material.SetTextureOffset("_MainTex", vOffset);	
			}
			else {
				if ( myAnimation.isRunning ) {
				column *= 2;
				vOffset.x = column * (1f/iMaxCols); 
				}
				else if (!myAnimation.isRunning && myAnimation.isShooting) {
					column *= 3;	
				}
				else { // is standing
					column *= 1;
		
				}
					
				//vOffset.x = column * (1f/iMaxCols); 
				vOffset.y += ( 1f / iMaxRows );
				vOffset.y %= 1;  
				
				if (column < 0) vOffset.x = (Mathf.Abs (column) * (1f/iMaxCols)) - .75f ;
				else vOffset.x = column * (1f/iMaxCols); 
					
				renderer.material.SetTextureOffset("_MainTex", vOffset);
				renderer.material.mainTextureScale = new Vector2 ( ( myAnimation.Facing * (1f/iMaxCols)), ( 1f / iMaxRows ));
			}

		}
		//else renderer.material.mainTextureScale = new Vector2 ( (column * (1f/iMaxCols)), ( 1f / iMaxRows ));
		//else renderer.material.mainTextureScale = new Vector2 (  (1f/iMaxCols), ( 1f / iMaxRows ));	
		frame = newFrame;
	
    } 
}
