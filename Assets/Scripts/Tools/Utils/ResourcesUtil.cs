using UnityEngine;
using System.Collections.Generic;

public class ResourcesUtil
{

    public enum Url
    {
        AudioClip, BattleAudioClip, GridAudioClip, PublicAudioClip, UiAudioClip,
        ChatEmotion,
        Effect,
        Font,
        SpineDatas,
        BattleBg, Body, Cube, GuardCard, HalfBody, Head, CircleHead, ItemIcon, SkillIcon, Illustration, LandMark, MapLevelBg, MapLevelFg, SetCard, TownBg, Weapon,
        TutorialActionMask,
        WeaponSpineDatas,
        DynamicToon,
        SpineMaterial,
		TouchAnim,
		Avatars,
    }

    private Dictionary<Url, string> urlDict;

    private static ResourcesUtil instance;
    public static ResourcesUtil GetInstance()
    {
        if (instance == null)
            instance = new ResourcesUtil();
        return instance;
    }

    public ResourcesUtil()
    {
        urlDict = new Dictionary<Url, string>();
        urlDict.Add(Url.AudioClip, "AudioClip/");
        urlDict.Add(Url.BattleAudioClip, "AudioClip/Battle/");
        urlDict.Add(Url.GridAudioClip, "AudioClip/Grid/");
        urlDict.Add(Url.PublicAudioClip, "AudioClip/Public/");
        urlDict.Add(Url.UiAudioClip, "AudioClip/UI/");

        urlDict.Add(Url.ChatEmotion, "Chat/Emotion/");

        urlDict.Add(Url.Effect, "Effect/");

        urlDict.Add(Url.Font, "Fonts/");

        urlDict.Add(Url.SpineDatas, "SpineDatas/");

        urlDict.Add(Url.BattleBg, "Texture/BattleBg/");
        urlDict.Add(Url.Body, "Texture/Body/");
        urlDict.Add(Url.Cube, "Texture/Cube/");
        urlDict.Add(Url.GuardCard, "Texture/GuardCard/");
        urlDict.Add(Url.HalfBody, "Texture/HalfBody/");
        urlDict.Add(Url.Head, "Texture/Head/");
        urlDict.Add(Url.CircleHead, "Texture/CircleHead/");
        urlDict.Add(Url.ItemIcon, "Texture/Icon/Item/");
        urlDict.Add(Url.SkillIcon, "Texture/Icon/Skill/");
        urlDict.Add(Url.Illustration, "Texture/Illustration/");
        urlDict.Add(Url.LandMark, "Texture/LandMark/");
        urlDict.Add(Url.MapLevelBg, "Texture/MapLevel/Background/");
        urlDict.Add(Url.MapLevelFg, "Texture/MapLevel/Foreground/");
        urlDict.Add(Url.SetCard, "Texture/SetCard/");
        urlDict.Add(Url.TownBg, "Texture/TownBg/");
        urlDict.Add(Url.Weapon, "Texture/Weapon/");

        urlDict.Add(Url.TutorialActionMask, "Tutorial/ActionMask/");
        urlDict.Add(Url.WeaponSpineDatas, "WeaponSpineDatas/");
        urlDict.Add(Url.SpineMaterial, "SpineDatas/SpineMaterial");

		urlDict.Add(Url.TouchAnim, "Utils/TouchAnim");
		urlDict.Add(Url.Avatars, "Avatars/");

    }


    public string GetUrl(Url url)
    {
        return urlDict[url];
    }

    public Sprite GetSprite(Url url, string id)
    {
        return Resources.Load<Sprite>(urlDict[url] + id);
    }

    public Sprite GetSprite(Url url, int id)
    {
        return Resources.Load<Sprite>(urlDict[url] + id);
    }

    public Sprite GetSprite(string url)
    {
        return Resources.Load<Sprite>(url);
    }

    public Sprite[] GetAllSprite(Url url)
    {
        return Resources.LoadAll<Sprite>(urlDict[url]);
    }

    public AudioClip GetAudioClip(Url url, string id)
    {
        return Resources.Load<AudioClip>(urlDict[url] + id);
    }

    public GameObject GetGameObject(Url url, string id)
    {
        return Resources.Load<GameObject>(urlDict[url] + id);
    }

    public GameObject GetGameObject(string url)
    {
        return Resources.Load<GameObject>(url);
    }

    public Font GetFont(Url url, string id)
    {
        return Resources.Load<Font>(urlDict[url] + id);
    }

    public Material GetMaterial(Url url, string id)
    {
        return Resources.Load<Material>(urlDict[url] + id);
    }

    public Material GetUniqueMaterial(Url url)
    {
        return Resources.Load<Material>(urlDict[url]);
    }

    public TextAsset GetTextAsset(string url)
    {
        return Resources.Load<TextAsset>(url);
    }

    public Texture GetTexture(string url)
    {
        return Resources.Load<Texture>(url);
    }
}

