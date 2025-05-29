using UnityEngine;

public class Boss : Enemy
{
    protected override void Die()
    {
        GameManager.Instance.DifficultyLevel++; // 게임 난이도 증가
        base.Die();
    }
}
