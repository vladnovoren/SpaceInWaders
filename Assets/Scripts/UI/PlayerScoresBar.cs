using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoresBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _playerShip = playerShipGameObject.GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScores();
    }

    private void UpdateScores()
    {
        text.text = "scores: " + _playerShip.Scores.ToString();
    }

    [SerializeField] protected GameObject playerShipGameObject;
    public TextMeshProUGUI text;
    private PlayerShip _playerShip;
}
