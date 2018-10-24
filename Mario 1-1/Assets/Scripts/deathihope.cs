using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathihope : MonoBehaviour {

    private AudioSource source;
    public AudioClip coinsound;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public Text reset;

    private void Start()
    {
        reset.text = "";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerCont.points = 0;
            Application.LoadLevel(Application.loadedLevel);

        }
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinsound);
            other.gameObject.SetActive(false);
            reset.text = "Press R to Restart";
            
        }




    }

}
