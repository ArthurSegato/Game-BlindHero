using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
	// Declara��o de Vari�veis
    public GameObject uI_Manager;
	// Primeiro M�todo a ser chamado que s� � executado uma vez
    void Awake()
	{
		// Reseta a UI
		StartCoroutine(uI_Manager.GetComponent<UI_Manager>().ResetUI());
		// Inicia a Ui da Splash Screen
		StartCoroutine(uI_Manager.GetComponent<UI_Manager>().SplashScreen());
	}
}
