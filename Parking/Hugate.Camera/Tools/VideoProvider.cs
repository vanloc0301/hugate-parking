namespace Hugate.Camera
{
    using System;
    using System.Xml;

    /// <summary>
    /// VideoProvider class
    /// </summary>
    public class VideoProvider : IComparable
    {
        private IVideoSourceDescription sourceDesc = null;

        // Name property
        public string Name
        {
            get { return sourceDesc.Name; }
        }

        // Description property
        public string Description
        {
            get { return sourceDesc.Description; }
        }

        // ProviderName property
        public string ProviderName
        {
            get { return sourceDesc.GetType().ToString(); }
        }


        // Constructor
        public VideoProvider(IVideoSourceDescription sourceDesc)
        {
            this.sourceDesc = sourceDesc;
        }

        // Compares objects of the type
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            VideoProvider p = (VideoProvider)obj;
            return (this.Name.CompareTo(p.Name));
        }

        // Get video source settings page
        public IVideoSourcePage GetSettingsPage()
        {
            return sourceDesc.GetSettingsPage();
        }

        // Save configuration
        public void SaveConfiguration(XmlTextWriter writer, object config)
        {
            sourceDesc.SaveConfiguration(writer, config);
        }

        // Load configuration
        public object LoadConfiguration(XmlTextReader reader)
        {
            return sourceDesc.LoadConfiguration(reader);
        }

        public object LoadConfiguration(string source, string login, string password, string size, string stype, string quality, string interval)
        {
            return sourceDesc.LoadConfiguration(source, login, password, size, stype, quality, interval);
        }

        // Create video source
        public IVideoSource CreateVideoSource(object config)
        {
            return sourceDesc.CreateVideoSource(config);
        }
    }
}
