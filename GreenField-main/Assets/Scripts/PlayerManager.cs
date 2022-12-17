using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public LeaderBoard leaderBoard;
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI success;
    public TextMeshProUGUI error;
    public TextMeshProUGUI enterName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetUpRoutine());
    }

    IEnumerator SetUpRoutine()
    {
        yield return LoginRoutine();
        yield return leaderBoard.FetchTopScores();
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInput.text, (response) =>
        {
            if(playerNameInput.text == "")
            {
                enterName.gameObject.SetActive(true);
                return;
            }
            else if (playerNameInput.text != "" && response.success)
            {
                success.gameObject.SetActive(true);
            }
            else
            {
                error.gameObject.SetActive(true);
            }

        });
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                // player can still play without login
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    public void ClearError()
    {
        success.gameObject.SetActive(false);
        error.gameObject.SetActive(false);
        enterName.gameObject.SetActive(false);
    }

    public void ClearInput()
    {
        playerNameInput.text = "";
    }
}
