using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
        _enemies = new EnemyShip[_spawnConfig.NRows, _spawnConfig.NCols];
        SpawnAllEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseAndShoot();
    }

    private void ChooseAndShoot()
    {
        int i = Random.Range(0, (int)_spawnConfig.NRows);
        int j = Random.Range(0, (int)_spawnConfig.NCols);
        
        if (_timeLeft <= 0)
        {
            TryShoot(i, j);
            _timeLeft = _timeBetweenShoots;
        }
        else
        {
            _timeLeft -= Time.deltaTime;
        }
    }

    private void TryShoot(int i, int j)
    {
        if (_enemies[i, j] != null)
            _enemies[i, j].Shoot();
    }

    private void SpawnAllEnemies()
    {
        Vector2 currPos = _spawnConfig.StartPos;
        for (ulong i = 0; i < _spawnConfig.NRows; ++i)
        {
            for (ulong j = 0; j < _spawnConfig.NCols; ++j)
            {
                _enemies[i, j] = Instantiate(enemyShip, currPos, enemyShip.transform.rotation);
                currPos.x += _spawnConfig.DeltaPos.x;
            }
            currPos.y += _spawnConfig.DeltaPos.y;
            currPos.x = _spawnConfig.StartPos.x;
        }
    }

    private readonly EnemySpawnConfig _spawnConfig = new EnemySpawnConfig(
        new Vector2(-3, 0.5f), new Vector2(1.5f, 1.5f),
        3, 5);

    private EnemyShip[,] _enemies;
    [SerializeField] protected EnemyShip enemyShip;
    
    private readonly float _timeBetweenShoots = 0.05f;
    private float _timeLeft = 0.0f;
}
