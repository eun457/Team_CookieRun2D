using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : SingletonBehaviour<SoundManager>
{
    [SerializeField] AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    void Awake()
    {
        base.Awake();

        //_audioSources[(int)Define.Sound.Bgm] = gameObject.AddComponent<AudioSource>();
        //_audioSources[(int)Define.Sound.Effect] = gameObject.AddComponent<AudioSource>();
        //_audioSources[(int)Define.Sound.IngameEffect] = gameObject.AddComponent<AudioSource>();
        //_audioSources[(int)Define.Sound.GiganticEffect] = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {

    }
    public void Clear() //DontDestroyOnLoad�� �ı����� �ʰ� �Ǿ��ֱ� ������ �޸� ȿ���� ���� Dictionary�� ����ִ� �Լ� ����
    {
        //����� ���� ��� ��ž, ���� ����
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        //ȿ���� Dictionary ����
        _audioClips.Clear();
    }

    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;
        if(type == Define.Sound.Bgm) //BGM ���
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else if(type == Define.Sound.Effect) //Ingame�� ȿ����
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip); //�ѹ��� ���
        }
        else if (type == Define.Sound.IngameEffect) //���� �� ������ ȹ�� ȿ����
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.IngameEffect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip); 
        }
        else if (type == Define.Sound.GiganticEffect) //Gigantic���� ȿ������ ������ �ʹ� Ŀ�� ���� ��Ʈ��
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.GiganticEffect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        AudioClip audioClip = null;

        if(type == Define.Sound.Bgm)
        {
            audioClip = GameManager.Instance.LoadAudioClip(path);
        }
        else
        {
            if(_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = GameManager.Instance.LoadAudioClip(path);
                _audioClips.Add(path, audioClip);
            }
        }
        return audioClip;
    }

    public void PauseBGM() //BGM�Ͻ�����
    {
        AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
        if (audioSource.isPlaying)
            audioSource.Pause();
    }

    public void ResumeBGM() //BGM�Ͻ����� ����
    {
        AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
        audioSource.UnPause();
    }

    public void PlayBGM() //BGM ó������ ���
    {
        AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
        audioSource.Play();
    }
}
