using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCtrler : MonoBehaviour
{
    [SerializeField]
    public LineRenderer lineRender;
    public Material material;
    public Transform addr;


    private void Update()
    {
        lineRender.SetPosition(0, addr.position);
    }
}
