using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class AnimacionCartas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialScale;

    public Image spriteSeleccionado;
    public Image spriteSeleccionado2;
    public Image spriteSeleccionado3;
    public Image spriteSeleccionado4;
    public Image spriteSeleccionado5;
    public Image spriteSeleccionado6;
    public Combat combatScript;

    void Start()
    {
        spriteSeleccionado.gameObject.SetActive(false);
        spriteSeleccionado2.gameObject.SetActive(false);
        spriteSeleccionado3.gameObject.SetActive(false);
        spriteSeleccionado4.gameObject.SetActive(false);
        spriteSeleccionado5.gameObject.SetActive(false);
        spriteSeleccionado6.gameObject.SetActive(false);

        initialScale = transform.localScale; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (!gameObject.activeInHierarchy)
        //{
        //    return;
        //}

        LeanTween.scale(gameObject, initialScale * 1.2f, 0.2f);

        //spriteSeleccionado.gameObject.SetActive(true);
        
        spriteSeleccionado.transform.position = transform.position;
        spriteSeleccionado2.transform.position = transform.position;
        spriteSeleccionado3.transform.position = transform.position;
        spriteSeleccionado4.transform.position = transform.position;
        spriteSeleccionado5.transform.position = transform.position;
        spriteSeleccionado6.transform.position = transform.position;

        if (combatScript.button1.interactable == false)
        {
            spriteSeleccionado.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(combatScript.button1.interactable == true)
        {
            spriteSeleccionado.GetComponent<Image>().gameObject.SetActive(true);
        }
        if (combatScript.button2.interactable == false)
        {
            spriteSeleccionado2.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(combatScript.button2.interactable == true)
        {
            spriteSeleccionado2.GetComponent<Image>().gameObject.SetActive(true);
        }
        if (combatScript.button3.interactable == false)
        {
            spriteSeleccionado3.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(combatScript.button3.interactable == true)
        {
            spriteSeleccionado3.GetComponent<Image>().gameObject.SetActive(true);
        }
        if (combatScript.button4.interactable == false)
        {
            spriteSeleccionado4.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(combatScript.button4.interactable == true)
        {
            spriteSeleccionado4.GetComponent<Image>().gameObject.SetActive(true);
        }
        if (combatScript.button5.interactable == false)
        {
            spriteSeleccionado5.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(combatScript.button5.interactable == true)
        {
            spriteSeleccionado5.GetComponent<Image>().gameObject.SetActive(true);
        }
        if (combatScript.button6.interactable == false)
        {
            spriteSeleccionado6.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(combatScript.button6.interactable == true)
        {
            spriteSeleccionado6.GetComponent<Image>().gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       

        LeanTween.scale(gameObject, initialScale, 0.2f);

        spriteSeleccionado.gameObject.SetActive(false);
        spriteSeleccionado2.gameObject.SetActive(false);
        spriteSeleccionado3.gameObject.SetActive(false);
        spriteSeleccionado4.gameObject.SetActive(false);
        spriteSeleccionado5.gameObject.SetActive(false);
        spriteSeleccionado6.gameObject.SetActive(false);




    }
}
