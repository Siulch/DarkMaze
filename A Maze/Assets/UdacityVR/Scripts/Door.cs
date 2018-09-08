using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject leftDoor;
    public GameObject rightDoor;

    public AudioSource audioSource;
    public AudioClip doorLocked;
    public AudioClip doorOpen;

    private int keyCount = 0;
    private bool locked = true;
    private bool opening = false;

    private Quaternion leftDoorStartRotation;
    private Quaternion leftDoorEndRotation;
    private Quaternion rightDoorStartRotation;
    private Quaternion rightDoorEndRotation;

    private float timer = 0f;
    private float rotationTime = 10f;

    public BoxCollider[] m_Collider;

    void Start () {
        audioSource = GetComponent<AudioSource>();

        // start and end rotation values used when animating the door opening
        leftDoorStartRotation = leftDoor.transform.rotation;
        leftDoorEndRotation = leftDoorStartRotation * Quaternion.Euler(0f, 0f, 90f);

        rightDoorStartRotation = rightDoor.transform.rotation;
        rightDoorEndRotation = rightDoorStartRotation * Quaternion.Euler(0f, 0f, -90f);

        m_Collider = GetComponentsInChildren<BoxCollider>();
    }


	void Update () {
		// If the door is open
        if (opening)
        {
            timer += Time.deltaTime * 5;
            leftDoor.transform.rotation = Quaternion.Slerp(leftDoorStartRotation, leftDoorEndRotation, timer / rotationTime);
            rightDoor.transform.rotation = Quaternion.Slerp(rightDoorStartRotation, rightDoorEndRotation, timer / rotationTime);
            
        }
	}


	public void OnDoorClicked () {
		/// Called when the 'Left_Door' or 'Right_Door' game object is clicked
		/// - Starts opening the door if it has been unlocked
		/// - Plays an audio clip when the door starts opening
        if (locked == false)
        {
            opening = true;
            audioSource.clip = doorOpen;
            audioSource.Play();
            // Prevent the door from being interacted with after it has started opening
            foreach (BoxCollider col in m_Collider)
            {
                col.enabled = false;
            }        
        }
        else
        {
            // Play a different sound if the door is locked
            audioSource.clip = doorLocked;
            audioSource.Play();
        }
	}

	public void Unlock () {
        /// Called from Key.OnKeyClicked(), i.e. the Key.cs script, when the 'Key' game object is clicked
        /// - Unlocks the door when collecting two keys
        keyCount++;
        if(keyCount >= 2)
        {
            locked = false;
        }
        
	}
}
