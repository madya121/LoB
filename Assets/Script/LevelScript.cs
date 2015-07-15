using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	public ChatMessageScript oneChatMessage, zeroChatMessage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ClearOneChat() {
		oneChatMessage.Speak("");
	}
	
	public void ClearZeroChat() {
		zeroChatMessage.Speak("");
	}
	
	public void OneSpeak(string message) {
		oneChatMessage.Speak(message);
	}
	
	public void ZeroSpeak(string message) {
		zeroChatMessage.Speak(message);
	}
}
