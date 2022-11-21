using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    Bank bankScript;

    void Awake()
    {
        bankScript = FindObjectOfType<Bank>();
    }

    public void Reload()
    {
        bankScript.ReloadScene();
    }
}
