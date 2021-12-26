using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
	// Declaração de Variáveis
    public GameObject uI_Manager;
	// Primeiro Método a ser chamado que só é executado uma vez
    void Awake()
	{
		// Reseta a UI
		StartCoroutine(uI_Manager.GetComponent<UI_Manager>().ResetUI());
		// Inicia a Ui da Splash Screen
		StartCoroutine(uI_Manager.GetComponent<UI_Manager>().SplashScreen());
	}
}
