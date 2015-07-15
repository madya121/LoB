using UnityEngine;
using System.Collections;

public class ChatMessageScript : MonoBehaviour {

	public float timePerCharacter = 0.1f;
	public string message = "";
	
	string messageNow = "";
	int index = 0;
	TextMesh textMesh;
	AudioSource sfx;

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().sortingOrder = 10;
		textMesh = GetComponent<TextMesh>();
		message = textMesh.text;
		textMesh.text = string.Empty;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ShowMessage() {
		if (index < message.Length) {
			messageNow = messageNow + message.ToCharArray()[index];
			textMesh.text = messageNow;
			index++;
		}
	}
	
	public void SpeakNow() {
		timePerCharacter = 0.5f / (float)message.Length;
		InvokeRepeating("ShowMessage", timePerCharacter, timePerCharacter);
	}
	
	public void Speak(string _message) {
		timePerCharacter = 1.0f / (float)_message.Length;
	
		CancelInvoke();
		InvokeRepeating("ShowMessage", timePerCharacter, timePerCharacter);
		message = _message;
		messageNow = string.Empty;
		textMesh.text = messageNow;
		index = 0;
	}
}
