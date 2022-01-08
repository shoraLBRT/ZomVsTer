using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DialogTrigger : MonoBehaviour
{
    public DialogParameters dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
