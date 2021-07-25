using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorSetter : ColorSetter
{
    [SerializeField] private ParticleSystem _particle;

    private void Start() 
    {
        if(_particle == null)
            _particle = GetComponent<ParticleSystem>();

        Init();
    }

    public override void SetColor(ColorData colorData)
    {
        var main = _particle.main;
        main.startColor = colorData.Color;
    }
}
