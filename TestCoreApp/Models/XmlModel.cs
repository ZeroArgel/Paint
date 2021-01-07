namespace TestCoreApp.Models
{
    public class XmlModel 
    {
        public Config Config { get; set; }
    }
    public class Config
    {
        public UserConfig UserConfig { get; set; }
        public SystemConfig SystemConfig { get; set; }
    }
    public class UserConfig
    {
        public string PosX { get; set; }
        public string PosY { get; set; }
        public string DataSave { get; set; }
    }
    public class SystemConfig
    {
        public string PosXMax { get; set; }
        public string PosYMax { get; set; }
        public ColorSelected ColorSelected { get; set; }
        public ColorPositionCurrent ColorPositionCurrent { get; set; }
        public ColorPosition ColorPosition { get; set; }
        public ColorBlank ColorBlank { get; set; }
    }
}