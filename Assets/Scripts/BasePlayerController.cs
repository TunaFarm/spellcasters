using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerController : MonoBehaviour, IDamageable
{
           
    public float Health { get; set; }
    public float Energy { get; set; }

    private float _healthProperty;
    private float _energyProperty;
    
    public void TakeDamage(DamageData data)
    {
        var resutDamage = data.Damage;
        _healthProperty -= resutDamage;
    }
}
