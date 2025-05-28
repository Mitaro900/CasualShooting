using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected int power = 1;
    public int Power => power;

    [SerializeField] protected TextMeshProUGUI powerText;

    protected virtual void Start()
    {
        UpdatePowerText();
    }

    public void ChangePower(OperationType operationType, int value)
    {
        switch (operationType)
        {
            case OperationType.Add:
                power += value;
                break;
            case OperationType.Subtract:
                power -= value;
                break;
            case OperationType.Multiply:
                power *= value;
                break;
            case OperationType.Divide:
                if (value != 0)
                {
                    power /= value;
                }
                else
                {
                    Debug.LogWarning("Division by zero is not allowed.");
                }
                break;
            default:
                Debug.LogWarning("Invalid operation.");
                break;
        }

        if (power < 1)
        {
            power = 1;
        }

        UpdatePowerText();
    }

    protected void UpdatePowerText()
    {
        if (powerText != null)
        {
            powerText.text = power.ToString();
        }
    }

    public void TakeDamage(int damage)
    {
        power -= damage;
        UpdatePowerText();

        if (power <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
