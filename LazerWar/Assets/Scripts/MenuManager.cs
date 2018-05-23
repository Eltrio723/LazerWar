using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.SocialPlatforms;
using System;

public class MenuManager : MonoBehaviour, RealTimeMultiplayerListener {

	// Use this for initialization
	void Start () {
        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

	}
	

    public void LogIn() {
        Social.localUser.Authenticate((bool success) => {
            if (success == true) {
                Debug.Log("Login success");
            }
            else {
                Debug.Log("Login failed");
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
