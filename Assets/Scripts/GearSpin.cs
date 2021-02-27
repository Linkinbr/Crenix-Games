using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpin : MonoBehaviour
{
    public bool horario = false;
    public bool antiHorario = false;

    public Game gameController;

    void Start()
    {

    }

    void Update()
    {
        if(gameController.taskFeita && horario)
        {
            this.transform.Rotate(0, 0, -30 * Time.deltaTime);

        }  else if(gameController.taskFeita && antiHorario)
        {
            this.transform.Rotate(0, 0, 30 * Time.deltaTime);
        }
    }
}
