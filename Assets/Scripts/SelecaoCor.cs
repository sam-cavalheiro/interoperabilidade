using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoCor : MonoBehaviour
{
    [SerializeField] Image trocaCorImage;
    Slider[] sliders;

    // Start is called before the first frame update
    void Start()
    {
        sliders = GetComponentsInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        trocaCorImage.color = GetColor();
    }

    public Color GetColor()
    {
        return new Color(sliders[0].value, sliders[1].value, sliders[2].value);
    }
}
