using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {

    private AudioSource source;
    public AudioClip coinsound;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public Text reset;

    private void Start()
    {
        reset.text = "";
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
            reset.text = "Press R to Restart";
        }
    }
}
