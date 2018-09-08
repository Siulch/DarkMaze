using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public GameObject coin;
    public GameObject coinPoofPrefab;

	void Update () {
        // Coin rotation animation
        coin.transform.Rotate(0f, Time.deltaTime * 100f, 0f);
	}


	public void OnCoinClicked () {
		/// Called when the 'Coin' game object is clicked
		/// - Displays a poof effect (handled by the 'CoinPoof' prefab)
		/// - Plays an audio clip (handled by the 'CoinPoof' prefab)
		/// - Removes the coin from the scene
        CoinCounterText.coinsCounter++;
        Instantiate(coinPoofPrefab, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        Destroy(coin, 0.5f);
	}
}
