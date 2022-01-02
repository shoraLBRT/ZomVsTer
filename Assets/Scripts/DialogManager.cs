using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text NameText;
    public Text DialogText;
    private GameObject speakerWindow;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<GameObject> speakers; 
    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        speakers = new Queue<GameObject>();
    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("isOne", true);
        sentences.Clear();
        names.Clear();
        speakers.Clear();

        foreach (string name in dialog.names)
        {
            names.Enqueue(name);
        }
        foreach (GameObject speaker in dialog.speakers)
        {
            speakers.Enqueue(speaker);
        }
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 & names.Count == 0)
        {
            EndDialog();
            return;
        }
        
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        GameObject speaker = speakers.Dequeue();
        speaker.SetActive(false);
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeName(name));
        showSpeaker(speaker);
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return null;
        }
    }
    IEnumerator TypeName(string name)
    {
        NameText.text = "";
        foreach (char letter in name.ToCharArray())
        {
            NameText.text += letter;
            yield return null;
        }
    }
    private void showSpeaker(GameObject speaker)
    {
        speaker.SetActive(true);
    }

    public void EndDialog()
    {
        animator.SetBool("isOne", false);
    }
}
