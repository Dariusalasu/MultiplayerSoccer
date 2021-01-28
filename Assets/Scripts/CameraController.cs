using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private GameObject cameraOne, cameraTwo;
    AudioListener cameraOneAudio, cameraTwoAudio;
    private int curCamera = 1;
    // Start is called before the first frame update
    void Start() {
        cameraOneAudio = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudio = cameraTwo.GetComponent<AudioListener>();
    } // End of Start

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.C)) {
            if(curCamera == 1) {
                cameraTwo.SetActive(true);
                cameraTwoAudio.enabled = true;

                cameraOne.SetActive(false);
                cameraOneAudio.enabled = false;

                curCamera = 2;
            } else if(curCamera == 2) {
                cameraOne.SetActive(true);
                cameraOneAudio.enabled = true;

                cameraTwo.SetActive(false);
                cameraTwoAudio.enabled = false;
                
                curCamera = 1;
            }
        }
    } // End of Update
}
