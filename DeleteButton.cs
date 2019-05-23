using Synth.mods.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace DeleteSongScript
{
    public class DeleteButton : MonoBehaviour
    {

        public Button button;

        public GameObject wrapper;

        public GameObject canvas;

        public static DeleteButton s_instance;

        private bool canvasSet = false;

        private Action<GameObject> setUICanvasCallback;

        public static Action<GameObject> SetUICanvasCallback
        {
            get
            {
                return s_instance.setUICanvasCallback;
            }

            set
            {
                s_instance.setUICanvasCallback = value;
            }
        }

        private List<TrackData> tracks;

        public static List<TrackData> Tracks
        {
            get
            {
                return s_instance.tracks;
            }

            set
            {
                s_instance.tracks = value;
            }
        }

        private Action<Action, bool> refreshCallback;

        public static Action<Action, bool> RefreshCallback
        {
            get
            {
                return s_instance.refreshCallback;
            }

            set
            {
                s_instance.refreshCallback = value;
            }
        }

        private int currentSong;

        public static int CurrrentSong
        {
            get
            {
                return s_instance.currentSong;
            }

            set
            {
                s_instance.currentSong = value;
            }
        }

        // Use this for initialization
        void Awake()
        {
            if (s_instance != null)
            {
                Destroy(this);
            }

            s_instance = this;
            DontDestroyOnLoad(this);
            button.onClick.AddListener(DeleteSong);
        }

        void Start()
        {
            if (s_instance == null) { return; }

            wrapper.SetActive(false);
        }

        private void Update()
        {

        }

        public static void ShowMe()
        {
            if (!s_instance) { return; }

            s_instance.wrapper.SetActive(true);
        }

        public static void HideMe()
        {
            if (!s_instance) { return; }

            s_instance.wrapper.SetActive(false);
        }

        public static void DestroyMe()
        {
            if (s_instance == null) { return; }

            Destroy(s_instance);
        }

        public static void InitCanvasVRTK()
        {
            if (!s_instance.canvasSet && s_instance.setUICanvasCallback != null)
            {
                s_instance.canvasSet = true;
                s_instance.setUICanvasCallback(s_instance.canvas);
            }
        }

        public static void DeleteSong()
        {
            if (s_instance.wrapper.activeSelf)
            {
                if (Tracks[CurrrentSong].isCustomSong)
                {
                    Log("Deleting " + Tracks[CurrrentSong].filePath);
                    File.Delete(Tracks[CurrrentSong].filePath);
                    RefreshCallback(null,true);
                }
            }
        }

        public static void Log(string str)
        {
            //get file path
            var dataPath = Application.dataPath;
            var filePath = dataPath.Substring(0, dataPath.LastIndexOf('/')) + "/Novalog.txt";

            //write
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write(str);
            }
        }
    }
}