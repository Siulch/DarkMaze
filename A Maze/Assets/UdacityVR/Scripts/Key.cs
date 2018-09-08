using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public GameObject key;
    public GameObject keyPoofPrefab;
    public Door door;

    void Update () {
        // Key rotation animation
        key.transform.Rotate(0f, 0f, Time.deltaTime * 100f);
    }

	public void OnKeyClicked () {
		/// Called when the 'Key' game object is clicked
		/// - Unlocks the door (handled by the Door class)
		/// - Displays a poof effect (handled by the 'KeyPoof' prefab)
		/// - Plays an audio clip (handled by the 'KeyPoof' prefab)
		/// - Removes the key from the scene
        KeyCounterText.keyCounter++;
        Instantiate(keyPoofPrefab, transform.position, transform.rotation);
        door.Unlock();
        Destroy(key, 0.5f);
    }
}
