using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GerenciadorJogo : MonoBehaviour
{
    const string PARTIDA_XML_CAMINHO = "partida.xml";

    ControladorCorredor jogador1;
    ControladorCorredor jogador2;

    void Start()
    {
        ControladorCorredor[] ccs = FindObjectsOfType<ControladorCorredor>();
        jogador1 = ccs[0];
        jogador2 = ccs[1];

        jogador1.Setup(true);
        jogador2.Setup(false);
    }

    void OnApplicationQuit()
    {
        FabricaXML fabricaXml = new FabricaXML();
        fabricaXml.EscreverXML(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO, DadosJogo.partida);
    }
}
