using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuJogo : MonoBehaviour
{
    [SerializeField] int cenaJogoId = 1;
    [SerializeField] GameObject selecaoCorHolder;
    [SerializeField] GameObject partidaEncontradaHolder;
    [SerializeField] SelecaoCor selecaoCorJogador1;
    [SerializeField] SelecaoCor selecaoCorJogador2;

    string voltasInputFieldValor;

    // Start is called before the first frame update
    void Start()
    {
        string _file;
        if (DadosJogo.ARMAZENANDO_JSON)
        {
            _file = "partida.json";
        }
        else
        {
            _file = "partida.xml";
        }

        if (File.Exists(_file))
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
        Partida partida = new Partida();
        partida.Corredor1.Cor = new CleanColor(selecaoCorJogador1.GetColor());
        partida.Corredor2.Cor = new CleanColor(selecaoCorJogador2.GetColor());

        int.TryParse(voltasInputFieldValor, out int voltas);

        partida.MaximoVoltas = Mathf.Max(voltas, 1);

        DadosJogo.partida = partida;
        DadosJogo.carregouPorArquivo = false;
        SceneManager.LoadScene(cenaJogoId);
    }

    public void Comando_RetomarPartida()
    {
        if (DadosJogo.ARMAZENANDO_JSON)
        {
            FabricaJSON fabricaJson = new FabricaJSON();
            DadosJogo.partida = fabricaJson.LerJSON("partida.json");
        }
        else
        {
            FabricaXML fabricaXml = new FabricaXML();
            string xml = fabricaXml.LerXMLDeArquivo("partida.xml");
            DadosJogo.partida = fabricaXml.ConverterXMLParaPartida(xml);
        }

        DadosJogo.carregouPorArquivo = true;

        SceneManager.LoadScene(cenaJogoId);
    }

    public void Comando_NaoRetomarPartida()
    {
        selecaoCorHolder.SetActive(true);
        partidaEncontradaHolder.SetActive(false);
    }

    public void OnInputFieldValueChanged(string text)
    {
        voltasInputFieldValor = text;
    }
}
