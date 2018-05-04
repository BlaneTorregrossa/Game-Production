using UnityEngine;
public interface IShooter
{
    Transform Spawn { get; set; }
    float ShooterSpeed { get; set; }
}