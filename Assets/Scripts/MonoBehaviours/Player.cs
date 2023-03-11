using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Player : Character
{
  public HealthBar healthBarPrefab;
  HealthBar healthBar;

  public void Start() 
  {
    hitPoints.value = startingHitPoints;
    healthBar = Instantiate(healthBarPrefab);
    healthBar.character = this;
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("CanBePickedUp"))
    {
      Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
      if (hitObject != null) {
        print("Hit: " + hitObject.objectName);
        bool shouldDisappear = false;
        switch (hitObject.itemType)
        {
          case Item.ItemType.COIN:
            shouldDisappear = true;
            break;

          case Item.ItemType.HEALTH:
            shouldDisappear = AdjustHitPoints(hitObject.quantity);
            break;

          default:
            break;
        }
        if (shouldDisappear) {
          collision.gameObject.SetActive(false);
        }
      }  
    }
  }

  public static string prettyPrint(object obj)
  {
      return JsonConvert.SerializeObject(obj);
  }

  public bool AdjustHitPoints(int amount) {
    print("hitPoints: " + prettyPrint(hitPoints));
    if (hitPoints.value < maxHitPoints) {
      hitPoints.value = hitPoints.value + amount;
      print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints);
      return true;
    }
    return false;
  }
}
