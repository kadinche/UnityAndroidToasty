using UnityEngine;
using UnityEngine.UI;

namespace Kadinche.Example.Plugin
{
    public class Toasty : MonoBehaviour
    {
        [SerializeField] private Text countText = default;

        private AndroidJavaClass _jClass;
        private AndroidJavaObject _jInstance;
        private AndroidPluginCallback _callback;

        private void OnEnable()
        {
            _jClass = new AndroidJavaClass("com.kadinche.example.toastywrapper.ToastyFragment");
            _jInstance = _jClass.CallStatic<AndroidJavaObject>("getInstance");
            _callback = new AndroidPluginCallback(countText);
        }

        private void OnDisable()
        {
            _jInstance?.Dispose();
            _jClass?.Dispose();
        }

        public void Success(string message)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _jInstance.Call("success", message, _callback);
#endif
        }
    }

    public class AndroidPluginCallback : AndroidJavaProxy
    {
        private readonly Text _text;

        public AndroidPluginCallback(Text text) : base("com.kadinche.example.toastywrapper.PluginCallback")
        {
            _text = text;
        }

        public void sendResponse(int count)
        {
            _text.text = $"{count}";
        }
    }
}