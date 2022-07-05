using UnityEngine;

public class BaseProjectileSpell : MonoBehaviour
{
  [SerializeField] protected float damage;
  [SerializeField] protected Collision2D spellCollider;
  [SerializeField] protected Rigidbody2D rigidBody2D;

  private Vector2 _screenPosition;

  private Vector3 _worldPosition;

  protected void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Vector3 mousePos = Input.mousePosition;
      _screenPosition = new Vector2(mousePos.x, mousePos.y);
    }

    _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);
  }

  protected virtual void DamageTarget(Collision2D other) { }

  protected virtual void OnCollisionEnter2D(Collision2D other)
  {
    DamageTarget(other);
  }

  protected virtual void Shoot(Quaternion angle, float speed, ForceMode2D forceMode2D = ForceMode2D.Impulse)
  {
    transform.rotation = angle;
    rigidBody2D.SetRotation(angle);
    rigidBody2D.AddRelativeForce(Vector2.up * speed, forceMode2D);

  }

  protected virtual void DeSpawn()
  {
    Destroy(this.gameObject);
  }
}