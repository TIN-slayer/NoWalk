using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private Image imageCooldown;
    private bool isCooldown = false;
    private float cooldownTime;
    private float cooldownTimer;
    [SerializeField] private GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = gun.GetComponent<Gun>().cooldown;
        cooldownTimer = cooldownTime;
        imageCooldown.fillAmount = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCooldown)
        {
            Counter();
        }

    }

    public void StartCounter()
    {
        imageCooldown.fillAmount = 1f;
        isCooldown = true;
        cooldownTimer = cooldownTime;
    }
    private void Counter()
    {
        if (cooldownTimer <= 0f)
        {
            isCooldown = false;
            imageCooldown.fillAmount = 0f;
            cooldownTimer = cooldownTime;
        }
        else
        {
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
            cooldownTimer -= Time.deltaTime;
        }
    }
}
