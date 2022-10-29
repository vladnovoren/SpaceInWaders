using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _heartsList = new List<GameObject>();
        _deltaHeartSpawn = new Vector3(heart.GetComponent<RectTransform>().rect.width, 0, 0);
        _playerHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();
    }

    private void UpdateHP()
    {
        var deltaHealth = _playerHealth.Value - _heartsList.Count;
        if (deltaHealth == 0)
            return;
        for (var i = 0; i < Math.Abs(deltaHealth); ++i)
        {
            if (deltaHealth < 0)
                TakeHP();
            else
                AddHP();
        }
    }

    private void AddHP()
    {
        _heartsList.Add(Instantiate(heart, gameObject.transform));
        _heartsList[^1].transform.localPosition = _deltaHeartSpawn * (_heartsList.Count - 1);
        _heartsList[^1].transform.localScale = Vector3.one;
    }

    private void TakeHP()
    {
        Destroy(_heartsList[^1]);
        _heartsList.RemoveAt(_heartsList.Count - 1);
    }

    public GameObject heart;
    [SerializeField] protected GameObject player;
    private Health _playerHealth;

    private List<GameObject> _heartsList;
    private Vector3 _deltaHeartSpawn;
    
}
