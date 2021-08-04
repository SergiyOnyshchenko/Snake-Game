using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorFoodSpawner", menuName = "Spawner/ColorFoodSpawner")]
public class ColorFoodSpawner : MultipleObjectSpawner
{
    [SerializeField] private ColorFood _prefab;
    [SerializeField] private bool _isEdibleColor;

    public override void SpawnOneObject(Vector3 position, SpawnData data)
    {
        IColorChanger newColorObject = Instantiate(_prefab, position, Quaternion.identity, data.Parent);

        if (_isEdibleColor)
        {
            newColorObject.ChangeColor(data.EdibleColor);
        }
        else
        {
            newColorObject.ChangeColor(data.NonEdibleColor);
        }
    }
}
