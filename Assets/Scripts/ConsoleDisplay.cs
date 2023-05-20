using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleDisplay : MonoBehaviour
{
    public Text consoleText;
    public float messageTime;
    public Image backgroundImage;
    
    void Start()
    {
        consoleText.text = "";
        backgroundImage.gameObject.SetActive(false);

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

        if (!string.IsNullOrEmpty(logString))
        {
            // Mostrar la imagen de fondo
            backgroundImage.gameObject.SetActive(true);

            StartCoroutine(DestroyText());
        }
       
    }

    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(messageTime);
        consoleText.text = "";

        // Ocultar la imagen de fondo si el campo de texto está vacío
        if (string.IsNullOrEmpty(consoleText.text))
        {
            backgroundImage.gameObject.SetActive(false);
        }
    }
}
