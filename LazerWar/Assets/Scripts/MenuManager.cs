using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.SocialPlatforms;
using System;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, RealTimeMultiplayerListener {


    public Text text;

	// Use this for initialization
	void Start () {

        text.text = "prueba";

        /*PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
        // registers a callback to handle game invitations received while the game is not running.
        //.WithInvitationDelegate(< callback method >)
        // registers a callback for turn based match notifications received while the
        // game is not running.
        //.WithMatchDelegate(< callback method >)
        // requests the email address of the player be available.
        // Will bring up a prompt for consent.
        .RequestEmail()
        // requests a server auth code be generated so it can be passed to an
        //  associated back end server application and exchanged for an OAuth token.
        .RequestServerAuthCode(false)
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();

        text.text = "config";

        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        text.text = "Initialized";
        PlayGamesPlatform.Activate();
        text.text = "Activated";*/
        /*Social.localUser.Authenticate((bool success) => {
            if (success == true) {
                Debug.Log("Login success");
                text.text = "Success";
            }
            else {
                Debug.Log("Login failed");
                text.text = "Failed";
            }
        });*/

    }

    public void SignInCallback(bool success) {
        text.text = "Callback";
        if (success == true) {
            Debug.Log("Login success");
            text.text = "Success";
        }
        else {
            Debug.Log("Login failed");
            text.text = "Failed";
        }
    }

    public void SignIn() {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
        // registers a callback to handle game invitations received while the game is not running.
        //.WithInvitationDelegate(< callback method >)
        // registers a callback for turn based match notifications received while the
        // game is not running.
        //.WithMatchDelegate(< callback method >)
        // requests the email address of the player be available.
        // Will bring up a prompt for consent.
        .RequestEmail()
        // requests a server auth code be generated so it can be passed to an
        //  associated back end server application and exchanged for an OAuth token.
        .RequestServerAuthCode(true)
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();

        text.text = "config";

        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        text.text = "Initialized";
        PlayGamesPlatform.Activate();
        text.text = "Activated";


        text.text = "SignIn";
        if (!PlayGamesPlatform.Instance.localUser.authenticated) {
            text.text = "Correcto";
            Debug.Log("-----------------------------------------------------");
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
            Debug.Log("****************************************************");
            text.text = "Correcto_despues";
        }
        else {
            text.text = "Incorrecto";
            PlayGamesPlatform.Instance.SignOut();
        }
    }
	

    public void LogIn() {
        /*Social.localUser.Authenticate((bool success) => {
            if (success == true) {
                Debug.Log("Login success");
            }
            else {
                Debug.Log("Login failed");
            }
        });*/
        /*PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();*/
        Debug.Log("****************************************************");
        PlayGamesPlatform.Instance.Authenticate((bool success) => {
            Debug.Log("****************************************************");
            Debug.Log(success);
            Debug.Log("****************************************************");
            if (success == true) {
                Debug.Log("Login success");
                text.text = "Success";
            }
            else {
                Debug.Log("Login failed");
                text.text = "Failed";
            }
        });
    }

    public void CreateQuickGame() {
        const int minOpponents = 1, maxOpponents = 1;
        const int gameType = 0;

        PlayGamesPlatform.Instance.RealTime.CreateQuickGame(minOpponents, maxOpponents, gameType, this);
    }

    public void CreateWithInvitationScreen() {
        const int minOpponents = 1, maxOpponents = 1;
        const int gameType = 0;

        PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen(minOpponents, maxOpponents, gameType, this);
    }

    public void OnRoomSetupProgress(float percent) {
        throw new NotImplementedException();
    }

    public void OnRoomConnected(bool success) {
        throw new NotImplementedException();
    }

    public void OnLeftRoom() {
        throw new NotImplementedException();
    }

    public void OnParticipantLeft(Participant participant) {
        throw new NotImplementedException();
    }

    public void OnPeersConnected(string[] participantIds) {
        throw new NotImplementedException();
    }

    public void OnPeersDisconnected(string[] participantIds) {
        throw new NotImplementedException();
    }

    public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data) {
        throw new NotImplementedException();
    }


}
