using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public GameObject manaBar;
    public GameObject easeManaBar;
    
    public float maxMana = 250f;
    public float mana;
    public float manaRegen = 100f;

    private Slider manaSlider;
    private Slider easeManaSlider;
    private float lerpSpeed = 0.05f;
    private float timeDelayEaseMana = 0f;
    private float cooldownRegen = 0f;
    private bool regen = true;
    
    // Start is called before the first frame update
    void Start()
    {
        manaSlider = manaBar.GetComponent<Slider>();
        easeManaSlider = easeManaBar.GetComponent<Slider>();

        float scale = ((maxMana - 250) / 250);

        manaBar.transform.localScale += Vector3.right * scale;
        easeManaBar.transform.localScale += Vector3.right * scale;

        mana = maxMana;

        manaSlider.maxValue = maxMana;
        easeManaSlider.maxValue = maxMana;

        manaSlider.value = maxMana;
        easeManaSlider.value = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownRegen < 1f) {
            cooldownRegen += Time.deltaTime;
        } else {
            if(mana < maxMana) mana += manaRegen * Time.deltaTime;
        }
        if(manaSlider.value != mana) {
            manaSlider.value = mana;
        }
        if(easeManaSlider.value != manaSlider.value) {
            if(easeManaSlider.value > manaSlider.value) {
                if(timeDelayEaseMana < 0.5f) timeDelayEaseMana += Time.deltaTime;
                else {
                    easeManaSlider.value = Mathf.Lerp(easeManaSlider.value, manaSlider.value, lerpSpeed);
                }
            } else {
                easeManaSlider.value = manaSlider.value;
            }
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            decreaseMana(10);
            
        }
    }

    public bool decreaseMana(float value) {
        if (mana - value >= 0) {
            mana -= value;
            timeDelayEaseMana = 0f;
            cooldownRegen = 0f;
            return true;
        } else {
            return false;
        }
    }

    public void increaseMaxMana(float mana) {
        manaBar.transform.localScale += Vector3.right * (mana / 250);
        easeManaBar.transform.localScale += Vector3.right * (mana / 250);
        maxMana += mana;
        manaSlider.maxValue = maxMana;
        easeManaSlider.maxValue = maxMana;
        easeManaSlider.value = maxMana;
    }
}
