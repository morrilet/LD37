using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour 
{
	[SerializeField]
	protected static AudioSource musicSource, effectSource;
	[SerializeField]
	protected static List<AudioClip> effects, music;

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
}
