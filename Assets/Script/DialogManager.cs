using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		animator = GameObject.Find("DialogPanel").GetComponent<Animator>();
		nameText = GameObject.Find("NameOfSpeeker").GetComponent<TextMeshProUGUI>();
		dialogueText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialog dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		Player.inDialog = false;
	}

}
