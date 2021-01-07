namespace TestCoreApp.Models
{
    using System.Drawing;
    public class ActionModel
    {
        public ActionModel() { }
        public ActionModel(ActionModel _actionModel)
        {
            PosX = _actionModel.PosX;
            PosY = _actionModel.PosY;
            Data = _actionModel.Data;
            PosXMax = _actionModel.PosXMax;
            PosYMax = _actionModel.PosYMax;
            Move = false;
            ColorReady = _actionModel.ColorReady;
            ColorPositionCurrent = Color.White;
            ColorSelected = Color.Black;
        }
        public string Name { get; set; }
        public string Data { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int PosXMax { get; set; }
        public int PosYMax { get; set; }
        public bool Move { get; set; }
        public bool ColorReady { get; set; }
        public Color ColorPositionCurrent { get; set; }
        public Color ColorPosition { get; set; }
        public Color ColorSelected { get; set; }
        public Color ColorBlank { get; set; }
    }
}