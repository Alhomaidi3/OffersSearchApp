using System.Windows.Forms;

namespace OffersSearchApp
{
    partial class FormLogs
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogs));
            txtLogs = new TextBox();
            panelTitle = new Panel();
            lblTitle = new Label();
            mainLayout = new TableLayoutPanel();
            panelTitle.SuspendLayout();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // txtLogs
            // 
            txtLogs.Dock = DockStyle.Fill;
            txtLogs.Location = new Point(23, 61);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = ScrollBars.Vertical;
            txtLogs.Size = new Size(538, 482);
            txtLogs.TabIndex = 0;
            txtLogs.WordWrap = false;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.AliceBlue;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Dock = DockStyle.Fill;
            panelTitle.Location = new Point(23, 15);
            panelTitle.Margin = new Padding(3, 0, 3, 3);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(538, 40);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(9, -1);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📄 Activity Logs";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainLayout
            // 
            mainLayout.BackColor = Color.AliceBlue;
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainLayout.Controls.Add(panelTitle, 0, 0);
            mainLayout.Controls.Add(txtLogs, 0, 1);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(20, 15, 20, 15);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainLayout.Size = new Size(584, 561);
            mainLayout.TabIndex = 0;
            // 
            // FormLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 561);
            Controls.Add(mainLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activity Logs";
            Load += FormLogs_Load;
            panelTitle.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ResumeLayout(false);


        }
        private TextBox txtLogs;
        private Panel panelTitle;
        private Label lblTitle;
        private TableLayoutPanel mainLayout;
    }
}
