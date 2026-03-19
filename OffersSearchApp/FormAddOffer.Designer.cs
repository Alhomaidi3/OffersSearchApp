using System;
using System.Drawing;
using System.Windows.Forms;

namespace OffersSearchApp
{
    partial class FormAddOffer : Form
    {
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            mainFlow = new FlowLayoutPanel();
            row1 = new FlowLayoutPanel();
            panel_ProductName = new Panel();
            tbProductName = new TextBox();
            lbl_ProductName = new Label();
            panel_SupplierName = new Panel();
            tbSupplierName = new TextBox();
            lbl_SupplierName = new Label();
            row2 = new FlowLayoutPanel();
            panel_Contact = new Panel();
            tbContact = new TextBox();
            lbl_Contact = new Label();
            panel_Country = new Panel();
            tbCountry = new TextBox();
            lbl_Country = new Label();
            row3 = new FlowLayoutPanel();
            panel_Quantity = new Panel();
            tbQuantity = new TextBox();
            lbl_Quantity = new Label();
            panel_Price = new Panel();
            tbPrice = new TextBox();
            lbl_Price = new Label();
            row4 = new FlowLayoutPanel();
            panel_Material = new Panel();
            tbMaterial = new TextBox();
            lbl_Material = new Label();
            panel_Size = new Panel();
            tbSize = new TextBox();
            lbl_Size = new Label();
            row5 = new FlowLayoutPanel();
            panel_Type = new Panel();
            tbType = new TextBox();
            lbl_Type = new Label();
            panel_Quarter = new Panel();
            tbQuarter = new TextBox();
            lbl_Quarter = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            mainFlow.SuspendLayout();
            row1.SuspendLayout();
            panel_ProductName.SuspendLayout();
            panel_SupplierName.SuspendLayout();
            row2.SuspendLayout();
            panel_Contact.SuspendLayout();
            panel_Country.SuspendLayout();
            row3.SuspendLayout();
            panel_Quantity.SuspendLayout();
            panel_Price.SuspendLayout();
            row4.SuspendLayout();
            panel_Material.SuspendLayout();
            panel_Size.SuspendLayout();
            row5.SuspendLayout();
            panel_Type.SuspendLayout();
            panel_Quarter.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // mainFlow
            // 
            mainFlow.AutoSize = true;
            mainFlow.BackColor = Color.AliceBlue;
            mainFlow.Controls.Add(row1);
            mainFlow.Controls.Add(row2);
            mainFlow.Controls.Add(row3);
            mainFlow.Controls.Add(row4);
            mainFlow.Controls.Add(row5);
            mainFlow.Controls.Add(panel2);
            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.Location = new Point(0, 0);
            mainFlow.Name = "mainFlow";
            mainFlow.Padding = new Padding(10);
            mainFlow.Size = new Size(1856, 458);
            mainFlow.TabIndex = 0;
            mainFlow.WrapContents = false;
            // 
            // row1
            // 
            row1.AutoSize = true;
            row1.Controls.Add(panel_ProductName);
            row1.Controls.Add(panel_SupplierName);
            row1.Location = new Point(13, 13);
            row1.Name = "row1";
            row1.Size = new Size(912, 66);
            row1.TabIndex = 0;
            // 
            // panel_ProductName
            // 
            panel_ProductName.Controls.Add(tbProductName);
            panel_ProductName.Controls.Add(lbl_ProductName);
            panel_ProductName.Location = new Point(3, 3);
            panel_ProductName.Name = "panel_ProductName";
            panel_ProductName.Size = new Size(450, 60);
            panel_ProductName.TabIndex = 0;
            // 
            // tbProductName
            // 
            tbProductName.Location = new Point(0, 25);
            tbProductName.Name = "tbProductName";
            tbProductName.Size = new Size(450, 23);
            tbProductName.TabIndex = 1;
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_ProductName.Location = new Point(0, 0);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new Size(450, 20);
            lbl_ProductName.TabIndex = 0;
            lbl_ProductName.Text = "Product Name";
            lbl_ProductName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_SupplierName
            // 
            panel_SupplierName.Controls.Add(tbSupplierName);
            panel_SupplierName.Controls.Add(lbl_SupplierName);
            panel_SupplierName.Location = new Point(459, 3);
            panel_SupplierName.Name = "panel_SupplierName";
            panel_SupplierName.Size = new Size(450, 60);
            panel_SupplierName.TabIndex = 1;
            // 
            // tbSupplierName
            // 
            tbSupplierName.Location = new Point(0, 25);
            tbSupplierName.Name = "tbSupplierName";
            tbSupplierName.Size = new Size(450, 23);
            tbSupplierName.TabIndex = 1;
            // 
            // lbl_SupplierName
            // 
            lbl_SupplierName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_SupplierName.Location = new Point(0, 0);
            lbl_SupplierName.Name = "lbl_SupplierName";
            lbl_SupplierName.Size = new Size(450, 20);
            lbl_SupplierName.TabIndex = 0;
            lbl_SupplierName.Text = "Supplier Name";
            lbl_SupplierName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // row2
            // 
            row2.AutoSize = true;
            row2.Controls.Add(panel_Contact);
            row2.Controls.Add(panel_Country);
            row2.Location = new Point(13, 85);
            row2.Name = "row2";
            row2.Size = new Size(912, 66);
            row2.TabIndex = 1;
            // 
            // panel_Contact
            // 
            panel_Contact.Controls.Add(tbContact);
            panel_Contact.Controls.Add(lbl_Contact);
            panel_Contact.Location = new Point(3, 3);
            panel_Contact.Name = "panel_Contact";
            panel_Contact.Size = new Size(450, 60);
            panel_Contact.TabIndex = 0;
            // 
            // tbContact
            // 
            tbContact.Location = new Point(0, 25);
            tbContact.Name = "tbContact";
            tbContact.Size = new Size(450, 23);
            tbContact.TabIndex = 1;
            // 
            // lbl_Contact
            // 
            lbl_Contact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Contact.Location = new Point(0, 0);
            lbl_Contact.Name = "lbl_Contact";
            lbl_Contact.Size = new Size(450, 20);
            lbl_Contact.TabIndex = 0;
            lbl_Contact.Text = "Contact";
            lbl_Contact.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Country
            // 
            panel_Country.Controls.Add(tbCountry);
            panel_Country.Controls.Add(lbl_Country);
            panel_Country.Location = new Point(459, 3);
            panel_Country.Name = "panel_Country";
            panel_Country.Size = new Size(450, 60);
            panel_Country.TabIndex = 1;
            // 
            // tbCountry
            // 
            tbCountry.Location = new Point(0, 25);
            tbCountry.Name = "tbCountry";
            tbCountry.Size = new Size(450, 23);
            tbCountry.TabIndex = 1;
            // 
            // lbl_Country
            // 
            lbl_Country.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Country.Location = new Point(0, 0);
            lbl_Country.Name = "lbl_Country";
            lbl_Country.Size = new Size(450, 20);
            lbl_Country.TabIndex = 0;
            lbl_Country.Text = "Country";
            lbl_Country.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // row3
            // 
            row3.AutoSize = true;
            row3.Controls.Add(panel_Quantity);
            row3.Controls.Add(panel_Price);
            row3.Location = new Point(13, 157);
            row3.Name = "row3";
            row3.Size = new Size(912, 66);
            row3.TabIndex = 2;
            // 
            // panel_Quantity
            // 
            panel_Quantity.Controls.Add(tbQuantity);
            panel_Quantity.Controls.Add(lbl_Quantity);
            panel_Quantity.Location = new Point(3, 3);
            panel_Quantity.Name = "panel_Quantity";
            panel_Quantity.Size = new Size(450, 60);
            panel_Quantity.TabIndex = 0;
            // 
            // tbQuantity
            // 
            tbQuantity.Location = new Point(0, 25);
            tbQuantity.Name = "tbQuantity";
            tbQuantity.Size = new Size(450, 23);
            tbQuantity.TabIndex = 1;
            // 
            // lbl_Quantity
            // 
            lbl_Quantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Quantity.Location = new Point(0, 0);
            lbl_Quantity.Name = "lbl_Quantity";
            lbl_Quantity.Size = new Size(450, 20);
            lbl_Quantity.TabIndex = 0;
            lbl_Quantity.Text = "Quantity";
            lbl_Quantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Price
            // 
            panel_Price.Controls.Add(tbPrice);
            panel_Price.Controls.Add(lbl_Price);
            panel_Price.Location = new Point(459, 3);
            panel_Price.Name = "panel_Price";
            panel_Price.Size = new Size(450, 60);
            panel_Price.TabIndex = 1;
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(0, 25);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(450, 23);
            tbPrice.TabIndex = 1;
            // 
            // lbl_Price
            // 
            lbl_Price.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Price.Location = new Point(0, 0);
            lbl_Price.Name = "lbl_Price";
            lbl_Price.Size = new Size(450, 20);
            lbl_Price.TabIndex = 0;
            lbl_Price.Text = "Price";
            lbl_Price.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // row4
            // 
            row4.AutoSize = true;
            row4.Controls.Add(panel_Material);
            row4.Controls.Add(panel_Size);
            row4.Controls.Add(flowLayoutPanel1);
            row4.Location = new Point(13, 229);
            row4.Name = "row4";
            row4.Size = new Size(918, 66);
            row4.TabIndex = 3;
            // 
            // panel_Material
            // 
            panel_Material.Controls.Add(tbMaterial);
            panel_Material.Controls.Add(lbl_Material);
            panel_Material.Location = new Point(3, 3);
            panel_Material.Name = "panel_Material";
            panel_Material.Size = new Size(450, 60);
            panel_Material.TabIndex = 0;
            // 
            // tbMaterial
            // 
            tbMaterial.Location = new Point(0, 25);
            tbMaterial.Name = "tbMaterial";
            tbMaterial.Size = new Size(450, 23);
            tbMaterial.TabIndex = 1;
            // 
            // lbl_Material
            // 
            lbl_Material.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Material.Location = new Point(0, 0);
            lbl_Material.Name = "lbl_Material";
            lbl_Material.Size = new Size(450, 20);
            lbl_Material.TabIndex = 0;
            lbl_Material.Text = "Material";
            lbl_Material.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Size
            // 
            panel_Size.Controls.Add(tbSize);
            panel_Size.Controls.Add(lbl_Size);
            panel_Size.Location = new Point(459, 3);
            panel_Size.Name = "panel_Size";
            panel_Size.Size = new Size(450, 60);
            panel_Size.TabIndex = 1;
            // 
            // tbSize
            // 
            tbSize.Location = new Point(0, 25);
            tbSize.Name = "tbSize";
            tbSize.Size = new Size(450, 23);
            tbSize.TabIndex = 1;
            // 
            // lbl_Size
            // 
            lbl_Size.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Size.Location = new Point(0, 0);
            lbl_Size.Name = "lbl_Size";
            lbl_Size.Size = new Size(450, 20);
            lbl_Size.TabIndex = 0;
            lbl_Size.Text = "Size";
            lbl_Size.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // row5
            // 
            row5.AutoSize = true;
            row5.Controls.Add(panel_Type);
            row5.Controls.Add(panel_Quarter);
            row5.Location = new Point(13, 301);
            row5.Name = "row5";
            row5.Size = new Size(912, 66);
            row5.TabIndex = 4;
            // 
            // panel_Type
            // 
            panel_Type.Controls.Add(tbType);
            panel_Type.Controls.Add(lbl_Type);
            panel_Type.Location = new Point(3, 3);
            panel_Type.Name = "panel_Type";
            panel_Type.Size = new Size(450, 60);
            panel_Type.TabIndex = 0;
            // 
            // tbType
            // 
            tbType.Location = new Point(0, 25);
            tbType.Name = "tbType";
            tbType.Size = new Size(450, 23);
            tbType.TabIndex = 1;
            // 
            // lbl_Type
            // 
            lbl_Type.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Type.Location = new Point(0, 0);
            lbl_Type.Name = "lbl_Type";
            lbl_Type.Size = new Size(450, 20);
            lbl_Type.TabIndex = 0;
            lbl_Type.Text = "Type";
            lbl_Type.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Quarter
            // 
            panel_Quarter.Controls.Add(tbQuarter);
            panel_Quarter.Controls.Add(lbl_Quarter);
            panel_Quarter.Location = new Point(459, 3);
            panel_Quarter.Name = "panel_Quarter";
            panel_Quarter.Size = new Size(450, 60);
            panel_Quarter.TabIndex = 1;
            // 
            // tbQuarter
            // 
            tbQuarter.Location = new Point(0, 25);
            tbQuarter.Name = "tbQuarter";
            tbQuarter.Size = new Size(450, 23);
            tbQuarter.TabIndex = 1;
            // 
            // lbl_Quarter
            // 
            lbl_Quarter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Quarter.Location = new Point(0, 0);
            lbl_Quarter.Name = "lbl_Quarter";
            lbl_Quarter.Size = new Size(450, 20);
            lbl_Quarter.TabIndex = 0;
            lbl_Quarter.Text = "Quarter";
            lbl_Quarter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.BackColor = Color.SeaGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(443, 17);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(259, 17);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 30);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "✖ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Location = new Point(915, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(0, 0);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSave);
            panel2.Location = new Point(13, 373);
            panel2.Name = "panel2";
            panel2.Size = new Size(918, 60);
            panel2.TabIndex = 1;
            // 
            // FormAddOffer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 453);
            Controls.Add(mainFlow);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormAddOffer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Offer";
            mainFlow.ResumeLayout(false);
            mainFlow.PerformLayout();
            row1.ResumeLayout(false);
            panel_ProductName.ResumeLayout(false);
            panel_ProductName.PerformLayout();
            panel_SupplierName.ResumeLayout(false);
            panel_SupplierName.PerformLayout();
            row2.ResumeLayout(false);
            panel_Contact.ResumeLayout(false);
            panel_Contact.PerformLayout();
            panel_Country.ResumeLayout(false);
            panel_Country.PerformLayout();
            row3.ResumeLayout(false);
            panel_Quantity.ResumeLayout(false);
            panel_Quantity.PerformLayout();
            panel_Price.ResumeLayout(false);
            panel_Price.PerformLayout();
            row4.ResumeLayout(false);
            row4.PerformLayout();
            panel_Material.ResumeLayout(false);
            panel_Material.PerformLayout();
            panel_Size.ResumeLayout(false);
            panel_Size.PerformLayout();
            row5.ResumeLayout(false);
            panel_Type.ResumeLayout(false);
            panel_Type.PerformLayout();
            panel_Quarter.ResumeLayout(false);
            panel_Quarter.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel mainFlow;
        private FlowLayoutPanel row1;
        private FlowLayoutPanel row2;
        private FlowLayoutPanel row3;
        private FlowLayoutPanel row4;
        private FlowLayoutPanel row5;
        private Panel panel_ProductName;
        private Panel panel_SupplierName;
        private Panel panel_Contact;
        private Panel panel_Country;
        private Panel panel_Quantity;
        private Panel panel_Price;
        private Panel panel_Material;
        private Panel panel_Size;
        private Panel panel_Type;
        private Panel panel_Quarter;
        private TextBox tbProductName;
        private TextBox tbSupplierName;
        private TextBox tbContact;
        private TextBox tbCountry;
        private TextBox tbQuantity;
        private TextBox tbPrice;
        private TextBox tbMaterial;
        private TextBox tbSize;
        private TextBox tbType;
        private TextBox tbQuarter;
        private Button btnSave;
        private Button btnCancel;
        private Label lbl_ProductName;
        private Label lbl_SupplierName;
        private Label lbl_Contact;
        private Label lbl_Country;
        private Label lbl_Quantity;
        private Label lbl_Price;
        private Label lbl_Material;
        private Label lbl_Size;
        private Label lbl_Type;
        private Label lbl_Quarter;

        private void btnSave_Click(object sender, EventArgs e) { }
        private void btnCancel_Click(object sender, EventArgs e) { }
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
    }
}
