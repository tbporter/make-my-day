using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour {
	public string NextLevel;

	void OnTriggerEnter(Collider player) {
		if (player.CompareTag ("Player")){
			Application.LoadLevel(NextLevel);
			if(NextLevel=="BossBattle")
				Destroy(GameObject.FindGameObjectWithTag("Music"));
		}
	}
}
