using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundVolume
{
	public float bgm = 1.0f;
	public float se = 1.0f;

	public bool mute = false;

	public void Reset()
	{
		bgm = 1.0f;
		se = 1.0f;
		mute = false;
	}
}

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
	public SoundVolume volume = new SoundVolume();

	private AudioClip[] seClips;
	private AudioClip[] bgmClips;

	private Dictionary<string, int> seIndexes = new Dictionary<string, int>();
	private Dictionary<string, int> bgmIndexes = new Dictionary<string, int>();

	private AudioSource bgmSource;
	private AudioSource seSource;

	void Awake()
	{
		if (this != Instance)
		{
			Destroy(this);
			return;
		}

		bgmSource = gameObject.AddComponent<AudioSource>();
		bgmSource.loop = true;

		seSource = gameObject.AddComponent<AudioSource>();

		seClips = Resources.LoadAll<AudioClip>("Audio/SE");
		bgmClips = Resources.LoadAll<AudioClip>("Audio/BGM");

		for (int i = 0; i < seClips.Length; ++i)
		{
			seIndexes[seClips[i].name] = i;
		}

		for (int i = 0; i < bgmClips.Length; ++i)
		{
			bgmIndexes[bgmClips[i].name] = i;
		}

	}

	void Update()
	{
		bgmSource.mute = volume.mute;
		seSource.mute = volume.mute;

		bgmSource.volume = volume.bgm;
		seSource.volume = volume.se;
	}

	public int GetSeIndex(string name)
	{
		return seIndexes[name];
	}

	public int GetBgmIndex(string name)
	{
		return bgmIndexes[name];
	}

	public void PlayBgm(string name)
	{
		int index = bgmIndexes[name];
		PlayBgm(index);
	}

	public void PlayBgm(int index)
	{
		if (0 > index || bgmClips.Length <= index)
		{
			return;
		}

		if (bgmSource.clip == bgmClips[index])
		{
			return;
		}

		bgmSource.Stop();
		bgmSource.clip = bgmClips[index];
		bgmSource.Play();
	}

	public void StopBgm()
	{
		bgmSource.Stop();
		bgmSource.clip = null;
	}

	public void PlaySe(string name)
	{
		PlaySe(GetSeIndex(name));
	}

	//一旦queueに溜め込んで重複を回避しているので
	//再生が1frame遅れる時がある
	public void PlaySe(int index, float volumeScale = 1.0f)
	{
		if (0 > index || seClips.Length <= index)
		{
			return;
		}

		//if (seSource.clip == seClips[index])
		//{
		//	return;
		//}

		//seSource.Stop();
		//seSource.clip = seClips[index];
		//seSource.Play();z
		seSource.PlayOneShot(seClips[index], volumeScale);
	}

	public void StopSe()
	{
		seSource.Stop();
		seSource.clip = null;
	}

}
