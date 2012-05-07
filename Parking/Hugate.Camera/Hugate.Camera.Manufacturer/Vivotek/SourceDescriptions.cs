// Camara Vision
//
// Copyright © Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace Hugate.Camera
{
    using System;
    using System.Xml;

    /// <summary>
    /// PixordCameraDescription
    /// </summary>
    public class VivotekCameraDescription : IVideoSourceDescription
    {
        // Name property
        public string Name
        {
            get { return "Network Camera"; }
        }

        // Description property
        public string Description
        {
            get { return "Provides access to Vivotek network cameras"; }
        }

        // Return settings page
        public IVideoSourcePage GetSettingsPage()
        {
            return new VivotekCameraSetupPage();
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            VivotekConfiguration cfg = (VivotekConfiguration)config;

            if (cfg != null)
            {
                writer.WriteAttributeString("source", cfg.source);
                writer.WriteAttributeString("login", cfg.login);
                writer.WriteAttributeString("password", cfg.password);
                writer.WriteAttributeString("size", cfg.resolution);
                writer.WriteAttributeString("stype", ((int)cfg.stremType).ToString());
                writer.WriteAttributeString("interval", cfg.frameInterval.ToString());
            }
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            VivotekConfiguration config = new VivotekConfiguration();
            try
            {
                config.source = reader.GetAttribute("source");
                config.login = reader.GetAttribute("login");
                config.password = reader.GetAttribute("password");
                config.resolution = reader.GetAttribute("size");
                config.stremType = (StreamType)(int.Parse(reader.GetAttribute("stype")));
                config.frameInterval = int.Parse(reader.GetAttribute("interval"));
            }
            catch (Exception)
            {
            }
            return (object)config;
        }

        // Create video source object
        public IVideoSource CreateVideoSource(object config)
        {
            VivotekConfiguration cfg = (VivotekConfiguration)config;

            if (cfg != null)
            {
                VivotekCamera source = new VivotekCamera();

                source.StreamType = cfg.stremType;
                source.VideoSource = cfg.source;
                source.Login = cfg.login;
                source.Password = cfg.password;
                source.Resolution = cfg.resolution;
                source.FrameInterval = cfg.frameInterval;

                return (IVideoSource)source;
            }
            return null;
        }

        public object LoadConfiguration(string source, string login, string password, string size, string stype, string quality, string interval)
        {
            VivotekConfiguration config = new VivotekConfiguration();
            try
            {
                config.source = source;
                config.login = login;
                config.password = password;
                config.resolution = size;
                config.stremType = (StreamType)(int.Parse(stype));
                config.quality = quality;
                config.frameInterval = int.Parse(interval);
                config.streamIndex = 0;
            }
            catch (Exception)
            {
            }
            return (object)config;
        }
    }
}