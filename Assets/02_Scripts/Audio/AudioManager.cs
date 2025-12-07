using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public AudioMixer audioMixer;

    // 슬라이더
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Text bgmVolumeText;
    public Text sfxVolumeText;

    public AudioSource audioBGM;
    public AudioSource buttonSFX;

    bool isBGMMute = true;
    bool isSFXMute = true;

    float bgmVolume;
    float sfxVolume;

    public GameObject bgmMuteButon;
    public GameObject sfxMuteButon;

    private void Awake()
    {
        Singleton.AudioManager = this;
        bgmSlider.value = -20;
        sfxSlider.value = -20;
        audioMixer.SetFloat("BGM", -20);
        audioMixer.SetFloat("SFX", -20);

    }
    // 볼륨 조절

    public void SettingReset()
    {
        PlayButtonSFX();

        bgmSlider.value = -20;
        sfxSlider.value = -20;
        audioMixer.SetFloat("BGM", -20);
        audioMixer.SetFloat("SFX", -20);
    }

    public void SetBgmVolme()
    {

        if (isSFXMute)
        {
            // 로그 연산 값 전달
            audioMixer.SetFloat("BGM", bgmSlider.value);
            bgmVolume = Mathf.InverseLerp(-80f, 0f, bgmSlider.value) * 100f;

            bgmVolumeText.text = Mathf.RoundToInt(bgmVolume).ToString();

        }




    }

    public void SetSFXVolme()
    {
        if (isSFXMute)
        {
            // 로그 연산 값 전달
            audioMixer.SetFloat("SFX", sfxSlider.value);
            sfxVolume = Mathf.InverseLerp(-80f, 0f, sfxSlider.value) * 100f;

            sfxVolumeText.text = Mathf.RoundToInt(sfxVolume).ToString();

        }


    }

    public void BGMMute()
    {
        if (isBGMMute)
        {
            audioMixer.SetFloat("BGM", -80);
            bgmMuteButon.SetActive(false);
            bgmSlider.interactable = false;
            isBGMMute = false;

        }
        else if (!isBGMMute)
        {
            audioMixer.SetFloat("BGM", bgmSlider.value);
            bgmMuteButon.SetActive(true);
            bgmSlider.interactable = true;
            isBGMMute = true;
            PlayButtonSFX();

        }
    }
    public void SFXMute()
    {

        if (isSFXMute)
        {
            audioMixer.SetFloat("SFX", -80);
            sfxMuteButon.SetActive(false);
            sfxSlider.interactable = false;
            isSFXMute = false;
            PlayButtonSFX();

        }
        else if (!isSFXMute)
        {
            audioMixer.SetFloat("SFX", sfxSlider.value);
            sfxMuteButon.SetActive(true);
            sfxSlider.interactable = true;
            isSFXMute = true;
            PlayButtonSFX();

        }

    }

    public void ReasningBGM()
    {
        audioBGM.clip = Resources.Load<AudioClip>("03_Source/08_Sound/BGM/Reasoning_BGM");
        audioBGM.Play();

    }
    public void PlayButtonSFX()
    {

        buttonSFX.clip = Resources.Load<AudioClip>("03_Source/08_Sound/SFX/Button");
        buttonSFX.Play();
    }

    public void CardSpreadSFX()
    {
        buttonSFX.clip = Resources.Load<AudioClip>("03_Source/08_Sound/SFX/CARD_SOUND/Card_Set");
        buttonSFX.Play();
    }
    public void CardLeaveSFX()
    {
        //buttonSFX.Stop();
        buttonSFX.clip = Resources.Load<AudioClip>("03_Source/08_Sound/SFX/CARD_SOUND/Card_Leave");
        buttonSFX.Play();
    }
    public void CardSelecteSFX()
    {
        buttonSFX.clip = Resources.Load<AudioClip>("03_Source/08_Sound/SFX/CARD_SOUND/CardSelect");
        buttonSFX.Play();
    }

    public void winSFX()
    {
        audioBGM.Stop();
        buttonSFX.clip = Resources.Load<AudioClip>("03_Source/08_Sound/SFX/WIN_LOSE/WIN");
        buttonSFX.PlayOneShot(buttonSFX.clip);
    }
    public void loseSFX()
    {
        audioBGM.Stop();
        buttonSFX.clip = Resources.Load<AudioClip>("03_Source/08_Sound/SFX/WIN_LOSE/LOSE");
        buttonSFX.PlayOneShot(buttonSFX.clip);
    }
}
