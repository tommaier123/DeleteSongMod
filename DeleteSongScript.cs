using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMod;
using Synth.mods.events;
using Synth.mods.utils;
using Synth.mods.interactions;
using System;
using Synth.mods.info;
using System.IO;

namespace DeleteSongScript
{
    public class DeleteScript : ModScript, ISynthRidersEvents, ISynthRidersInfo, ISynthRidersInteractions
    {

        public override void OnModLoaded()
        {
            var deleteButton = ModAssets.Instantiate<GameObject>("DeleteButton_pre");
            log("DeleteMod loaded");
        }

        public override void OnModUnload()
        {
            DeleteButton.DestroyMe();
            log("DeleteMod unloaded");
        }

        public void OnRoomLoaded()
        {
            DeleteButton.ShowMe();
        }

        public void OnRoomUnloaded()
        {
            DeleteButton.HideMe();
        }

        public void OnGameStageLoaded(TrackData trackData)
        {

        }

        public void OnGameStageUnloaded()
        {
            
        }

        public void OnScoreStageLoaded()
        {
            
        }

        public void OnScoreStageUnloaded()
        {
            
        }

        public void OnPointScored(PointsData pointsData)
        {
            
        }

        public void OnNoteFail(PointsData pointsData)
        {
            
        }

        public void OnSongFinished(SongFinishedData songFinishedData)
        {
            
        }

        public void OnSongFailed(TrackData trackData)
        {
           
        }

        public void SetUICanvasCallback(Action<GameObject> callback)
        {
            DeleteButton.SetUICanvasCallback = callback;
            DeleteButton.InitCanvasVRTK();
        }

        public void SetGameOverCallback(Action callback)
        {
            
        }

        public void SetPlayTrackCallback(Action<int, int, int> callback)
        {
            
        }

        public void SetSelectedTrackCallback(Action<int> callback)
        {

        }

        public void SetLoadedTracks(List<TrackData> tracks)
        {
            DeleteButton.Tracks = tracks;
        }

        public void SetLoadedStages(List<StageData> stages)
        {

        }

        public void SetUserSelectedColors(Color leftHandColor, Color rightHandColor, Color oneHandSpecialColor, Color bothHandSpecialColor)
        {

        }

        public void SetCurrentSongSelected(int CurrentSong)
        {
            DeleteButton.CurrrentSong = CurrentSong;
        }

        public void SetRefreshCallback(Action<Action, bool> callback)
        {
            DeleteButton.RefreshCallback = callback;
        }

        public void SetFilterTrackCallback(Action<List<string>, Action, bool> callback)
        {
            
        }

        public void SetLoseLifeCallback(Action callback)
        {

        }

        public void SetSongModifier(Action<int[]> callback)
        {

        }

        public void SetSongPitchCallback(Action<float> callback)
        {

        }

        public void log(string str)
        {
            //get file path
            var dataPath = Application.dataPath;
            var filePath = dataPath.Substring(0, dataPath.LastIndexOf('/')) + "/Novalog.txt";

            //write
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(str);
            }
        }
    }
}