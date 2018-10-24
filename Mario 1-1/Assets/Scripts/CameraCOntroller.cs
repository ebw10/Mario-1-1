using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCOntroller : MonoBehaviour {

    public Transform player;

    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
		//position = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
}
