using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy;
        if (other.TryGetComponent(out enemy))
            LevelManager.Instance.EnemyCount--;
        
        Destroy(other.transform.parent.parent.gameObject);
        
    }
}
