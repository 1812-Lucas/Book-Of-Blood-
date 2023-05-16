using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleDisplay : MonoBehaviour
{
    public Text consoleText;
    public float messageTime = 1000f;
    
    void Start()
    {
        consoleText.text = "";
        
    }

    public void Update()
    {
        
    }
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
        
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
        
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        consoleText.text += logString + "\n";
        StartCoroutine(DestroyText());
    }

    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(messageTime);
        consoleText.text = "";
    }
}
