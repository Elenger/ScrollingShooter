using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float paralax;
    private MeshRenderer _meshRenderer;
    private Material _material;
    private Vector2 _offset;

    private void Start()
    {
         _meshRenderer = GetComponent<MeshRenderer>();
         _material = _meshRenderer.material;
         _offset = _material.mainTextureOffset;
    }

    private void Update()
    {
        _offset.y += Time.deltaTime / paralax;
        _material.mainTextureOffset = _offset;
    }
}
