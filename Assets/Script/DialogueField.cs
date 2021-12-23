using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
        dialogTriggered = true;
        ofObject = GetComponent<DialogTrigger>();
        ofObjectC = GetComponent<DialogConversationTrigger>();
    }

    private void FixedUpdate()
    {
        enteredRoomDialogue();
    }

    public void enteredRoomDialogue()
    {
        if (Player.inDialog==false) {
            Collider2D playerCollider = Physics2D.OverlapCircle(this.transform.position, 2, playerMask);

            // Found Player
            if (playerCollider)
            {
                Debug.Log("inside");
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Debug.Log("pressed");
                    Player player = playerCollider.GetComponent<Player>();
                    if (player)
                    {
                        Player.inDialog = true;
                        if (ofObjectC == null)
                        {
                            ofObject.TriggerDialogue();
                        }
                        else
                        {
                            ofObjectC.TriggerDialogue();
                        }

                        
                    }
                }
                
            }
        }
        
    }
}
