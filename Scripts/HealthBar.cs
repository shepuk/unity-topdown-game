using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform heartsContainer;

    [SerializeField]
    private RectTransform healthHeartTemplate;

    [SerializeField]
    private RectTransform emptyHealthHeartTemplate;

    float heartsContainerWidth = 0;
    float healthLost;

    [SerializeField]
    public HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (healthManager.remainingHealth > healthManager.totalHealth)
        {
            healthManager.remainingHealth = healthManager.totalHealth;
        }

        //TODO
        // also a check here for if health is less than zero

        foreach (RectTransform heartObj in heartsContainer)
        {
            if (heartObj.gameObject.activeSelf)
            {
                Destroy(heartObj.gameObject);
            }
        }

        for (int i = 0; i < healthManager.remainingHealth; i++)
        {
            GameObject heart = Instantiate(healthHeartTemplate.gameObject, heartsContainer);
            heart.gameObject.SetActive(true);
        }

        healthLost = healthManager.totalHealth - healthManager.remainingHealth;

        for (int i = 0; i < healthLost; i++)
        {
            GameObject emptyHeart = Instantiate(
                emptyHealthHeartTemplate.gameObject,
                heartsContainer
            );
            emptyHeart.gameObject.SetActive(true);
        }

        float maxHealth = healthManager.totalHealth;
        heartsContainerWidth = healthHeartTemplate.sizeDelta.x * maxHealth;
        heartsContainer.sizeDelta = new Vector2(heartsContainerWidth, heartsContainer.sizeDelta.y);
        heartsContainer.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() { }
}
