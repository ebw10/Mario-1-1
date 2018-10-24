using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushrooms : MonoBehaviour {


    private AudioSource source;
    public AudioClip coinsound;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private bool wallHit;
    public Transform wallHitBox;

    public float wallHitHeight;
    public float wallHitWidth;
    public GameObject shroom;

    //private int enter = 1;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        shroom.gameObject.SetActive(false);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinsound);
            gameObject.SetActive(false);
            shroom.gameObject.SetActive(true);
        }

      

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }


}

