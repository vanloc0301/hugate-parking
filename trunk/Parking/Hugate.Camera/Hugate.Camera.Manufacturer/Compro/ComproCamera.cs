using System;
namespace Hugate.Camera
{
    public class ComproCamera : MultimodeVideoSource
    {
        private string server;
        private short channel = 1;
        private string resolution = "QVGA";
        private int frameInterval;
        private string quality = "Standard";

        // Constructor
        public ComproCamera()
        {
            videoSource = new JPEGSource();
            streamType = StreamType.Jpeg;
        }

        // StreamType property
        public override StreamType StreamType
        {
            get { return base.StreamType; }
            set
            {
                if ((value != StreamType.Jpeg) &&
                    (value != StreamType.MJpeg))
                    throw new ArgumentException("Invalid stream type");
                base.StreamType = value;
            }
        }
        // VideoSource property
        public override string VideoSource
        {
            get { return server; }
            set
            {
                server = value;
                UpdateVideoSource();
            }
        }
        // Resolution property
        public string Resolution
        {
            get { return resolution; }
            set
            {
                resolution = value;
                UpdateVideoSource();
            }
        }
        // FrameInterval property - interval between frames
        public int FrameInterval
        {
            get { return frameInterval; }
            set
            {
                frameInterval = value;

                if (streamType == StreamType.Jpeg)
                {
                    ((JPEGSource)videoSource).FrameInterval = frameInterval;
                }
                else
                {
                    UpdateVideoSource();
                }
            }
        }
        // Update video source
        protected override void UpdateVideoSource()
        {
            //string a = "http://<servername>/cgi-bin/viewer/video.jpg";
            //192.168.1.167/cgi-bin/view/ss.cgi/Images/snapshot.jpg
            switch (streamType)
            {
                case StreamType.Jpeg:
                    videoSource.VideoSource = "http://" + server + "/cgi-bin/view/ss.cgi/Images/snapshot.jpg";
                    break;
                case StreamType.MJpeg:
                    {
                        string src = "http://" + server + "/getimage?camera=" + channel.ToString() + "&fmt=" + resolution;

                        if (frameInterval > 0)
                        {
                            src += "&delay=" + ((int)(frameInterval / 10)).ToString();
                        }
                        videoSource.VideoSource = src;
                        break;
                    }
            }
        }
    }
}
