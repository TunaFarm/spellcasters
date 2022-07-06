using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FluxShot : ShootingSkill
{
    [SerializeField] protected BaseProjectileSpell prefabSpell;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected float speed = 400f;

    private BaseProjectileSpell _bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        _bullet = SpawnProjectile(prefabSpell, shootPoint.position);
    }
}