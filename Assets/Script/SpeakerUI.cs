using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{
    public Image portrait;
    public TextMeshProUGUI fullName;
    public TextMeshProUGUI dialog;

    private CharacterUI speaker;
    public CharacterUI Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            fullName.text = speaker.fullName;
        }
    }
    public string Dialog
    {
        set {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialog.text = value));
        }
        get
        {
            return Dialog;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialog.text = "";
        GameObject enemy= GameObject.Find("EnemyImage");
        foreach (char letter in sentence.ToCharArray())
        {
            dialog.text += letter;
            //Play sound
            if (enemy != null)
            {
                enemy.GetComponent<Animator>().SetBool("isTalking", true);
            }
            
            yield return new WaitForSeconds(0.05f);
        }
        if (enemy != null)
        {
            enemy.GetComponent<Animator>().SetBool("isTalking", false);
        }
    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(CharacterUI character)
    {
        return speaker == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
