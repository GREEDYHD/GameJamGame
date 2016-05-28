using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	[SerializeField]
	int currentHealth;

	[SerializeField]
	int maxHealth;
	
	public Image fill;

	public Canvas healthBar;

	public Color thresholdOne;
	public Color thresholdTwo;
	public Color thresholdThree;
	//Healthbar UI element
	
	public void Init(int startingHealth, int maxHealth)
	{
		this.currentHealth = startingHealth;
		this.maxHealth = maxHealth;
		UpdateBar ();
	}

	public void Init(int maxHealth) // Use if starts with max Health
	{
		this.currentHealth = maxHealth;
		this.maxHealth = maxHealth;
		UpdateBar ();
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		//Update UI element
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Destroy(gameObject);
		}
		UpdateBar ();
	}

	public void Heal(int amount)
	{
		currentHealth += amount;
		
		//Update UI element
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
			//Destroy(gameObject);
		}
		UpdateBar ();
	}

	void UpdateBar()
	{

		if(healthBar != null)
		{
			fill.fillAmount = (float)currentHealth / (float)maxHealth;
			if (currentHealth == maxHealth)
			{
				healthBar.enabled = false;
			} else {
				healthBar.enabled = true;
			}

			if( fill.fillAmount > 0.5f)
			{
				fill.color = thresholdOne;
				return;
			}
			else if( fill.fillAmount > 0.1f)
			{
				fill.color = thresholdTwo;
				return;
			}
			else if( fill.fillAmount > 0.0f)
			{
				fill.color = thresholdThree;
				return;
			}
		}
	}
}