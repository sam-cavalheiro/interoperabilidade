using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class ControladorCorredor : MonoBehaviour
{
    public float aceleracao = 1f;
    public float desaceleracao = 1f;
    public float velocidadeRotacao = 1f;
    public float velocidadeMovimentoMaxima = 10f;

    //Rigidbody2D rb;

    Corredor corredor;
    string inputPrefix;
    float velocidadeMovimento;

    /*void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }*/

    public void Setup(bool jogadorUm)
    {
        if (jogadorUm)
        {
            corredor = DadosJogo.partida.Corredor1;
            inputPrefix = "p1_";
        }
        else
        {
            corredor = DadosJogo.partida.Corredor2;
            inputPrefix = "p2_";
        }

        if (DadosJogo.carregouPorArquivo)
        {
            transform.position = corredor.Posicao;
            velocidadeMovimento = corredor.Velocidade;
            transform.eulerAngles = Vector3.forward * corredor.Angulo;
        }

        GetComponent<SpriteRenderer>().color = corredor.Cor;
    }

    // Update is called once per frame
    void Update()
    {
        // Atualizar as informações pertinentes do Corredor para salvar arquivo
        corredor.Posicao = transform.position;
        corredor.Angulo = transform.eulerAngles.z;
        corredor.Velocidade = velocidadeMovimento;

        // TODO Dar um jeito de atualizar as voltas realizadas

        // Movimentação
        //rb.AddForce(transform.up * Input.GetAxis(inputPrefix + "Vertical") * aceleracao);
        transform.eulerAngles -= Vector3.forward * Input.GetAxis(inputPrefix + "Horizontal") * velocidadeRotacao * Time.deltaTime;
        velocidadeMovimento += Input.GetAxis(inputPrefix + "Vertical") * aceleracao * Time.deltaTime;

        transform.position += transform.up * velocidadeMovimento;

        if (velocidadeMovimento < 0f)
        {
            //velocidadeMovimento = Mathf.Min(velocidadeMovimento + Time.deltaTime, 0f);
            velocidadeMovimento = Mathf.Clamp(velocidadeMovimento + desaceleracao * Time.deltaTime, -velocidadeMovimentoMaxima, 0f);
        }
        else if (velocidadeMovimento > 0f)
        {
            //velocidadeMovimento = Mathf.Max(velocidadeMovimento - Time.deltaTime, 0f);
            velocidadeMovimento = Mathf.Clamp(velocidadeMovimento - desaceleracao * Time.deltaTime, 0f, velocidadeMovimentoMaxima);
        }
    }
}
