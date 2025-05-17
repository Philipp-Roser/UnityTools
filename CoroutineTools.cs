/* Created by Philipp Roser. https://github.com/Philipp-Roser */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTools
{

    public static class CoroutineTools
    {
        //--------------- API ---------------

        /// <summary> Starts a monobehaviour-free coroutine. </summary>
        public static Coroutine StartCoroutine(IEnumerator coroutine) => _StartCoroutine(coroutine);

        /// <summary> Stops a monobehaviour-free coroutine. </summary>
        public static void StopCoroutine(Coroutine coroutine) => _StopCoroutine(coroutine);

        /// <summary> Stops all monobehaviour-free coroutines. </summary>
        public static void StopAllCoroutines() => _StopAllCoroutines();


        // --------- Implementation ---------

        private class CoroutineHost : MonoBehaviour
        { }

        private static CoroutineHost _host;

	    public static Coroutine _StartCoroutine(IEnumerator coroutine)
        {
            if(_host == null)
            {
                GameObject go = new GameObject();
                go.name = "Coroutine Host";
                _host = go.AddComponent<CoroutineHost>();
            }


            return _host.StartCoroutine(coroutine);
        }

        public static void _StopCoroutine(Coroutine coroutine)
        {
            if ( _host == null )
                return;

            _host.StopCoroutine(coroutine);
            return;
        }

        public static void _StopAllCoroutines()
        {
            if ( _host == null )
                return;

            _host.StopAllCoroutines();
            return;
        }

 
    }
}
