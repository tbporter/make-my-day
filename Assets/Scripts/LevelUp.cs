using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour {
	public string NextLevel;

	void OnTriggerEnter(Collider player) {
		
		if (player.CompareTag ("Player")){
			Debug.Log ("levelUp");
			Application.LoadLevel(NextLevel);
		}
	}
}
