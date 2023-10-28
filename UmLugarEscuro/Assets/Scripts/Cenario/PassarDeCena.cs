using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarDeCena : MonoBehaviour
{
    public string targetSceneName; // O nome da cena para a qual o jogador será teleportado

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto de colisão é o jogador
        {
            // Teleporta o jogador para a cena alvo
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

