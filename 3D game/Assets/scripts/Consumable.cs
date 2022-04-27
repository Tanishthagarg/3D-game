using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private ItemData _item;
    public ItemData Item
    {
        get
        {
            return _item;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            print("Item collected: " + _item.name);
            if (_item.name == "Heart")
            {
                other.GetComponent<PlayerCharacter>().Heal(1);
            }
           
            if (_item.name == "Coin")
            {
                other.GetComponent<PlayerCharacter>().Countcoin();
            } 
            if (_item.name == "Weapon")
            {
                print("Comsumable weapon");
                GameObject.Find("Main Camera").GetComponent<RayShooter>().pistolshotter();
            }
            Destroy(this.gameObject);
        }
    }
}
