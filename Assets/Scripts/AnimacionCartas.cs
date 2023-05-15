using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class AnimacionCartas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialScale;

    public Image spriteSeleccionado;

    public Combat combatScript;

    void Start()
    {
        spriteSeleccionado.gameObject.SetActive(false);
        
        initialScale = transform.localScale; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }


        LeanTween.scale(gameObject, initialScale * 1.2f, 0.2f);


        spriteSeleccionado.gameObject.SetActive(true);
        
        spriteSeleccionado.transform.position = transform.position;
       
        if(combatScript.button1.interactable == false)
        {
            spriteSeleccionado.gameObject.SetActive(false);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
       

        LeanTween.scale(gameObject, initialScale, 0.2f);

        spriteSeleccionado.gameObject.SetActive(false);
        



    }
}
