using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour 
{
	public AudioSource tempMusicSource, tempEffectSource;
	public List<AudioClip> tempEffects, tempMusic;

	public static AudioSource musicSource, effectSource;
	public static List<AudioClip> effects, music;

	void Start()
	{
		TransferLists ();
	}

	public static void PlayEffect(string effectName)
	{
		for(int i = 0; i < effects.Count; i++)
		{
			if(effects[i].name == effectName)
			{
				effectSource.volume = 1.0f;
				effectSource.PlayOneShot (effects [i]);
			}
		}
	}

	public static void PlayEffect(string effectName, float volume)
	{
		for(int i = 0; i < effects.Count; i++)
		{
			if(effects[i].name == effectName)
			{
				effectSource.volume = volume;
				effectSource.PlayOneShot (effects [i]);
			}
		}
	}

	public static void PlayMusic(string musicName)
	{
		for(int i = 0; i < music.Count; i++)
		{
			if(music[i].name == musicName)
			{
				musicSource.Stop ();
				musicSource.volume = 1.0f;
				musicSource.loop = true;
				musicSource.clip = music [i];
				musicSource.Play ();
			}
		}
	}

	public static void PlayMusic(string musicName, float volume)
	{
		for(int i = 0; i < music.Count; i++)
		{
			if(music[i].name == musicName)
			{
				musicSource.Stop ();
				musicSource.volume = volume;
				musicSource.loop = true;
				musicSource.clip = music [i];
				musicSource.Play ();
			}
		}
	}

	void TransferLists()
	{
		musicSource = tempMusicSource;
		effectSource = tempEffectSource;

		effects = tempEffects;
		music = tempMusic;
	}

}
