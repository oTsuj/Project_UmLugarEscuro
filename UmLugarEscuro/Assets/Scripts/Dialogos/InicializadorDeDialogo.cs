using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorDeDialogo : MonoBehaviour
{
   [SerializeField] 
   private GerenciadorDialogos _gerenciador;
   [SerializeField] 
   private Dialogo _dialogo;

   public void Inicializa()
   {
      if (_gerenciador == null)
         return;
      _gerenciador.Inicializa(_dialogo);
   }
}
