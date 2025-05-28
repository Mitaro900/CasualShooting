using UnityEngine;

public class Enemy : Entity
{
    public void InitEnemy(int _power)
    {
        power = _power;
        UpdatePowerText();
    }

    protected override void Die()
    {
        GameManager.Instance.AddScore(100);
        base.Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(power);
        }
    }
}
