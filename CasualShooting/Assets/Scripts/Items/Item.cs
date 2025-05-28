using TMPro;
using UnityEngine;

public enum OperationType
{
    Add,
    Subtract,
    Multiply,
    Divide
}

public class Item : MonoBehaviour
{
    [SerializeField] private OperationType operationType;
    [SerializeField] private int value;
    [SerializeField] private TextMeshProUGUI itemText;
    private Material itemMaterial;

    private void Awake()
    {
        itemMaterial = GetComponentInChildren<Renderer>().material;
    }

    public void InitItem(OperationType _operationType, int _value)
    {
        operationType = _operationType;
        value = _value;

        char operation = '?';

        switch (operationType)
        {
            case OperationType.Add:
                operation = '+';
                itemMaterial.color = new Color(0f, 0f, 1f, 0.5f);
                break;
            case OperationType.Subtract:
                operation = '-';
                itemMaterial.color = new Color(1f, 0f, 0f, 0.5f);
                break;
            case OperationType.Multiply:
                operation = 'X';
                itemMaterial.color = new Color(0f, 0f, 1f, 0.5f);
                break;
            case OperationType.Divide:
                operation = '÷';
                itemMaterial.color = new Color(1f, 0f, 0f, 0.5f);
                break;
            default:
                Debug.LogWarning("Invalid operation type.");
                break;
        }

        itemText.text = $"{operation}{value}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ChangePower(operationType, value);
        }
    }
}
