using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [Header("SplashScreen Configuration:")]
    public GameObject uISplash;
    public GameObject splashLogo;
    public float splashInitialOpacity = 0f;
    public float splashFinalOpacity = 0f;
    public float splashDuration = 0f;
    public float splashDelaytoStart = 0f;
    public float splashDelaytoEnd = 0f;
    public float splashScale = 0f;
    public float splashChangeTime = 0f;
    [Header("Welcome Configuration:")]
    public GameObject uIWelcomeScreen;
    public float welcomeSoundDelay = 0f;
    public float welcomeInitialOpacity = 0f;
    public float welcomeFinalOpacity = 0f;
    public float welcomeDuration = 0f;
    public float welcomeDelaytoStart = 0f;
    public float welcomeDelaytoEnd = 0f;
    [Header("Main Menu Configuration:")]
    public GameObject uIMainMenu;
    [Header("About Configuration:")]
    public GameObject uIAbout;
    [Header("GameOver Configuration:")]
    public GameObject uIGameOver;

    // Fecha o jogo
    public void CloseGame()
	{
        Application.Quit();
    }
    // Animação da Splash Screen
    public IEnumerator SplashScreen(){
        // Mostra a logo
        LeanTween.alpha(splashLogo.GetComponent<RectTransform>(), splashInitialOpacity, splashDuration).setDelay(splashDelaytoStart);
        // Escala a logo
        LeanTween.scale(splashLogo.GetComponent<RectTransform>(), splashLogo.GetComponent<RectTransform>().localScale * splashScale, splashDuration).setDelay(splashDelaytoStart);
        // Esconde a logo
        LeanTween.alpha(splashLogo.GetComponent<RectTransform>(), splashFinalOpacity, splashDuration).setDelay(splashDelaytoStart + splashDelaytoEnd);
        // Tempo a ser esperado antes de passa para a próxima tarefa
        yield return new WaitForSeconds(splashChangeTime);
        // Desabilita a UI da splash Screen
        uISplash.SetActive(false);
        // Troca para a tela de welcome
        StartCoroutine(WelcomeScreen());
    }
    private IEnumerator WelcomeScreen(){
        // Ativa a tela de Welcome
        uIWelcomeScreen.SetActive(true);
        // Mostra o conteudo
        LeanTween.alphaCanvas(uIWelcomeScreen.GetComponent<CanvasGroup>(), welcomeInitialOpacity, welcomeDuration).setDelay(welcomeDelaytoStart);
        // Espera antes de tocar o som
        yield return new WaitForSeconds(welcomeSoundDelay);
        // Esconde o conteudo
        LeanTween.alphaCanvas(uIWelcomeScreen.GetComponent<CanvasGroup>(), welcomeFinalOpacity, welcomeDuration).setDelay(welcomeDelaytoEnd);
        yield return null;
    }
    public IEnumerator ResetUI(){
        // Desativas as UI's
        uIWelcomeScreen.SetActive(false);
        uIMainMenu.SetActive(false);
        uIAbout.SetActive(false);
        uIGameOver.SetActive(false);
        // Define o conteudo das UI's como transparente
        LeanTween.alphaCanvas(uIWelcomeScreen.GetComponent<CanvasGroup>(), 0f, 0f).setDelay(0f);
        // Ativa a splashScreen
        uISplash.SetActive(true);
        // Esconde a logo da splashScreen
        LeanTween.alpha(splashLogo.GetComponent<RectTransform>(), 0f, 0f).setDelay(0f);
        yield return null;
    }
}
