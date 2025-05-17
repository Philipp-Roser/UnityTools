/* Created by Philipp Roser. https://github.com/Philipp-Roser */

using System;
using UnityEngine;

namespace UnityTools
{
    public static class AsyncTools
    {
        /// <summary> Effectively Task.Run(...), except catches exceptions and outputs them as LogErrors to the console. </summary>
        public static void FireAndForgetAsync(Action action )
        {
            System.Threading.Tasks.Task.Run( () => 
            {
                try { action.Invoke(); }
                catch ( Exception e ) { Debug.LogError(e); }
            });
        }
    }
}