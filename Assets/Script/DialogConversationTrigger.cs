using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConversationTrigger : MonoBehaviour
{
	public Conversation conversation;
	

	public void TriggerDialogue()
	{
		
		
			FindObjectOfType<DialogDisplay>().StartConversation(conversation);
		
			
			
		}
		
		
	}

