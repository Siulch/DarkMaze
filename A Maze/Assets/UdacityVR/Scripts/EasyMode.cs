using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMode : MonoBehaviour {

    public GameObject Steps;

    public void OnEasyModeButtonClicked()
    {
        Steps.SetActive(true);
    }
}
