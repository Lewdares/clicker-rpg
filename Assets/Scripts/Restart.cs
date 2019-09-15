using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame() {
		// Some variables that need to be reset before restarting.
		CreateEnemy.DungeonFloor = 1;
		CreateEnemy.DungeonLevel = 1;
		
		// Finally, restarts the scene.
		var scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
