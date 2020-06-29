@file:Suppress("DEPRECATION")

package com.kadinche.example.toastywrapper

import android.app.Fragment
import android.os.Bundle
import com.unity3d.player.UnityPlayer
import es.dmoral.toasty.Toasty

private val TAG = ToastyFragment::class.simpleName

interface PluginCallback {
    fun sendResponse(count: Int)
}

@Suppress("unused")
class ToastyFragment : Fragment() {
    private var count = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        retainInstance = true
    }

    fun success(message: String, callback: PluginCallback) {
        val msg = (if (BuildConfig.DEBUG) "IN DEBUG: " else "") + message
        Toasty.success(UnityPlayer.currentActivity, msg).show()
        count++
        callback.sendResponse(count)
    }

    companion object {
        private var instance: ToastyFragment? = null

        @JvmStatic
        fun getInstance() =
            instance ?: synchronized(this) {
                instance ?: ToastyFragment().also {
                    instance = it
                    UnityPlayer.currentActivity.fragmentManager
                        .beginTransaction().add(it, TAG).commit()
                }
            }
    }
}
