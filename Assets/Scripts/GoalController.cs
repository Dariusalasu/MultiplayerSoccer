using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {
    [SerializeField] private GameObject mNetwork;
    [SerializeField] private AudioClip mAudio;
    private AudioSource mAudioSource;
    private ScoreController sc;
    private List<GameObject> balls = new List<GameObject>();
    // Start is called before the first frame update
    void Start() {
        sc = mNetwork.GetComponent<ScoreController>();
        mAudioSource = GetComponent<AudioSource>();
    } // End of Start

    void OnTriggerEnter(Collider other) {
        if(!this.gameObject.CompareTag("SoccerBall")) {
            if(other.CompareTag("SoccerBall")) {
                if(!balls.Contains(other.gameObject)) {
                    balls.Add(other.gameObject);
                    sc.updateScore(this.transform.parent.gameObject.name == "goal-home");
                    playCheering();
                    StartCoroutine(resetBall(other.gameObject));
                }
            }
        } else {
            Debug.Log("Error");
        }
    } // End of OnTriggerEnter

    // playCheering:
    // Play audio for crowd cheer
    private void playCheering() {
        mAudioSource.PlayOneShot(mAudio);
    } // End of playCheering

    IEnumerator resetBall(GameObject obj) {
        yield return new WaitForSeconds(2f);
        obj.transform.position = new Vector3(Random.Range(-5f, 5f), 5, Random.Range(-5f, 5f));
        if(balls.Contains(obj)) {
            balls.Remove(obj);
        }
    } // End of resetBall
}
