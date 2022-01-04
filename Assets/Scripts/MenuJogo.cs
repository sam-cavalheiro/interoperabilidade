using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuJogo : MonoBehaviour
{
    const string PARTIDA_XML_CAMINHO = "partida.xml";

    [SerializeField] int cenaJogoId = 1;
    [SerializeField] GameObject selecaoCorHolder;
    [SerializeField] GameObject partidaEncontradaHolder;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO))
        {
            partidaEncontradaHolder.SetActive(true);
        }
        else
        {
            selecaoCorHolder.SetActive(true);
        }
    }

    public void Comando_ComecarNovaPartida()
    {
        SelecaoCor[] selecaoCores = FindObjectsOfType<SelecaoCor>();

        Partida partida = new Partida();
        partida.Corredor1.Cor = selecaoCores[0].GetColor();
        partida.Corredor2.Cor = selecaoCores[1].GetColor();

        int.TryParse(FindObjectOfType<TMPro.TMP_InputField>().text, out int voltas);
        print(">>>> voltas: " + voltas);

        partida.MaximoVoltas = Mathf.Max(voltas, 1);

        DadosJogo.partida = partida;
        SceneManager.LoadScene(cenaJogoId);
    }

    public void Comando_RetomarPartida()
    {
        FabricaXML fabricaXml = new FabricaXML();
        string xml = fabricaXml.LerXMLDeArquivo(Directory.GetCurrentDirectory() + '/' + PARTIDA_XML_CAMINHO);
        DadosJogo.partida = fabricaXml.ConverterXMLParaPartida(xml);
        DadosJogo.carregouPorArquivo = true;

        SceneManager.LoadScene(cenaJogoId);
    }

    public void Comando_NaoRetomarPartida()
    {
        selecaoCorHolder.SetActive(true);
        partidaEncontradaHolder.SetActive(false);
    }
}
