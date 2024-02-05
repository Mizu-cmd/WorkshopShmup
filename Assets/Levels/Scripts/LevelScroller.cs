using System.Collections;
using UnityEngine;

public class LevelScroller : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private float scrollSpeed;
    public static float ScrollSpeed = 1f;
    private Transform _level;
    [SerializeField]private GameObject _currentTile;
    private void Start()
    {
        ScrollSpeed = scrollSpeed;
        _level = GameObject.FindGameObjectWithTag("Level").transform;
        StartCoroutine(SpawnTile());
    }
    private void Update()
    {
        _level.Translate(_level.right * (ScrollSpeed * Time.deltaTime));
    }

    private GameObject GetRandomTile()
    {
        return tiles[Random.Range(0, tiles.Length - 1)];
    }

    private IEnumerator SpawnTile()
    {
        yield return new WaitForSeconds(spawnDelay);
        var newTile = Instantiate(GetRandomTile(), _level);
        
        var rotation = Vector3.zero;
        rotation.y = 180;
        var start = _currentTile.transform.GetChild(0).transform.position;
        newTile.transform.SetPositionAndRotation(start, Quaternion.Euler(rotation));
        StartCoroutine(SpawnTile());
        _currentTile = newTile;
        Destroy(_currentTile, 20f);
    }
}
