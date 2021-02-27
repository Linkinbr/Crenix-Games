using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public Text balaoFala;

    public bool taskFeita = false;

    public GameObject[] gearSlots;

    void Start()
    {
        balaoFala.text = "ENCAIXE AS ENGRENAGENS EM QUALQUER ORDEM";
    }

    public void UpdateEncaixados()
    {
        for(int i = 0; i < gearSlots.Length; i++)
        {
            if(gearSlots[i].GetComponent<GearSlot>().encaixado == false)
            {
                balaoFala.text = "ENCAIXE AS ENGRENAGENS EM QUALQUER ORDEM";
                taskFeita = false;
                return;
            }
        }

        balaoFala.text = "YAY, PARABÉNS. TASK CONCLUÍDA!";
        taskFeita = true;
        return;
    }

    public void Reset()
    {
        SceneManager.LoadScene("Game");
    }
}
