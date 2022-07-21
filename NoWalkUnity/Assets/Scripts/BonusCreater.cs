using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Bonuces", fileName = "New Bonus")]
public class BonusCreater : ScriptableObject
{
    [SerializeField] private Text counter;
}
