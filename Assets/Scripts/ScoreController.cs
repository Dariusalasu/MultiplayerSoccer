using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {
    [SerializeField] private TMP_Text home1, home2, guest1, guest2;
    private int homeScore = 0, guestScore = 0;

    // Update is called once per frame
    void Update() {
        // Store integers as strings
        var tmpHome = homeScore.ToString();
        if(homeScore <= 9) {
            tmpHome = "   " + tmpHome;
        }

        var tmpGuest = guestScore.ToString();
        if(guestScore <= 9) {
            tmpGuest = "   " + tmpGuest;
        }

        // Set texts
        home1.SetText(tmpHome);
        home2.SetText(tmpHome);
        guest1.SetText(tmpGuest);
        guest2.SetText(tmpGuest);
    } // End of Update

    // updateScore:
    // Method called to increment score provided by boolean in parameter by one
    public void updateScore(bool homeGoal) {
        if(homeGoal) {
            homeScore++;
        } else {
            guestScore++;
        }
    } // End of updateScore
}
