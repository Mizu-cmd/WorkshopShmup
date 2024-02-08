using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy;
        Pickup pickup;
        if (other.TryGetComponent(out enemy))
        {
            LevelManager.Instance.EnemyCount--;
            Destroy(enemy.gameObject);
        } else Destroy(other.transform.parent.gameObject);
    }
}
