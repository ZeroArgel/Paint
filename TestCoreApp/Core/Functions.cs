namespace TestCoreApp.Core
{
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    public static class Functions
    {
        #region Xml
        #region GetConfigXml
        /// <summary>
        /// Get from file 'Config.xml' all configuration.
        /// </summary>
        /// <returns></returns>
        public static ActionModel GetConfigXml()
        {
            var doc = new XmlDocument();
            doc.Load("Config.xml");
            
            var jsonXml = JsonConvert.DeserializeObject<XmlModel>(JsonConvert.SerializeXmlNode(doc));
            var user = jsonXml.Config.UserConfig;
            var system = jsonXml.Config.SystemConfig;
            var colorSelected = new ColorSelected()
            {
                RedColor = system.ColorSelected.RedColor,
                BlueColor = system.ColorSelected.BlueColor,
                GreenColor = system.ColorSelected.GreenColor
            };
            var colorPositionCurrent = new ColorPositionCurrent()
            {
                RedColor = system.ColorPositionCurrent.RedColor,
                BlueColor = system.ColorPositionCurrent.BlueColor,
                GreenColor = system.ColorPositionCurrent.GreenColor
            };
            var colorPosition = new ColorPosition()
            {
                RedColor = system.ColorPosition.RedColor,
                BlueColor = system.ColorPosition.BlueColor,
                GreenColor = system.ColorPosition.GreenColor
            };
            var colorBlank = new ColorBlank()
            {
                RedColor = system.ColorBlank.RedColor,
                BlueColor = system.ColorBlank.BlueColor,
                GreenColor = system.ColorBlank.GreenColor
            };
            var actionModel = new ActionModel()
            {
                PosX = user.PosX.ToInt(),
                PosY = user.PosY.ToInt(),
                Data = user.DataSave.ToDecode(),
                PosXMax = system.PosXMax.ToInt(),
                PosYMax = system.PosYMax.ToInt(),
                ColorPositionCurrent = colorPositionCurrent.ToColor(),
                ColorSelected = colorSelected.ToColor(),
                ColorBlank = colorBlank.ToColor(),
                ColorPosition = colorPosition.ToColor(),
                ColorReady = colorPositionCurrent.ToColor() == colorSelected.ToColor(),
                Move = false,
                Name = user.PosX.ToInt().ToFormatTxtName(user.PosY.ToInt())
            };
            return actionModel;
        }
        #endregion
        #region UpdConfigXml
        /// <summary>
        /// Save all data into file Config.xml to last time that open game.
        /// </summary>
        /// <param name="_actionModel">One model with all param of panel</param>
        public static void UpdConfigXml(ActionModel _actionModel)
        {
            var doc = new XmlDocument();
            doc.Load("Config.xml");
            var root = doc.DocumentElement;
            var userConfig = root.SelectSingleNode("descendant::UserConfig");
            var systemConfig = root.SelectSingleNode("descendant::SystemConfig");
            var posX = userConfig.SelectSingleNode("descendant::PosX");
            var posY = userConfig.SelectSingleNode("descendant::PosY");
            var dataSave = userConfig.SelectSingleNode("descendant::DataSave");
            var posXMax = systemConfig.SelectSingleNode("descendant::PosXMax");
            var posYMax = systemConfig.SelectSingleNode("descendant::PosYMax");
            posX.InnerText = _actionModel.PosX.ToString();
            posY.InnerText = _actionModel.PosY.ToString();
            dataSave.InnerText = _actionModel.Data.ToEncode();
            posXMax.InnerText = _actionModel.PosXMax.ToString();
            posYMax.InnerText = _actionModel.PosYMax.ToString();
            doc.Save("Config.xml");
        }
        #endregion
        #endregion
        #region Methods
        #region ToPanel
        #region SetPanel
        /// <summary>
        /// Draw all panel with param of Config.xml file
        /// </summary>
        /// <param name="_gbx">Panel 'Gbx_Paint' Object</param>
        /// <param name="_actionModel">All configuration of system</param>
        /// <returns></returns>
        public static GroupBox SetPanel(this GroupBox _gbx, ActionModel _actionModel)
        {
            _gbx.Controls.Clear(); // Clean before to create new boxs.
            var xInit = 1;
            var yInitCurrent = 0;
            var xIncrement = 9;
            var yIncrement = 9;
            for (int posY = 0; posY <= _actionModel.PosYMax; posY++)
            {
                yInitCurrent += yIncrement;
                for (int posX = 0; posX <= _actionModel.PosXMax; posX++)
                {
                    var xInitCurrent = ((posX + 1) * xIncrement) + xInit;
                    _gbx.Controls.Add(TextBoxToPanel(new Point(xInitCurrent, yInitCurrent), posX, posY));
                }
            }
            return _gbx;
        }
        #endregion
        #region TextBoxToPanel
        /// <summary>
        /// function to separete process of SetPanel Function. 
        /// </summary>
        /// <param name="_point">Point into Panel 'Gbx_Paint' to draw</param>
        /// <param name="posX">Position in X</param>
        /// <param name="posY">Position in Y</param>
        /// <returns></returns>
        private static TextBox TextBoxToPanel(Point _point, int posX, int posY)
        {
            return new TextBox()
            {
                Enabled = false,
                Multiline = true,
                Location = _point,
                Name = "Txt_" + posY + "_" + posX,
                ReadOnly = true,
                Size = new Size(10, 10)
            };
        }
        #endregion
        #region SetInitPanel
        /// <summary>
        /// Function to draw in white all field in panel.
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_actionModel"></param>
        public static void SetInitPanel(this Control _parent, ActionModel _actionModel)
        {
            for (int posY = 0; posY <= _actionModel.PosYMax; posY++)
            {
                for (int posX = 0; posX <= _actionModel.PosXMax; posX++)
                {
                    _parent.ToSetColorInTextBox(posX, posY, Color.White);
                    _parent.ToSetTextInTextBox(posX, posY, "");
                }
            }
        }
        #endregion
        #region SetDataSavePanel
        /// <summary>
        /// Function to set and draw all data saved beforely.
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_actionModel"></param>
        public static void SetDataSavePanel(this Control _parent, ActionModel _actionModel)
        {
            var listDataJson = JsonConvert.DeserializeObject<List<DataSaved>>(_actionModel.Data);
            foreach(var l in listDataJson)
            {
                if (l.ColorSelected != _actionModel.ColorPosition)
                {
                    _parent.ToSetColorInTextBox(l.PosX, l.PosY, l.ColorSelected);
                    _parent.ToSetTextInTextBox(l.PosX, l.PosY, " ");
                }
            }
        }
        #endregion
        #region GetDataSavePanel
        public static string GetDataSavePanel(this Control _parent, ActionModel _actionModel)
        {
            var listDataJson = new List<DataSaved>();
            for (int posY = 0; posY <= _actionModel.PosYMax; posY++)
            {
                for (int posX = 0; posX <= _actionModel.PosXMax; posX++)
                {
                    var nameCurrent = "Txt_" + posY + "_" + posX;
                    var colorCurrent = _parent.FindColorCurrent(nameCurrent);
                    if (colorCurrent != Color.White)
                    {
                        var dataSaved = new DataSaved()
                        {
                            PosX = posX,
                            PosY = posY,
                            ColorSelected = colorCurrent,
                            Name = nameCurrent
                        };
                        listDataJson.Add(dataSaved);
                    }
                }
            }
            return JsonConvert.SerializeObject(listDataJson);
        }
        #endregion
        #region ToSetColorInTextBox
        /// <summary>
        /// Function to set backcolor in a Textbox.
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="_color"></param>
        public static void ToSetColorInTextBox(this Control _parent, int posX, int posY, Color _color) => ((TextBox)_parent.FindControl("Txt_" + posY + "_" + posX)).BackColor = _color;
        #endregion
        #region ToSetTextInTextBox
        /// <summary>
        /// Function to set Text in a Textbox.
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="_color"></param>
        public static void ToSetTextInTextBox(this Control _parent, int posX, int posY, string _text) => ((TextBox)_parent.FindControl("Txt_" + posY + "_" + posX)).Text = _text;
        #endregion
        #endregion
        #region FindControl
        /// <summary>
        /// Function to find object with ID Name
        /// </summary>
        /// <param name="_parent">Object Txt_Ctl</param>
        /// <param name="ctlName">Name of object into 'Gbx_Paint' to search</param>
        /// <returns></returns>
        public static Control FindControl(this Control _parent, string ctlName)
        {
            if (_parent.Name == "Frm_Paint") return _parent.Controls.Find("Gbx_Paint", false)[0];
            if (_parent.Name == "Gbx_Paint") return _parent.Controls.Find(ctlName, false)[0];
            var gbx = _parent.Controls.Find("Gbx_Paint", true);
            var txt = gbx[0].Controls.Find(ctlName, false);
            if (txt.Length == 1) return txt[0];
            return null;
        }
        #endregion
        #region PosByKeyCurrent
        /// <summary>
        /// Function to find position current by key pressed
        /// </summary>
        /// <param name="_e">Key Event of keyboard</param>
        /// <param name="_actionModel">Object with position current</param>
        /// <returns></returns>
        public static ActionModel PosByKeyCurrent(this KeyEventArgs _e, ActionModel _actionModel)
        {
            var valueX = _actionModel.PosX;
            var valueY = _actionModel.PosY;
            var valueMove = false;
            var ColorReady = false;
            switch (_e.KeyCode)
            {
                case Keys.Up: 
                    valueY = _actionModel.PosY == 0 ? _actionModel.PosY : _actionModel.PosY-1;
                    valueMove = valueY != _actionModel.PosY;
                    break;
                case Keys.Down: 
                    valueY = _actionModel.PosY < _actionModel.PosYMax ? _actionModel.PosY+1 : _actionModel.PosY;
                    valueMove = valueY != _actionModel.PosY;
                    break;
                case Keys.Left: 
                    valueX = _actionModel.PosX == 0 ? _actionModel.PosX : _actionModel.PosX-1;
                    valueMove = valueX != _actionModel.PosX;
                    break;
                case Keys.Right: 
                    valueX = _actionModel.PosX < _actionModel.PosXMax ? _actionModel.PosX+1 : _actionModel.PosX;
                    valueMove = valueX != _actionModel.PosX;
                    break;
                case Keys.M:
                    ColorReady = true;
                    break;
                default: break;
            }
            _actionModel.PosX = valueX;
            _actionModel.PosY = valueY;
            _actionModel.Name = _actionModel.GetNameTxt();
            _actionModel.Move = valueMove;
            _actionModel.ColorReady = ColorReady;
            _actionModel.ColorPositionCurrent = _actionModel.ColorPosition;
            if (ColorReady) _actionModel.ColorPositionCurrent = _actionModel.ColorSelected;
            return _actionModel;
        }
        #endregion
        #region FindColorCurrent
        /// <summary>
        /// Function to find of color currently
        /// </summary>
        /// <param name="_parent"></param>
        /// <param name="_actionModel"></param>
        /// <returns>Color</returns>
        public static Color FindColorCurrent(this Control _parent, string _name)
        {
            if (_parent.Name == "Gbx_Paint") return _parent.Controls.Find(_name, false)[0].BackColor;
            return _parent.Controls.Find("Gbx_Paint", true)[0].Controls.Find(_name, false)[0].BackColor;
        }
        #endregion
        #region GetNameTxt
        /// <summary>
        /// Return name in format of TextBox.
        /// </summary>
        /// <param name="_actionModel"></param>
        /// <returns></returns>
        public static string GetNameTxt(this ActionModel _actionModel) => "Txt_" + _actionModel.PosY + "_" + _actionModel.PosX;
        #endregion
        #endregion
        #region extentionMethods to one life more easy.
        public static string ToFormatTxtName(this int posX, int posY) => "Txt_" + posY + "_" + posX;
        public static int ToInt(this string _value) => Convert.ToInt32(_value);
        public static int ToInt(this decimal _value) => Convert.ToInt32(_value);
        public static Color ToColor(this ColorPositionCurrent _model) => Color.FromArgb(_model.RedColor.ToInt(), _model.GreenColor.ToInt(), _model.BlueColor.ToInt());
        public static Color ToColor(this ColorSelected _model) => Color.FromArgb(_model.RedColor.ToInt(), _model.GreenColor.ToInt(), _model.BlueColor.ToInt());
        public static Color ToColor(this ColorBlank _model) => Color.FromArgb(_model.RedColor.ToInt(), _model.GreenColor.ToInt(), _model.BlueColor.ToInt());
        public static Color ToColor(this ColorPosition _model) => Color.FromArgb(_model.RedColor.ToInt(), _model.GreenColor.ToInt(), _model.BlueColor.ToInt());
        public static string ToEncode(this string _str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(_str));
        public static string ToDecode(this string _strBase64) => Encoding.UTF8.GetString(Convert.FromBase64String(_strBase64));
        #endregion
    }
}