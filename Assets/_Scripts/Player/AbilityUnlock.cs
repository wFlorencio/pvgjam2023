using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUnlock : MonoBehaviour
{
    public bool unlockDoubleJump, unlockDash, unlockBow, unlockCombo;

    public string unlockMessage;
    public TMP_Text unlockText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerAbilityTracker abilities = other.GetComponentInParent<PlayerAbilityTracker>();

            if (unlockDoubleJump)
            {
                abilities.canDoubleJump = true;
            }

            if (unlockDash)
            {
                abilities.canDash = true;
            }

            if (unlockBow)
            {
                abilities.canUseBow = true;
            }

            if (unlockCombo)
            {
                abilities.canGiveCombo = true;
            }

            unlockText.transform.parent.SetParent(null);
            unlockText.transform.parent.position = transform.position;

            unlockText.text = unlockMessage;
            unlockText.gameObject.SetActive(true);

            Destroy(unlockText.transform.parent.gameObject, 3f);
            Destroy(gameObject);
        }
    }
}
