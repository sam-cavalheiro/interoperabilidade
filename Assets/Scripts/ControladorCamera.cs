using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ControladorCamera : MonoBehaviour
{
    public float minTamanhoCamera = 5f;

    Camera cam;
    Transform jogadorTransformA;
    Transform jogadorTransformB;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        ControladorCorredor[] ccs = FindObjectsOfType<ControladorCorredor>();
        jogadorTransformA = ccs[0].transform;
        jogadorTransformB = ccs[1].transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posA = jogadorTransformA.position;
        Vector3 posB = jogadorTransformB.position;

        transform.position = new Vector3((posA.x + posB.x) / 2f, (posA.y + posB.y) / 2f, -10f);
        cam.orthographicSize = Mathf.Max(Vector3.Distance(posA, posB) * 0.6f, minTamanhoCamera);
    }
}
