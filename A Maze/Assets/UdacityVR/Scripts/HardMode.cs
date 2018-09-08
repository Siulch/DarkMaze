using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMode : MonoBehaviour {

    public GameObject Steps;

    public void OnHardModeButtonClicked()
    {
        Steps.SetActive(false);
    }
}
