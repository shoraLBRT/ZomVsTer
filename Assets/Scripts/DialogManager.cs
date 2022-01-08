using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _helpText2;
    // Для красивого появления символов
    [SerializeField]
    private Text NameTextForTyping;
    [SerializeField]
    private Text DialogTextForTyping;
    //
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<GameObject> speakers; 
    public Animator animator;

    private GameObject speaker;

    // Дополнительные переменные для реализации удобного, расширяемого диалогового менеджера.
    private int _countOfDialogs;
    private GameObject _deletedSpeaker;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        speakers = new Queue<GameObject>();
    }

    public void StartDialog(DialogParameters dialog)
    {
        _helpText2.SetActive(false);
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
        _countOfDialogs = sentences.Count; // Запоминаем общее количество реплик. Ниже будем от этого числа отталкиваться.
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (sentences.Count == 0 & names.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        if (speakers.Count < _countOfDialogs) // проверяем, если у нас уже была хотя бы одна реплика, значит надо спрятать спикера из прошлой реплики.
        {
            HideSpeaker();
        }
        speaker = speakers.Peek();
        _deletedSpeaker = speakers.Dequeue();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeName(name));
        ShowSpeaker(speaker);
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogTextForTyping.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogTextForTyping.text += letter;
            yield return null;
        }
    }
    IEnumerator TypeName(string name)
    {
        NameTextForTyping.text = "";
        foreach (char letter in name.ToCharArray())
        {
            NameTextForTyping.text += letter;
            yield return null;
        }
    }
    private void ShowSpeaker(GameObject speaker)
    {
        speaker.SetActive(true);
    }
    private void HideSpeaker()
    {
        _deletedSpeaker.SetActive(false);
    }

    private void EndDialog()
    {
        animator.SetBool("isOne", false);
        speaker.SetActive(false);
    }
}
