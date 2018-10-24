using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinbox : MonoBehaviour {

   
    private AudioSource source;
    public AudioClip coinsound;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private bool wallHit;
    public Transform wallHitBox;
    public Text pointstext;
    //private int points;

    public float wallHitHeight;
    public float wallHitWidth;
    private int enter = 0;

    private void Start()
    {
       // SetCountText();
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && enter < 3)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinsound);
            enter++;
            PlayerCont.points++;
            Debug.Log(PlayerCont.points);
            SetCountText();
        }

        else 
        {
            if (enter >= 3)
            {
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(coinsound);
                gameObject.SetActive(false);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }

    void SetCountText()
   {
        pointstext.text = "Points: " + PlayerCont.points.ToString();
   }


}
