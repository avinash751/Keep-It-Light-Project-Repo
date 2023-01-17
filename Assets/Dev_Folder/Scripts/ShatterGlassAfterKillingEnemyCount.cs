using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterGlassAfterKillingEnemyCount : MonoBehaviour
{
	[SerializeField] List<GameObject> enemiesInTrigger;

	[SerializeField] GameObject glassWall;

	[SerializeField] int currentDeathCount;
	[SerializeField] int maxEnemyDeaths;

	[SerializeField] AudioSource glassCrackingAudio;
	[SerializeField] AudioSource glassShatterAudio;

	bool playCrackSoundOnce;
	bool playShatterGlass;

	void Update()
	{
		RemoveEnemyAndIncrementDeathCount();
		TriggerGlassShatter();
		PlayGlassCrackSound();
        PlayGlassShatterSound();
	}

	void RemoveEnemyAndIncrementDeathCount()
	{
		for (int i = 0; i < enemiesInTrigger.Count; i++)
		{
			if (enemiesInTrigger[i] == null)
			{
				enemiesInTrigger.RemoveAt(i);
				currentDeathCount++;

			}
		}
	}

	void TriggerGlassShatter()
	{
		if (currentDeathCount >= maxEnemyDeaths)
		{
			ShatterGlass();
		}
	}

	void ShatterGlass()
	{
		for (int i = 0; i < 34; i++)
		{
			glassWall.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
		}
	}

	void PlayGlassShatterSound()
	{
		if (currentDeathCount >= maxEnemyDeaths && !playShatterGlass)
		{
			glassShatterAudio.Play();
			playShatterGlass = true;
			Debug.Log("PLAYINGTHEGLASSSHATTER");
		}
	}

	void PlayGlassCrackSound()
	{
		if (currentDeathCount >= 5 && !playCrackSoundOnce)
		{
			glassCrackingAudio.Play();
			playCrackSoundOnce = true;

		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent(out Wander enemy))
		{
			if (enemiesInTrigger.Contains(enemy.gameObject))
			{
				return;
			}
			enemiesInTrigger.Add(enemy.gameObject);
		}
	}
}
