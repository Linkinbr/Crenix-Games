using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSlot : MonoBehaviour
{
    public bool encaixado = false;

    private int childCount;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void UpdateEncaixe()
    {
        if(!encaixado)
        {
            childCount = transform.childCount;
            for(int i = 0; i < childCount; i++)
            {
                //Debug.Log(i);
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
