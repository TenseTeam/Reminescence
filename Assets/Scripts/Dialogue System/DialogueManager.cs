using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI m_NPCName;
    [SerializeField] private TextMeshProUGUI m_DialogueTextBox;
    [SerializeField] private Animator m_Animator;
	[SerializeField] private List<Dialogue> m_DialogueList;

	private Dialogue m_ActualDialogue;
	private Queue<string> m_CurrentText;
	private int m_CurrentMonologueIndex;

	// Use this for initialization
	void Start () {
		m_CurrentText = new Queue<string>();
	}

	public void StartDialogue(int indexDialogue)
	{
        m_Animator.SetBool("IsOpen", true);

        m_ActualDialogue = m_DialogueList[indexDialogue];

		StartMonologue();
    }

	public void StartMonologue()
	{
        m_NPCName.text = m_ActualDialogue.DialogueParts[m_CurrentMonologueIndex].name;

		m_CurrentText.Clear();

		foreach (string sentence in m_ActualDialogue.DialogueParts[m_CurrentMonologueIndex].sentences)
		{
			m_CurrentText.Enqueue(sentence);
        }

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (m_CurrentText.Count == 0)
		{
			if (m_CurrentMonologueIndex < m_ActualDialogue.DialogueParts.Length - 1)
			{
				m_CurrentMonologueIndex++;
				StartMonologue();
            }
            else
			{
				EndDialogue();
				return;
			}
		}

		string sentence = m_CurrentText.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		m_DialogueTextBox.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			m_DialogueTextBox.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		m_Animator.SetBool("IsOpen", false);
		m_ActualDialogue = null;
        m_CurrentMonologueIndex = 0;
    }
}
