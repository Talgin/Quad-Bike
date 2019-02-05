namespace com_port
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btC = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btD = new System.Windows.Forms.Button();
            this.btCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.imgTop = new System.Windows.Forms.PictureBox();
            this.imgRight = new System.Windows.Forms.PictureBox();
            this.imgLeft = new System.Windows.Forms.PictureBox();
            this.imgBottom = new System.Windows.Forms.PictureBox();
            this.joystickTimer = new System.Windows.Forms.Timer(this.components);
            this.outputWindow = new System.Windows.Forms.RichTextBox();
            this.wbPlatformCam = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.imgTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // btC
            // 
            this.btC.Location = new System.Drawing.Point(163, 73);
            this.btC.Name = "btC";
            this.btC.Size = new System.Drawing.Size(75, 21);
            this.btC.TabIndex = 1;
            this.btC.Text = "Connect";
            this.btC.UseVisualStyleBackColor = true;
            this.btC.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(49, 153);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 13);
            this.Label1.TabIndex = 4;
            // 
            // btD
            // 
            this.btD.Location = new System.Drawing.Point(260, 73);
            this.btD.Name = "btD";
            this.btD.Size = new System.Drawing.Size(69, 21);
            this.btD.TabIndex = 5;
            this.btD.Text = "Disconnect";
            this.btD.UseVisualStyleBackColor = true;
            this.btD.Click += new System.EventHandler(this.btD_Click);
            // 
            // btCheck
            // 
            this.btCheck.Location = new System.Drawing.Point(163, 41);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(165, 21);
            this.btCheck.TabIndex = 6;
            this.btCheck.Text = "Check Ports";
            this.btCheck.UseVisualStyleBackColor = true;
            this.btCheck.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Disconnect";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.comboBox2.Location = new System.Drawing.Point(19, 73);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // imgTop
            // 
            this.imgTop.ErrorImage = global::com_port.Properties.Resources.top_down;
            this.imgTop.Image = global::com_port.Properties.Resources.top_down;
            this.imgTop.InitialImage = global::com_port.Properties.Resources.top_down;
            this.imgTop.Location = new System.Drawing.Point(153, 111);
            this.imgTop.Name = "imgTop";
            this.imgTop.Size = new System.Drawing.Size(58, 57);
            this.imgTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgTop.TabIndex = 14;
            this.imgTop.TabStop = false;
            // 
            // imgRight
            // 
            this.imgRight.Image = global::com_port.Properties.Resources.right_down;
            this.imgRight.Location = new System.Drawing.Point(216, 174);
            this.imgRight.Name = "imgRight";
            this.imgRight.Size = new System.Drawing.Size(56, 58);
            this.imgRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRight.TabIndex = 13;
            this.imgRight.TabStop = false;
            // 
            // imgLeft
            // 
            this.imgLeft.Image = global::com_port.Properties.Resources.left_down;
            this.imgLeft.Location = new System.Drawing.Point(89, 174);
            this.imgLeft.Name = "imgLeft";
            this.imgLeft.Size = new System.Drawing.Size(58, 57);
            this.imgLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLeft.TabIndex = 11;
            this.imgLeft.TabStop = false;
            // 
            // imgBottom
            // 
            this.imgBottom.Image = global::com_port.Properties.Resources.bottom_down;
            this.imgBottom.Location = new System.Drawing.Point(153, 174);
            this.imgBottom.Name = "imgBottom";
            this.imgBottom.Size = new System.Drawing.Size(56, 57);
            this.imgBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgBottom.TabIndex = 12;
            this.imgBottom.TabStop = false;
            // 
            // joystickTimer
            // 
            //this.joystickTimer.Tick += new System.EventHandler(this.joystickTimer_Tick);
            // 
            // outputWindow
            // 
            this.outputWindow.Location = new System.Drawing.Point(785, 12);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.Size = new System.Drawing.Size(108, 305);
            this.outputWindow.TabIndex = 16;
            this.outputWindow.Text = "";
            // 
            // wbPlatformCam
            // 
            this.wbPlatformCam.Location = new System.Drawing.Point(335, 12);
            this.wbPlatformCam.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPlatformCam.Name = "wbPlatformCam";
            this.wbPlatformCam.Size = new System.Drawing.Size(444, 305);
            this.wbPlatformCam.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 329);
            this.Controls.Add(this.wbPlatformCam);
            this.Controls.Add(this.outputWindow);
            this.Controls.Add(this.imgTop);
            this.Controls.Add(this.imgRight);
            this.Controls.Add(this.imgLeft);
            this.Controls.Add(this.imgBottom);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCheck);
            this.Controls.Add(this.btD);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btC);
            this.Name = "Form1";
            this.Text = "CamDevice";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBottom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btC;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btD;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.PictureBox imgTop;
        private System.Windows.Forms.PictureBox imgRight;
        private System.Windows.Forms.PictureBox imgLeft;
        private System.Windows.Forms.PictureBox imgBottom;
        private System.Windows.Forms.Timer joystickTimer;
        private System.Windows.Forms.RichTextBox outputWindow;
        private System.Windows.Forms.WebBrowser wbPlatformCam;


    }
}

