using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

	public Dialog dialogue;

    public void TriggerDialogue()
	{
		if (dialogue.hasPlayed == false)
        {
			FindObjectOfType<DialogManager>().StartDialogue(dialogue);
			dialogue.hasPlayed = true;
			Destroy(this.gameObject);
        }
        else
        {
			Player.inDialog = false;
			Destroy(this.gameObject);
		}
		
	}

}
