// Camara Vision
//
// Copyright © Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace Hugate.Camera
{
    using System;
    /// <summary>
    /// PixordConfiguration
    /// </summary>
    public class VivotekConfiguration
    {
        public string source;
        public string login;
        public string password;
        public int streamIndex = 0;
        public int frameInterval = 0;
        public StreamType stremType = StreamType.Jpeg;
        public string resolution;
        public string quality;
    }
}
