using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public void QuitToMain()
    {
        Application.LoadLevel("Main");
    }
}
