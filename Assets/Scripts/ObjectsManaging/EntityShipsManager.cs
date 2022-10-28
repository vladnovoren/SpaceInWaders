using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnConfig
{
    public EnemySpawnConfig() {}

    public EnemySpawnConfig(Vector2 startPos, Vector2 deltaPos, ulong nRows, ulong nCols)
    {
        StartPos = startPos;
        DeltaPos = deltaPos;

        NRows = nRows;
        NCols = nCols;
    }
    
    public Vector2 StartPos { set; get; }
    public Vector2 DeltaPos { set; get; }

    public ulong NRows { set; get; }
    public ulong NCols { set; get; }

    private Vector2 _startPos;
    private Vector2 _deltaPos;

    private ulong _nRows;
    private ulong _nCols;
}

public class EntityShipsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnAllEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAllEnemies()
    {
        Vector2 currPos = _spawnConfig.StartPos;
        for (ulong i = 0; i < _spawnConfig.NRows; ++i)
        {
            for (ulong j = 0; j < _spawnConfig.NCols; ++j)
            {
                Instantiate(_enemyShip, currPos, _enemyShip.transform.rotation);
                currPos.x += _spawnConfig.DeltaPos.x;
            }
            currPos.y += _spawnConfig.DeltaPos.y;
            currPos.x = _spawnConfig.StartPos.x;
        }
    }

    private readonly EnemySpawnConfig _spawnConfig = new EnemySpawnConfig(
        new Vector2(-3, 1), new Vector2(1.5f, 1.5f),
        3, 5);

    [SerializeField] protected EnemyShip _enemyShip;
}
