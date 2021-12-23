using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueField : MonoBehaviour
{
    private bool dialogTriggered = false;

    public LayerMask playerMask;

    private DialogTrigger ofObject;
    private DialogConversationTrigger ofObjectC;

    public Vector2 dashDirection;

    // Start is called before the first frame update
    void Start()
    {
        dialogTriggered = false;
        ofObject = GetComponent<DialogTrigger>();
        ofObjectC = GetComponent<DialogConversationTrigger>();
    }

    private void FixedUpdate()
    {
        enteredRoomDialogue();
    }

    public void enteredRoomDialogue()
    {
        if (dialogTriggered == false) {
            Collider2D playerCollider = Physics2D.OverlapCircle(this.transform.position, 5, playerMask);

            // Found Player
            if (playerCollider)
            {
                Player player = playerCollider.GetComponent<Player>();
                if (player)
                {
                    //Player.inDialog = true;
                    if(ofObjectC == null)
                    {
                        ofObject.TriggerDialogue();
                    }
                    else
                    {
                        ofObjectC.TriggerDialogue();
                    }
                    
                    dialogTriggered = true;
                }
            }
        }
        
    }
}
