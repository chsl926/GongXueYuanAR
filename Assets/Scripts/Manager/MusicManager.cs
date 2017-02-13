using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SimpleFramework.Manager {
    public class MusicManager : View {
        private AudioSource audio = null;
        private Hashtable sounds = new Hashtable();

        void Awake() {
            if (!GetComponent<AudioSource>())
                gameObject.AddComponent<AudioSource>();
            audio = GetComponent<AudioSource>();
        }

        /// <summary>
        /// ���һ������
        /// </summary>
        void Add(string key, AudioClip value) {
            if (sounds[key] != null || value == null) return;
            sounds.Add(key, value);
        }

        /// <summary>
        /// ��ȡһ������
        /// </summary>
        AudioClip Get(string key) {
            if (sounds[key] == null) return null;
            return sounds[key] as AudioClip;
        }

        /// <summary>
        /// ����һ����Ƶ
        /// </summary>
        public AudioClip LoadAudioClip(string path) {
            AudioClip ac = Get(path);
            if (ac == null) {
                ac = (AudioClip)Resources.Load(path, typeof(AudioClip));
                Add(path, ac);
            }
            return ac;
        }

        /// <summary>
        /// �Ƿ񲥷ű������֣�Ĭ����1������
        /// </summary>
        /// <returns></returns>
        public bool CanPlayBackSound() {
            string key = AppConst.AppPrefix + "BackSound";
            int i = PlayerPrefs.GetInt(key, 1);
            return i == 1;
        }

        /// <summary>
        /// ���ű�������
        /// </summary>
        /// <param name="canPlay"></param>
        public void PlayBacksound(string name, bool canPlay) {
            if (audio.clip != null) {
                if (name.IndexOf(audio.clip.name) > -1) {
                    if (!canPlay) {
                        audio.Stop();
                        audio.clip = null;
                        Util.ClearMemory();
                    }
                    return;
                }
            }
            if (canPlay) {
                audio.loop = true;
                audio.clip = LoadAudioClip(name);
                audio.Play();
            } else {
                audio.Stop();
                audio.clip = null;
                Util.ClearMemory();
            }
        }

        /// <summary>
        /// �Ƿ񲥷���Ч,Ĭ����1������
        /// </summary>
        /// <returns></returns>
        public bool CanPlaySoundEffect() {
            string key = AppConst.AppPrefix + "SoundEffect";
            int i = PlayerPrefs.GetInt(key, 1);
            return i == 1;
        }

        /// <summary>
        /// ������Ƶ����
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="position"></param>
        public void PlayPos(AudioClip clip, Vector3 position) {
            if (!CanPlaySoundEffect()) return;
            AudioSource.PlayClipAtPoint(clip, position);
        }

        public void PlayObj(string name,GameObject obj,bool isLoop=false)
        {
            AudioSource _audio ;
            if (!obj.GetComponent<AudioSource>())
            {
                _audio = obj.AddComponent<AudioSource>();
            }
            else
            {
                _audio = obj.GetComponent<AudioSource>();
            }
           
            AssetBundle bundle = ResourceManager.Instance.LoadBundle(name);
            AudioClip clip = bundle.LoadAsset(name, typeof(AudioClip)) as AudioClip;
            _audio.clip = clip;
            _audio.loop = isLoop;
            _audio.Play();
        }
        public void PauseObj(GameObject obj)
        {
            obj.GetComponent<AudioSource>().Pause();
        }
        public void StopObj (GameObject obj)
        {
            obj.GetComponent<AudioSource>().Stop();
        }

        public void PlayBG(string name,bool isLoop)
        {
            AssetBundle bundle = ResManager.LoadBundle(name);
            AudioClip clip=bundle.LoadAsset(name, typeof(AudioClip)) as AudioClip;
            audio.clip = clip;
            audio.loop = isLoop;
            audio.Play();

        }
        public void PauseBG()
        {
            audio.Pause();
        }
        public void StopBG()
        {
            audio.Stop();
        }
    }
}