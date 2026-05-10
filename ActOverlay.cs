using MagicUI.Core;
using MagicUI.Elements;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using WavLib;
using Img = UnityEngine.UI.Image;
using System.IO;
using System.Reflection;

namespace Hollow_knight_ACTS
{
    internal class ActOverlay
    {
        public static class ActOverlay_01
        {
            public static IEnumerator PlayCutscene(LayoutRoot layout, AudioSource ACT_MUSIC)
            {
                GameCameras.instance.hudCanvas.gameObject.SetActive(false);

                

                /* canvasObj = new GameObject("ACT_BLACK_BG");
                var canvas = canvasObj.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.overrideSorting = true;
                canvas.sortingOrder = 0;

                var imageObj = new GameObject("BG");
                imageObj.transform.SetParent(canvasObj.transform);

                var img = imageObj.AddComponent<Img>();
                img.color = new Color(0f, 0f, 0f, 1f);

                // stretch full screen
                var rt = img.rectTransform;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                rt.offsetMin = Vector2.zero;
                rt.offsetMax = Vector2.zero;*/
                yield return new WaitUntil(() => HeroController.instance != null);

                // wait until control is actually given back
                yield return new WaitUntil(() => HeroController.instance.acceptingInput);

                // extra safety delay for Tutorial_01 intro override
                yield return new WaitForSeconds(0.5f);

                GameCameras.instance.cameraFadeFSM.Fsm.Event("FADE OUT");

                var actText = new TextObject(layout)
                {
                    Text = "ACT 1",
                    FontSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    Padding = new(10,60,10,10)
                };

                // instant appear
                yield return null;
                ACT_MUSIC.clip = LoadEmbeddedWav("Hollow_knight_ACTS.Resources.ui titlecard pt 1.wav");
                ACT_MUSIC.Play();

                yield return new WaitForSeconds(4f);

                var subtitle = new TextObject(layout)
                {
                    Text = "Enter Hallownest",
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                ACT_MUSIC.clip = LoadEmbeddedWav("Hollow_knight_ACTS.Resources.ui titlecard pt 2.wav");
                ACT_MUSIC.Play();

                yield return new WaitForSeconds(5f);

                actText.Destroy();
                subtitle.Destroy();
                //GameObject.Destroy(canvasObj);
                GameCameras.instance.cameraFadeFSM.Fsm.Event("FADE SCENE IN");

                GameCameras.instance.hudCanvas.gameObject.SetActive(true);
            }
        }

        public static class ActOverlay_02
        {
            public static IEnumerator PlayCutscene(LayoutRoot layout, AudioSource ACT_MUSIC)
            {
                GameCameras.instance.hudCanvas.gameObject.SetActive(false);

                /* canvasObj = new GameObject("ACT_BLACK_BG");
                var canvas = canvasObj.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.overrideSorting = true;
                canvas.sortingOrder = 0;

                var imageObj = new GameObject("BG");
                imageObj.transform.SetParent(canvasObj.transform);

                var img = imageObj.AddComponent<Img>();
                img.color = new Color(0f, 0f, 0f, 1f);

                // stretch full screen
                var rt = img.rectTransform;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                rt.offsetMin = Vector2.zero;
                rt.offsetMax = Vector2.zero;*/
                yield return new WaitUntil(() => HeroController.instance != null);

                // wait until control is actually given back
                yield return new WaitUntil(() => HeroController.instance.acceptingInput);

                // extra safety delay for Tutorial_01 intro override
                yield return new WaitForSeconds(0.5f);

                GameCameras.instance.cameraFadeFSM.Fsm.Event("FADE OUT");

                var actText = new TextObject(layout)
                {
                    Text = "ACT 2",
                    FontSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    Padding = new(10,60,10,10)
                };

                // instant appear
                yield return null;
                ACT_MUSIC.clip = LoadEmbeddedWav("Hollow_knight_ACTS.Resources.ui titlecard pt 1.wav");
                ACT_MUSIC.Play();

                yield return new WaitForSeconds(4f);

                var subtitle = new TextObject(layout)
                {
                    Text = "Kingdoms Depths",
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                ACT_MUSIC.clip = LoadEmbeddedWav("Hollow_knight_ACTS.Resources.ui titlecard pt 2.wav");
                ACT_MUSIC.Play();

                yield return new WaitForSeconds(5f);

                actText.Destroy();
                subtitle.Destroy();
                //GameObject.Destroy(canvasObj);
                GameCameras.instance.cameraFadeFSM.Fsm.Event("FADE SCENE IN");

                GameCameras.instance.hudCanvas.gameObject.SetActive(true);
            }
        }

        public static class ActOverlay_03
        {
            public static IEnumerator PlayCutscene(LayoutRoot layout, AudioSource ACT_MUSIC)
            {
                GameCameras.instance.hudCanvas.gameObject.SetActive(false);

                /* canvasObj = new GameObject("ACT_BLACK_BG");
                var canvas = canvasObj.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.overrideSorting = true;
                canvas.sortingOrder = 0;

                var imageObj = new GameObject("BG");
                imageObj.transform.SetParent(canvasObj.transform);

                var img = imageObj.AddComponent<Img>();
                img.color = new Color(0f, 0f, 0f, 1f);

                // stretch full screen
                var rt = img.rectTransform;
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                rt.offsetMin = Vector2.zero;
                rt.offsetMax = Vector2.zero;*/
                yield return new WaitUntil(() => HeroController.instance != null);

                // wait until control is actually given back
                yield return new WaitUntil(() => HeroController.instance.acceptingInput);

                // extra safety delay for Tutorial_01 intro override
                yield return new WaitForSeconds(0.5f);

                GameCameras.instance.cameraFadeFSM.Fsm.Event("FADE OUT");

                var actText = new TextObject(layout)
                {
                    Text = "ACT 3",
                    FontSize = 40,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    Padding = new(10,60,10,10)
                };

                // instant appear
                yield return null;
                ACT_MUSIC.clip = LoadEmbeddedWav("Hollow_knight_ACTS.Resources.ui titlecard pt 1.wav");
                ACT_MUSIC.Play();

                yield return new WaitForSeconds(4f);

                var subtitle = new TextObject(layout)
                {
                    Text = "Deepest Sleep",
                    FontSize = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                ACT_MUSIC.clip = LoadEmbeddedWav("Hollow_knight_ACTS.Resources.ui titlecard pt 2.wav");
                ACT_MUSIC.Play();

                yield return new WaitForSeconds(5f);

                actText.Destroy();
                subtitle.Destroy();
                //GameObject.Destroy(canvasObj);
                GameCameras.instance.cameraFadeFSM.Fsm.Event("FADE SCENE IN");

                GameCameras.instance.hudCanvas.gameObject.SetActive(true);
            }
        }

        public static AudioSource SetupMusicGameObject()
        {

            var am = new GameObject("ACT_MUSIC_DAT");
            var ACT_MUSIC_DAT = am.AddComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(am);
            return ACT_MUSIC_DAT;
        }

        public static AudioClip LoadEmbeddedWav(string resourceName)
        {
            var asm = Assembly.GetExecutingAssembly();

            using Stream s = asm.GetManifestResourceStream(resourceName);
            using MemoryStream ms = new MemoryStream();

            s.CopyTo(ms);
            ms.Position = 0;

            // optional debug inspect (SAFE)
            WavData.Inspect(ms, msg => HKACTS.Instance.Log(msg));

            ms.Position = 0;

            var wav = new WavData();
            wav.Parse(ms, msg => HKACTS.Instance.Log(msg));

            float[] samples = wav.GetSamples();

            var clip = AudioClip.Create(
                resourceName,
                samples.Length / wav.FormatChunk.NumChannels,
                wav.FormatChunk.NumChannels,
                (int)wav.FormatChunk.SampleRate,
                false
            );

            clip.SetData(samples, 0);
            return clip;
        }
    }
}
