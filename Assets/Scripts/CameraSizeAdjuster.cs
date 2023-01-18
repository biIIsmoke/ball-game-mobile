using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraSizeAdjuster : MonoBehaviour
{
    [SerializeField]private Transform _boardTransform;
    [SerializeField]private MeshRenderer _boardMeshRenderer;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        _camera.orthographicSize = (_boardMeshRenderer.bounds.size.x + _boardTransform.localScale.x) * Screen.height / Screen.width * 0.5f;
    }
}
