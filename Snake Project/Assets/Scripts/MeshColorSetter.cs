using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeshColorSetter : ColorSetter
{
    [SerializeField] private Renderer[] _renderers;

    private void Start() 
    {
        if(_renderers == null)
            GetAllRenderers();
        
        Init();
    }

    public void GetAllRenderers()
    {
        _renderers = GetComponentsInChildren<Renderer>();
    }

    public override void SetColor(ColorData colorData)
    {
        foreach (Renderer renderer in _renderers)
        {
            renderer.materials[0].color = colorData.Color;
        }
    }
}
