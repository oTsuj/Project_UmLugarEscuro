using UnityEngine;

public class AtivarLaser : MonoBehaviour
{
    private float tempoAtivo = 4f;
    private float tempoInativo = 2f;
    private bool ativo = true;

    private void Start()
    {
        // Inicia o comportamento com o objeto ativo
        AtivarObjeto();
    }

    private void AtivarObjeto()
    {
        ativo = true;
        gameObject.SetActive(true);
        Invoke("DesativarObjeto", tempoAtivo);
    }

    private void DesativarObjeto()
    {
        ativo = false;
        gameObject.SetActive(false);
        Invoke("AtivarObjeto", tempoInativo);
    }

    // Opcional: você pode adicionar métodos para ativar e desativar manualmente o objeto se necessário
    public void AtivarManualmente()
    {
        if (!ativo)
        {
            AtivarObjeto();
        }
    }

    public void DesativarManualmente()
    {
        if (ativo)
        {
            DesativarObjeto();
        }
    }
}

