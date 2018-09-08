using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

    public GameObject chestTop;
    public AudioSource audioSource;

    Quaternion startRotation;
    Quaternion endRotation;

    private bool opening = false;

    private float timer = 0f;
    private float rotationTime = 10f;

    public BoxCollider m_Collider;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        startRotation = chestTop.transform.rotation;
        endRotation = startRotation * Quaternion.Euler(90f, 0f, 0f);
        m_Collider = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (opening)
        {
            timer += Time.deltaTime * 3;
            chestTop.transform.rotation = Quaternion.Slerp(startRotation, endRotation, timer / rotationTime);
        }
    }

    public void OnTopChestClicked()
    {
        opening = true;
        audioSource.Play();
        m_Collider.enabled = false;
    }
    }
