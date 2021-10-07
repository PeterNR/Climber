using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ChosenAction { Rope, Missile }

public class PlayerShip : MonoBehaviour
{
    public int Health;
    public int Ropes;
    public int Money;
    public ChosenAction CurrentAction;


    [SerializeField]
    private Text _healthText, _scoreText, _gameOverText;
    [SerializeField]
    private GameObject _gameOverPanel;

    private Ship _mainShip;
    private Animator _animator;

    private void Start()
    {
        _mainShip = GameManager.Instance.MainShip;
        Health = _mainShip.MaxHealth;
        Ropes = _mainShip.MaxRopes;
        Money = 0;
        CurrentAction = ChosenAction.Rope;
        _gameOverPanel.SetActive(false);
        _scoreText.text = Money.ToString();
        _healthText.text = Health.ToString();
        _animator = GetComponent<Animator>();
    }

    public void LoseHealth(int dmg)
    {
        Health -= dmg;
        _healthText.text = Health.ToString();
        _animator.SetTrigger("TakeDamage");

        if (Health < 1)
        {
            GameOver("Ship destroyed");
            //gameover
        }
    }

    public void GatherMoney(int amount)
    {
        Money += amount;
        _scoreText.text = Money.ToString();
    }

    public void GameOver(string reason)
    {
        _gameOverPanel.SetActive(true);
        _gameOverText.text = reason;
    }

    public void ReturnToBase()
    {
        _mainShip.Money += Money;
        GameManager.Instance.SceneLoader.LoadSceneWithName("Hangar");
    }
}
