using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingSkill : MonoBehaviour
{
    public abstract void Shoot();
    
    protected virtual BaseProjectileSpell SpawnProjectile(BaseProjectileSpell prefab, Vector3 position)
    {
        var spell = Instantiate(prefab, position, Quaternion.identity);
        return spell;
    }
}