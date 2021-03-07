using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct dialogueStructure
{
    string dialogue;
    ActionChoice action;
    string[] candidateLabels;
}

public class DialogueFlow : MonoBehaviour
{
    [SerializeField]
    private dialogueStructure[] dialogues;

    [SerializeField]
    private string characterContext;
}
