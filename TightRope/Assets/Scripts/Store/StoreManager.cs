using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField]
    private List<ShipUpgrade> _ropeUpgradePath, _healthUpgradePath;
    [SerializeField]
    private Text _moneyText, _ropeUpgradeText, _healthUpgradeText;

    private Ship _upgradeShip;

    private void Start()
    {
        _upgradeShip = GameManager.Instance.MainShip;
        _moneyText.text = _upgradeShip.Money.ToString();
        if (_upgradeShip.RopeUpgradeIndex < _ropeUpgradePath.Count)
        {
            _ropeUpgradeText.text = _ropeUpgradePath[_upgradeShip.RopeUpgradeIndex].Cost.ToString();
        }
    }

    public void PurchaseRopeUpgrade()
    {
        ShipUpgrade upgrade = _ropeUpgradePath[_upgradeShip.RopeUpgradeIndex];
        if(_upgradeShip.RopeUpgradeIndex < _ropeUpgradePath.Count)
        {
            if (upgrade.Cost <= _upgradeShip.Money)
            {
                _upgradeShip.Money -= upgrade.Cost;
                _upgradeShip.MaxRopes += upgrade.UpgradeAmount;
                _moneyText.text = _upgradeShip.Money.ToString();
                _upgradeShip.RopeUpgradeIndex++;
                if (_upgradeShip.RopeUpgradeIndex < _ropeUpgradePath.Count)
                {
                    _ropeUpgradeText.text = _ropeUpgradePath[_upgradeShip.RopeUpgradeIndex].Cost.ToString();
                }
                else
                {
                    _ropeUpgradeText.text = "Max";
                }

            }
            else
            {
                Debug.Log("Not enough money");
            }
        }
        
    }

    public void PurchaseHealthUpgrade()
    {
        ShipUpgrade upgrade = _healthUpgradePath[_upgradeShip.HealthUpgradeIndex];
        if (_upgradeShip.HealthUpgradeIndex < _healthUpgradePath.Count)
        {
            if (upgrade.Cost <= _upgradeShip.Money)
            {
                _upgradeShip.Money -= upgrade.Cost;
                _upgradeShip.MaxHealth += upgrade.UpgradeAmount;
                _moneyText.text = _upgradeShip.Money.ToString();
                _upgradeShip.HealthUpgradeIndex++;
                if (_upgradeShip.HealthUpgradeIndex < _healthUpgradePath.Count)
                {
                    _healthUpgradeText.text = _healthUpgradePath[_upgradeShip.HealthUpgradeIndex].Cost.ToString();
                }
                else
                {
                    _ropeUpgradeText.text = "Max";
                }

            }
            else
            {
                Debug.Log("Not enough money");
            }
        }

    }
}

[System.Serializable]
public class ShipUpgrade
{
    public int Cost;
    public int UpgradeAmount;
}