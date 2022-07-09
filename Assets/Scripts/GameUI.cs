using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject healthBar;

    public void Damage(int damageAmount)
    {
        for (int i = 0; i < damageAmount; i++)
        {
            Destroy(healthBar.transform.GetChild(healthBar.transform.childCount - 1).gameObject);
        }
    }
}
