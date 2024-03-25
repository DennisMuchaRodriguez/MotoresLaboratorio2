using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    public int Life;
    public GameObject[] Lifes;
    public Contador contador;
    void Start()
    {

        ActivateLives();
    }

    void Update()
    {

    }

    public void Vidas()
    {

        for (int i = 0; i < Lifes.Length; i++)
        {
            Lifes[i].SetActive(false);
        }


        for (int i = 0; i < Life; i++)
        {
            Lifes[i].SetActive(true);
        }
        if (Life < 1)
        {
            contador.CambiarEscenaGameOver();
        }
    }


    void ActivateLives()
    {
        for (int i = 0; i < Lifes.Length; i++)
        {
            Lifes[i].SetActive(true);
        }
    }
}
