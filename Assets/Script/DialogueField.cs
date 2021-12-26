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
    public static GameObject interactIcon;
    public static bool insideOfOneZone;

    public Vector2 dashDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        interactIcon = GameObject.Find("InteractIcon");
    }
    void Start()
    {
        interactIcon.SetActive(false);
        insideOfOneZone = false;
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
        if (insideOfOneZone&&!Player.inDialog)
        {
            interactIcon.SetActive(true);
        }
        if (!insideOfOneZone)
        {
            interactIcon.SetActive(false);
        }
        if (Player.inDialog)
        {
            interactIcon.SetActive(false);
        }




        if (Player.inDialog==false) {
            Collider2D playerCollider = Physics2D.OverlapCircle(this.transform.position, 1, playerMask);
           
            // Found Player
            if (playerCollider)
            {
                
                if (Input.GetKey(KeyCode.UpArrow))
                {
                 
                    Player player = playerCollider.GetComponent<Player>();
                    if (player)
                    {

                        interactIcon.SetActive(false);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            insideOfOneZone = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            insideOfOneZone = false;
        }
           
    }
}
