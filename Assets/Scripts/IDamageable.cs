using UnityEngine;

public interface IDamageable
{
    void TakeDamage(DamageData data);
}

public struct DamageData
{
    public float Damage;
    public GameObject ImpactObject;
}