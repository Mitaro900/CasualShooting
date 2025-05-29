using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private int rewardScore = 100;

    public void Init(int _power)
    {
        power = _power;
        UpdatePowerText();
    }

    protected override void Die()
    {
        GameManager.Instance.AddScore(rewardScore);
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
