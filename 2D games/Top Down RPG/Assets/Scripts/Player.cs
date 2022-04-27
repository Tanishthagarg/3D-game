using UnityEngine;
using System.Collections;

public class Player : Character{

    [SerializeField] private HealthBar _healthBarPrefab;
    [SerializeField] private HitPoints _hitPoints;
    [SerializeField] Inventory _inventoryPrefab;
    private Inventory _inventory;
    private HealthBar _healthBar;
   // static int i=0;
     public override void ResetCharacter() {
    _inventory = Instantiate(_inventoryPrefab);
    _healthBar = Instantiate(_healthBarPrefab);
    _healthBar.Character = this;
    _hitPoints.Value = _startingHitPoints;

    }
    private void OnEnable() {
    ResetCharacter();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            ItemData hitObject = collision.gameObject.
            GetComponent<Consumable>().Item;
            // print(i++);
                if (hitObject != null) {
                 //    print(i++);
                print("Hit: " + hitObject.ObjectName);
               
                bool shouldDisappear = false;
                    switch (hitObject.Type) {
                        case ItemData.ItemType.Coin:
                            shouldDisappear = _inventory.AddItem(hitObject);
                            break;
                        case ItemData.ItemType.Key:
                            shouldDisappear = _inventory.AddItem(hitObject);
                            break;
                        case ItemData.ItemType.Health:
                            shouldDisappear = AdjustHitPoints(hitObject.Quantity,hitObject);
                            break;
                        case ItemData.ItemType.MaxHealth:
                            shouldDisappear = AdjustHitPoints(hitObject.Quantity,hitObject);
                            break;
                    }
                if (shouldDisappear)
                collision.gameObject.SetActive(false);
                }
        }
}
    public bool AdjustHitPoints(int amount, ItemData hitobject) {
        if (  _hitPoints.Value < _maxHitPoints) {
            if (hitobject.ObjectName.Equals("heart")){
                _hitPoints.Value = _hitPoints.Value + amount;
            }
            if (hitobject.ObjectName.Equals("maxHeart")){
                amount = (int)(_maxHitPoints- _hitPoints.Value); 
                _hitPoints.Value = _maxHitPoints;
            }
            print("Adjusted HP by: " + amount + ". New value: " + _hitPoints.Value);
            return true;
        }

        return false;
    }



    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        StartCoroutine(FlickerCharacter());
        while (true) {
            _hitPoints.Value = _hitPoints.Value - damage;
            if (_hitPoints.Value <= float.Epsilon) {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon) {
                yield return new WaitForSeconds(interval);
            }
            else {
                break;
            }
        }
    }
    public override void KillCharacter() {
    base.KillCharacter();
    Destroy(_healthBar.gameObject);
    Destroy(_inventory.gameObject);
    }


}
