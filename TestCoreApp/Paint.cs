namespace TestCoreApp
{
    using Core;
    using Models;
    using System;
    using System.Windows.Forms;
    public partial class Frm_Paint : Form
    {
        private ActionModel ActionCurrent_;
        public Frm_Paint() => InitializeComponent();
        private void Frm_Paint_Load(object sender, EventArgs e)
        {
            ActionCurrent_ = Functions.GetConfigXml(); // Get all data.
            FrmInitSquare(ActionCurrent_); // Draw all panel.
            Reset();
            FrmRecoverDataSave(ActionCurrent_); // Draw all data saved.
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            ActionCurrent_.Data = this.GetDataSavePanel(ActionCurrent_);
            ActionCurrent_.PosXMax = Txt_MaxX.Value.ToInt();
            ActionCurrent_.PosYMax = Txt_MaxY.Value.ToInt();
            Functions.UpdConfigXml(ActionCurrent_);
            MessageBox.Show("Saved");
            Txt_Ctrl.Focus();
        }
        private void Btn_Clean_Click(object sender, EventArgs e) => Reset();
        private void Btn_Load_Click(object sender, EventArgs e)
        {
            ActionCurrent_ = Functions.GetConfigXml(); // Get all data.
            FrmInitSquare(ActionCurrent_); // Draw all panel.
            Reset();
            FrmRecoverDataSave(ActionCurrent_); // Draw all data saved.
        }
        private void Txt_Ctrl_KeyDown(object sender, KeyEventArgs e) => TaskSelected(sender, e);
        private void Frm_Paint_Click(object sender, EventArgs e) => Txt_Ctrl.Focus();
        private void FrmInitSquare(ActionModel _actionModel) => Gbx_Paint = Gbx_Paint.SetPanel(_actionModel);
        private void FrmRecoverDataSave(ActionModel _actionModel) => Gbx_Paint.SetDataSavePanel(_actionModel);
        private void ShowPos(ActionModel _actionModel)
        {
            Txt_MaxX.Text = _actionModel.PosXMax.ToString();
            Txt_MaxY.Text = _actionModel.PosYMax.ToString();
        }
        private void TaskSelected(object sender, KeyEventArgs e)
        {
            var gbx = this.FindControl("Frm_Paint");
            var ActionBefore = new ActionModel(ActionCurrent_);
            var ActionCurrent = e.PosByKeyCurrent(ActionCurrent_);
            ActionBefore.Name = ActionBefore.GetNameTxt();

            var txtCurrent = (TextBox)gbx.FindControl(ActionCurrent_.Name);
            var txtBefore = (TextBox)gbx.FindControl(ActionBefore.Name);
            if (ActionCurrent.Move)
            {
                if(txtCurrent.Text != " ") txtCurrent.BackColor = ActionCurrent_.ColorPositionCurrent;
                else txtCurrent.BackColor = ActionCurrent_.ColorSelected;
                txtBefore.BackColor = ActionBefore.ColorPositionCurrent;
                ShowPos(ActionCurrent_);
            }
            if (ActionBefore.ColorReady || txtBefore.Text == " ")
            {
                txtBefore.Text = " ";
                txtBefore.BackColor = ActionBefore.ColorSelected;
            }
        }
        private void Reset()
        {
            var gbx = this.FindControl("Frm_Paint");
            gbx.SetInitPanel(ActionCurrent_); // White all panel.
            ((TextBox)gbx.FindControl(ActionCurrent_.Name)).BackColor = ActionCurrent_.ColorPositionCurrent; // Set current point.
            ShowPos(ActionCurrent_);
            Txt_Ctrl.Focus();
        }
    }
}