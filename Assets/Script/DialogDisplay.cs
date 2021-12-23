using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{

    private Conversation conversationAssign;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public Animator animator;

    private Queue<string> sentences;

    private int activeLineIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Conversation").GetComponent<Animator>();
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
    }

	public void StartConversation(Conversation conversation)
	{
		if(activeLineIndex < conversation.lines.Length)
        {
            conversationAssign = conversation;
			speakerUILeft.Speaker = conversation.speakerLeft;
			speakerUIRight.Speaker = conversation.speakerRight;
			animator.SetBool("IsOpen", true);
			DisplayNextSentence();
			
        }
        else
        {
			animator.SetBool("IsOpen", false);
			activeLineIndex = 0;
        }
	}

	public void DisplayNextSentence()
	{
		if (activeLineIndex == conversationAssign.lines.Length)
		{
			EndDialogue();
			return;
		}
		Line line = conversationAssign.lines[activeLineIndex];
		CharacterUI character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
			activeLineIndex += 1;
			SetDialog(speakerUILeft, speakerUIRight, line.text);
		}
        else
        {
			activeLineIndex += 1;
			SetDialog(speakerUIRight, speakerUILeft, line.text);
		}
	}

	void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
		activeSpeakerUI.Show();
		inactiveSpeakerUI.Hide();
		activeSpeakerUI.Dialog = text;
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		Player.inDialog = false;
		activeLineIndex = 0;
	}
}
