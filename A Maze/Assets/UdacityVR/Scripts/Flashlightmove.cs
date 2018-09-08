using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlightmove : MonoBehaviour {

    private Transform myTransform;

    public Transform pivot;
    public Transform master;
    public float ratioX;
    public float ratioY;
    public float ratioZ;
    private bool inizialized;

    void Start()
    {
        myTransform = transform;
    }

    public void Initialize(Transform pivot, Transform master, float ratioX, float ratioY, float ratioZ)
    {
        this.pivot = pivot;
        this.master = master;
        this.ratioX = ratioX;
        this.ratioY = ratioY;
        this.ratioZ = ratioZ;
        inizialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inizialized)
        {
            return;
        }
        if (master != null)
        {
            Vector3 position = master.position - pivot.position;
            Vector3 newPosition = new Vector3();
            newPosition.x = ratioX * position.x;
            newPosition.y = ratioY * position.y;
            newPosition.z = ratioZ * position.z;
            myTransform.localPosition = newPosition;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
