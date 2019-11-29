using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private Slider healthBar;
    private Text ammoText;
    public static Text objective;
    private Character player;

    private void Awake()
    {
        healthBar = transform.GetChild(0).GetComponent<Slider>();
        ammoText = transform.GetChild(1).GetComponent<Text>();
        objective = transform.GetChild(2).GetComponent<Text>();
        player = transform.GetComponentInParent<Character>();
    }

    private void FixedUpdate()
    {
        healthBar.value = player.GetHealthFraction();
        Weapon weapon = player.GetWeapon();

        ammoText.text = "" + weapon.InClip() + "/" + weapon.GetStats().GetClipSize();
    }
}
