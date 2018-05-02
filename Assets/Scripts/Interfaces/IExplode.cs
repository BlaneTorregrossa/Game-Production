using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExplode
{
    float Damage { get; set; }
    float Radius { get; set; }

    void Explode(string tag);
}