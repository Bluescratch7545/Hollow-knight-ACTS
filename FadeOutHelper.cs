using MagicUI.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hollow_knight_ACTS
{
    internal class FadeOutHelper
    {
        internal static IEnumerator FadeText(TextObject text, float from, float to, float duration)
        {
            float timer = 0f;

            Color baseColor = text.ContentColor;

            while (timer < duration)
            {
                timer += Time.deltaTime;

                float alpha = Mathf.Lerp(from, to, timer / duration);

                text.ContentColor = new Color(
                    baseColor.r,
                    baseColor.g,
                    baseColor.b,
                    alpha
                );

                yield return null;
            }

            text.ContentColor = new Color(
                baseColor.r,
                baseColor.g,
                baseColor.b,
                to
            );
        }
    }
}
