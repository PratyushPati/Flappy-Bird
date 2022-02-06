using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public MeshRenderer meshrenderer;

    public float animationspeed = 1f;

    private void Start()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshrenderer.material.mainTextureOffset += new Vector2(animationspeed*Time.deltaTime,0);
    }
}
