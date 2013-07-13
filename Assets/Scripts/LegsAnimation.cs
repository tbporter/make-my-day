using UnityEngine;
using System.Collections;

public class LegsAnimation : MonoBehaviour {
	//new Material mCharacter;
	public AnimationState myAnimation;
	
	public float fScrollSpeed = 0.5F;
	public int iMaxCols;
	public int iMaxRows;
	public int iSpriteSize;
	public float frameRate;		// tie to char speed later
	Vector2 vOffset;
	float frame = 0;

	// Use this for initialization
	void Start () {
		//sMovement = gameObject.GetComponent<Movement>();
		//vOffset.x = .5f;
		vOffset.y = 0f;
	}
	
    
    void Update() {
		float newFrame = Mathf.Floor ( Time.time / frameRate ) ;
		if (frame != newFrame) {
			if ( myAnimation.isRunning ) {

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
