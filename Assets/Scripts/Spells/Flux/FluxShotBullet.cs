using UnityEngine;

public class FluxShotBullet : BaseProjectileSpell
{
  private new void Update()
  {
    Shoot(transform.rotation, 40f, ForceMode2D.Force);
  }

  protected override void DamageTarget(Collision2D other)
  {
    var damageable = other.gameObject.GetComponent<IDamageable>();
    if (damageable != null)
    {
      damageable.TakeDamage(new DamageData
      {
        Damage = damage,
        ImpactObject = gameObject
      });
      DeSpawn();
    }
    else
    {
      //collide with wall
      DeSpawn();
    }
  }
}