# UnityTools
A variety of small tools/utilities for development with Unity.

## Usage
Each .cs file is independent unless otherwise indicated. Include individually in your project as needed.

## Tool List

### CoroutineTools
Provides Coroutine functionality statically. Works analogously to MonoBehaviour.StartCoroutine(IEnumerator), MonoBehaviour.StopCoroutine(Coroutine) and MonoBehaviour.StopAllCoroutines().
The script creates a temporary host monobehaviour to run the coroutine(s) and manages its lifetime.

### BasicAnimations
Simple one-line method to enable smooth rotations, tranlations and growth (scale change) from zero over a specified duration, with a callback upon completion. Easily modifiable to e.g. change type of callback function, or smoothing curve.

*Relies on CoroutineTools.*

### AsyncFireAndForget
Allows async fire-and-forget methods. Essentially, this is a wrapper for System.Threading.Tasks.Task.Run(...) that enables one to catch exceptions and display them as LogErrors (and hence greatly help with debugging).
