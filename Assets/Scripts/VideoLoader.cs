using UnityEngine;
using UnityEngine.Video;
using System.IO;
[RequireComponent(typeof(VideoPlayer))]
public class VideoLoader : MonoBehaviour 
{

    [SerializeField]
    private string relativePath;


    // Use this for initialization
    void Start()
    {
        VideoPlayer videoplayer = GetComponent<VideoPlayer>();

        videoplayer.source = VideoSource.Url;
        videoplayer.url = Path.Combine(Application.streamingAssetsPath, relativePath);
        videoplayer.isLooping = true;
        videoplayer.Play();
    
        // 読込完了時のコールバック
        // videoplayer.prepareCompleted += PrepareCompleted;
        // videoplayer.Prepare();

    }
    // void PrepareCompleted(VideoPlayer vp)
    // {
    //     vp.prepareCompleted -= PrepareCompleted;
    //     vp.Play();
    // }

    // public void VideoPlayerControl()
    // {
    //     VideoPlayer videoplayer = GetComponent<VideoPlayer>();

    //     if(!videoplayer.isPlaying) {
    //         videoplayer.Play();
    //     } else {
    //         videoplayer.Pause();
    //     }
    // }
}