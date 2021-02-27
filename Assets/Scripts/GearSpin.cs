using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpin : MonoBehaviour
{

    public Game gameController;

    void Start()
    {

    }

    void Update()
    {
        if(gameController.taskFeita)
        {
            this.transform.Rotate(0, 0, 30 * Time.deltaTime);
        }  
    }
}
