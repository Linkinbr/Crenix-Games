using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public int colorID = 0; // 0: Roxo, 1: Amarelo, 2: Verde, 3: Azul, 4: Roxo Escuro
    public Vector3 startPos;
    public bool canDrop = false;

    public Game gameController;

    public GameObject dropSlot;
    void Start()
    {
        startPos = transform.localPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        var tempColor = this.gameObject.GetComponent<Image>().color;
        tempColor.a = 1f;
        this.gameObject.GetComponent<Image>().color = tempColor;
        gameController.UpdateEncaixados();
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(canDrop == true && dropSlot != null)
        {
            if(dropSlot.GetComponent<GearSlot>().encaixado == false)
            {
                dropSlot.transform.GetChild(colorID).gameObject.SetActive(true);
                dropSlot.GetComponent<GearSlot>().encaixado = true;
                var tempColor = this.gameObject.GetComponent<Image>().color;
                tempColor.a = 0f;
                this.gameObject.GetComponent<Image>().color = tempColor;
                dropSlot.GetComponent<GearSlot>().UpdateEncaixe();
                gameController.UpdateEncaixados();
            }
            
        } else {
            transform.localPosition = startPos;
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.gameObject.GetComponent<GearSlot>() != null)
        {
            canDrop = true;
            dropSlot = col.transform.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.transform.gameObject.GetComponent<GearSlot>() != null  && dropSlot != null)
        {
            dropSlot.GetComponent<GearSlot>().encaixado = false;
            dropSlot.GetComponent<GearSlot>().UpdateEncaixe();
        }
        canDrop = false;
        dropSlot = null;
        var tempColor = this.gameObject.GetComponent<Image>().color;
        tempColor.a = 1f;
        this.gameObject.GetComponent<Image>().color = tempColor;
        gameController.UpdateEncaixados();
    }
}
