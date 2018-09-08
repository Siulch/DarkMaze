using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCounterText : MonoBehaviour {

    public Text keyText;
    public static int keyCounter;

    void Update()
    {
        keyText.text = keyCounter.ToString();
    }
}
