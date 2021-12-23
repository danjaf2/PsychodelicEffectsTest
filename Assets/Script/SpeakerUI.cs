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
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialog.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialog.text += letter;
            yield return null;
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
