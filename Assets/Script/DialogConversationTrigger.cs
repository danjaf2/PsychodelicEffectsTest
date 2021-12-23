using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConversationTrigger : MonoBehaviour
{
	public Conversation conversation;
	

	public void TriggerDialogue()
	{
		if (conversation.hasPlayed == false)
        {
			
			FindObjectOfType<DialogDisplay>().StartConversation(conversation);
			conversation.hasPlayed = true;
			Destroy(this.gameObject);
		}
		else if (conversation.hasPlayed == true)
        {
			Player.inDialog = false;
			Destroy(this.gameObject);
		}
		
	}
}
