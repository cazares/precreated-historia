using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public HitPoints hitPoints;

  [HideInInspector]
  public Player character;

  public Image meterImage;

  public Text hpText;

  [HideInInspector]
  public float maxHitPoints;

  // Start is called before the first frame update
  void Start()
  {
    if (character == null) {
      print("character null, returning");
      return;
    }
    print("character not null, setting maxHitPoints");
    maxHitPoints = character.maxHitPoints;
  }

  // Update is called once per frame
  void Update()
  {
    if (character != null) {
      print("HealthBar Update, character exists, setting fill amount");
      meterImage.fillAmount = hitPoints.value / maxHitPoints;
      hpText.text = "HP: " + (meterImage.fillAmount * 100);
    }
    else {
      print("HealthBar Update, character null, not setting fill amount");
    }
  }
}
