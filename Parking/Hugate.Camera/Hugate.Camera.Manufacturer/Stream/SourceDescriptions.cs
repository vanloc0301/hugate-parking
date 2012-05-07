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
	/// VideoStreamSourceDescription
	/// </summary>
	public class VideoStreamSourceDescription : IVideoSourceDescription
	{
		// Name property
		public string Name
		{
			get { return "Video stream"; }
		}

		// Description property
		public string Description
		{
			get { return "Downloads video from video streaming servers"; }
		}

		// Return settings page
		public IVideoSourcePage GetSettingsPage()
		{
			return new VideoStreamSetupPage();
		}

		// Save configuration
		public void SaveConfiguration(XmlTextWriter writer, object config)
		{
			StreamConfiguration cfg = (StreamConfiguration) config;

			if (cfg != null)
			{
				writer.WriteAttributeString("source", cfg.source);
			}
		}

		// Load configuration
		public object LoadConfiguration(XmlTextReader reader)
		{
			StreamConfiguration config = new StreamConfiguration();

			try
			{
				config.source = reader.GetAttribute("source");
			}
			catch (Exception)
			{
			}
			return (object) config;
		}

		// Create video source object
		public IVideoSource CreateVideoSource(object config)
		{
			StreamConfiguration cfg = (StreamConfiguration) config;
			
			if (cfg != null)
			{
				VideoStream source = new VideoStream();

				source.VideoSource	= cfg.source;

				return (IVideoSource) source;
			}
			return null;
        }

        public object LoadConfiguration(string source, string login, string password, string size, string stype, string quality, string interval)
        {
            PanasonicConfiguration config = new PanasonicConfiguration();
            try
            {
                config.source = source;
                config.login = login;
                config.password = password;
                config.resolution = size;
                config.stremType = (StreamType)(int.Parse(stype));
                config.quality = quality;
                config.frameInterval = int.Parse(interval);
            }
            catch (Exception)
            {
            }
            return (object)config;
        }
    }
}
