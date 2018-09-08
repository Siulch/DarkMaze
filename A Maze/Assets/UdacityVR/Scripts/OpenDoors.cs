using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    public GameObject door;
    private int doorOpenOrClose = 0;
    private AudioSource audio_source;
    public AudioClip doorSound;

    private bool opening = false;

    private Quaternion doorStartRotation;
    private Quaternion doorEndRotation;

    private float timer = 0f;
    private float rotationTime = 10f;

    void Start()
    {
        audio_source = gameObject.GetComponent<AudioSource>();
        audio_source.clip = doorSound;
        audio_source.playOnAwake = false;

        doorStartRotation = door.transform.rotation;
        doorEndRotation = doorStartRotation * Quaternion.Euler(0f, 90f, 0f);
    }

    void Update()
    {
        // If the door is open
        if (opening)
        {
            timer += Time.deltaTime * 5;
            door.transform.rotation = Quaternion.Slerp(doorStartRotation, doorEndRotation, timer / rotationTime);
        }
        if(opening == false)
        {   
            door.transform.rotation = doorStartRotation;
        }
    }

    public void OnDoorClicked()
    {
        //Door has been clicked
        doorOpenOrClose++;
        //Open door
        if (doorOpenOrClose % 2 != 0)
        {
            opening = true;
        }
        //Close door
        if (doorOpenOrClose % 2 == 0 && doorOpenOrClose != 0)
        {
            opening = false;
        }
        audio_source.Play();
    }
}
