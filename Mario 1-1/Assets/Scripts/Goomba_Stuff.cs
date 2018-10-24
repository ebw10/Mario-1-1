using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba_Stuff : MonoBehaviour {

    private Animator anim;

    public float speed;

    public LayerMask isGround;

    public Transform wallHitBox;

    private bool wallHit;

    public float wallHitHeight;
    public float wallHitWidth;

    private AudioSource source;
    public AudioClip GoombaDeathsound;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if (wallHit == true)
        {
            speed = speed * -1;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin_Free"))
        {

            collision.gameObject.SetActive(false);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(GoombaDeathsound);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }
}
