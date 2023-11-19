using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controlador_Cutscene : MonoBehaviour
{
    public float imageDisplayTime = 5.0f; // Tempo de exibição de cada imagem
    public string tutorialSceneName;
    private int currentImageIndex = 0;
    private float currentTime = 0;

    public Canvas cutsceneCanvas;
    public Image[] cutsceneImages;

    void Start()
    {
        Time.timeScale = 1;
        ShowNextImage();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= imageDisplayTime)
        {
            currentTime = 0;
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        if (currentImageIndex < cutsceneImages.Length)
        {
            cutsceneImages[currentImageIndex].gameObject.SetActive(true);
            currentImageIndex++;
        }
        else
        {
            // Todas as imagens da cutscene foram exibidas
            SceneManager.LoadScene(tutorialSceneName);
        }
    }
}
