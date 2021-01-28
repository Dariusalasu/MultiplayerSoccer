using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostController : MonoBehaviour {
    [SerializeField] private AudioClip mAudio;
    private AudioSource mAudioSource;

    // Start is called before the first frame update
    void Start() {
        mAudioSource = GetComponent<AudioSource>();
    } // End of Start

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "SoccerBall") {
            mAudioSource.PlayOneShot(mAudio);
        } else {
            Debug.Log(other.gameObject.name);
        }
    } // End of OnTriggerEnter
}
