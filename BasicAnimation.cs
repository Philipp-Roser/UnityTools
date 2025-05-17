/* Created by Philipp Roser. https://github.com/Philipp-Roser */


using UnityEngine;

/* WARNING: Relies on CoroutineTools class (see CoroutineTools.cs */

namespace UnityTools
{
    public static class BasicAnimations
    {
        public static Coroutine RotateSmoothly(this Transform transform, Vector3 axis, float angleInDeg, float duration, System.Action executeOnCompletion = null)
        {
            return CoroutineTools.StartCoroutine(RotateSmoothlyCoroutine());

            System.Collections.IEnumerator RotateSmoothlyCoroutine()
            {
                Quaternion startRot = transform.rotation;
                transform.Rotate(axis, angleInDeg);
                Quaternion targetRot = transform.rotation;
                transform.rotation = startRot;

                float rate = 1/duration;

                for(float t = 0; t < duration; t += Time.deltaTime )
                {
                    yield return null;
                    float s = t * rate;
                    float theta = angleInDeg * (3*s*s-2*s*s*s);
                    transform.rotation = startRot;
                    transform.Rotate(axis, theta);
                }

                transform.rotation = targetRot;
                if ( executeOnCompletion is not null )
                    executeOnCompletion();

            }
        }

        public static Coroutine TranslateSmoothly(this Transform transform, Vector3 targetPosition, float duration, System.Action executeOnCompletion = null)
        {
            return CoroutineTools.StartCoroutine(TranslateSmoothlyCoroutine());

            System.Collections.IEnumerator TranslateSmoothlyCoroutine()
            {
                Vector3 startPos = transform.position;
                float rate = 1/duration;

                for ( float t = 0; t < duration; t += Time.deltaTime )
                {
                    yield return null;
                    float s = t * rate;
                    float r =  3*s*s-2*s*s*s;
                    transform.position = startPos + r * (targetPosition - startPos);
                }

                transform.position = targetPosition;
                if ( executeOnCompletion is not null )
                    executeOnCompletion();

            }
        }


        public static Coroutine ShrinkToZero(this Transform transform, float duration, System.Action executeOnCompletion = null )
        {
            return CoroutineTools.StartCoroutine(ShrinkToZeroCoroutine());

            System.Collections.IEnumerator ShrinkToZeroCoroutine()
            {
                Vector3 startScale = transform.localScale;
                float rate = 1/duration;

                for(float t = 0; t < duration; t += Time.deltaTime )
                {
                    yield return null;
                    float s = t*rate;
                    transform.localScale = (1 - 3 * s * s + 2 * s * s * s) * startScale; 
                }

                transform.localScale = Vector3.zero;
                if(executeOnCompletion is not null)
                    executeOnCompletion();
            }
        }

        public static Coroutine GrowFromZero(this Transform transform, Vector3 targetScale, float duration, System.Action executeOnCompletion= null)
        {
            return CoroutineTools.StartCoroutine(ShrinkToZeroCoroutine());

            System.Collections.IEnumerator ShrinkToZeroCoroutine()
            {
                transform.localScale = Vector3.zero;

                float rate = 1/duration;
                for ( float t = 0; t < duration; t += Time.deltaTime )
                {
                    yield return null;
                    float s = t*rate;
                    transform.localScale =  ( 3 * s * s - 2 * s * s * s) * targetScale;
                }

                transform.localScale = targetScale;
                if ( executeOnCompletion is not null )
                    executeOnCompletion();
            }
        }
    }
}
