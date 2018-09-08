using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounterText : MonoBehaviour {

    public Text coinsText;
    public static int coinsCounter;

	void Update () {
        coinsText.text = coinsCounter.ToString();
	}
}
