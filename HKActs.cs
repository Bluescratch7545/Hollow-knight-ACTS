using MagicUI.Core;
using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UObject = UnityEngine.Object;

namespace Hollow_knight_ACTS
{
    public class HKACTS : Mod, ILocalSettings<SaveStateLocal>
    {
        public static SaveStateLocal saveSettings { get; set; } = new SaveStateLocal();
        public void OnLoadLocal(SaveStateLocal s) => saveSettings = s;
        public SaveStateLocal OnSaveLocal() => saveSettings;

        internal static HKACTS Instance;

        #nullable enable
        internal LayoutRoot? layout;
        internal CoroutineRunner runner;

        internal bool debugBoundStatePersistent = false;

        internal AudioSource ACT_MUSIC;


        public HKACTS() : base("Hollow Knight ACTS")
        {
            Instance = this;
        }

        public override string GetVersion() => "1.0.0.0";

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Instance.Log("Initializing...");

            Instance = this;

            GameObject obj = new GameObject("HKACTS_COROUTINE DATA RUNNER");
            UObject.DontDestroyOnLoad(obj);

            runner = obj.AddComponent<CoroutineRunner>();

            On.GameManager.OnNextLevelReady += DetectPlayerActLoc;

            On.HeroController.Awake += OnSaveOpened;

            layout = new LayoutRoot(true, "Persistent layout");
            layout.VisibilityCondition = () => true;

            ACT_MUSIC = ActOverlay.SetupMusicGameObject();


            foreach (var e in GameCameras.instance.cameraFadeFSM.Fsm.Events)
            {
                Modding.Logger.Log(e.Name);
            }

            Instance.Log("Initialized");
        }

        private void DetectPlayerActLoc(On.GameManager.orig_OnNextLevelReady orig, GameManager self)
        {
            orig(self);

            if (layout == null)
            {
                layout = new(true, "Persistent layout");

                layout.RenderDebugLayoutBounds = debugBoundStatePersistent;
            }

            if (self.sceneName == "Tutorial_01" && !saveSettings.IsInAct1)
            {
                Instance.Log("Act1 entered");
                runner.StartCoroutine(ActOverlay.ActOverlay_01.PlayCutscene(layout, ACT_MUSIC));
                saveSettings.IsInAct1 = true;
            }
            if (PlayerData.instance.hasDoubleJump && !saveSettings.IsInAct2 && saveSettings.IsInAct1)
            {
                Instance.Log("Act2 entered");
                runner.StartCoroutine(ActOverlay.ActOverlay_02.PlayCutscene(layout, ACT_MUSIC));
                saveSettings.IsInAct2 = true;
            }
            if (PlayerData.instance.killedFinalBoss)
            {
                Instance.Log("Act3 Accessible in save reload!");
                saveSettings.CanAccessAct3 = true;
            }
        }

        private void OnSaveOpened(On.HeroController.orig_Awake orig, HeroController self)
        {
            orig(self);

            if (saveSettings.CanAccessAct3 && !saveSettings.IsInAct3)
            {
                Instance.Log("Act3 entered on save reload!");
                runner.StartCoroutine(ActOverlay.ActOverlay_03.PlayCutscene(layout, ACT_MUSIC));
                saveSettings.IsInAct3 = true;
            }
            else
            {
                Instance.Log("Cannot enter Act3 on save enter because conditions not met");
            }
        }
        public void Unload()
        {
            On.HeroController.Awake -= OnSaveOpened;
            layout?.Destroy();
            layout = null;
        }

        public List<IMenuMod.MenuEntry> GetMenuData(IMenuMod.MenuEntry? toggleButtonEntry)
        {
            List<IMenuMod.MenuEntry> items = new()
            {
                new IMenuMod.MenuEntry {
                    Name = "Show Debug Bounds",
                    Values = new string[] {"On", "Off"},
                    Saver = opt => SetDebugBoundState(opt == 0),
                    Loader = () => debugBoundStatePersistent ? 0 : 1
                }
            };
            if (toggleButtonEntry != null)
            {
                items.Insert(0, (IMenuMod.MenuEntry)toggleButtonEntry);
            }
            return items;
        }
        private void SetDebugBoundState(bool value)
        {
            debugBoundStatePersistent = value;
            if (layout != null)
            {
                layout.RenderDebugLayoutBounds = value;
            }
        }
    }
}