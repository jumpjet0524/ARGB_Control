using System.Drawing;
using System.Windows.Forms;
using System;

namespace ArduinoLEDControl
{
    partial class Form1
        {
            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            private void InitializeComponent()
            {
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.trkRed = new System.Windows.Forms.TrackBar();
            this.trkGreen = new System.Windows.Forms.TrackBar();
            this.trkBlue = new System.Windows.Forms.TrackBar();
            this.update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpConnection.SuspendLayout();
            this.grpMode.SuspendLayout();
            this.grpColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.btnRefresh);
            this.grpConnection.Controls.Add(this.cmbPort);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Location = new System.Drawing.Point(18, 18);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(4);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(4);
            this.grpConnection.Size = new System.Drawing.Size(390, 120);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "串口連接";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(262, 30);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 34);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(22, 30);
            this.cmbPort.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(229, 26);
            this.cmbPort.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(22, 75);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(352, 34);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "連接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpMode
            // 
            this.grpMode.Controls.Add(this.cmbMode);
            this.grpMode.Location = new System.Drawing.Point(18, 150);
            this.grpMode.Margin = new System.Windows.Forms.Padding(4);
            this.grpMode.Name = "grpMode";
            this.grpMode.Padding = new System.Windows.Forms.Padding(4);
            this.grpMode.Size = new System.Drawing.Size(390, 75);
            this.grpMode.TabIndex = 1;
            this.grpMode.TabStop = false;
            this.grpMode.Text = "模式選擇";
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Location = new System.Drawing.Point(7, 29);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(244, 26);
            this.cmbMode.TabIndex = 3;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.update);
            this.grpColor.Controls.Add(this.label3);
            this.grpColor.Controls.Add(this.pnlColor);
            this.grpColor.Controls.Add(this.label2);
            this.grpColor.Controls.Add(this.trkRed);
            this.grpColor.Controls.Add(this.label1);
            this.grpColor.Controls.Add(this.trkGreen);
            this.grpColor.Controls.Add(this.trkBlue);
            this.grpColor.Location = new System.Drawing.Point(18, 240);
            this.grpColor.Margin = new System.Windows.Forms.Padding(4);
            this.grpColor.Name = "grpColor";
            this.grpColor.Padding = new System.Windows.Forms.Padding(4);
            this.grpColor.Size = new System.Drawing.Size(390, 271);
            this.grpColor.TabIndex = 2;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "顏色選擇";
            // 
            // pnlColor
            // 
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Location = new System.Drawing.Point(300, 31);
            this.pnlColor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(74, 74);
            this.pnlColor.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(498, 75);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(396, 196);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // trkRed
            // 
            this.trkRed.Location = new System.Drawing.Point(54, 31);
            this.trkRed.Maximum = 100;
            this.trkRed.Name = "trkRed";
            this.trkRed.Size = new System.Drawing.Size(222, 69);
            this.trkRed.TabIndex = 4;
            this.trkRed.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // trkGreen
            // 
            this.trkGreen.Location = new System.Drawing.Point(54, 104);
            this.trkGreen.Maximum = 100;
            this.trkGreen.Name = "trkGreen";
            this.trkGreen.Size = new System.Drawing.Size(222, 69);
            this.trkGreen.TabIndex = 5;
            this.trkGreen.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // trkBlue
            // 
            this.trkBlue.Location = new System.Drawing.Point(54, 177);
            this.trkBlue.Maximum = 100;
            this.trkBlue.Name = "trkBlue";
            this.trkBlue.Size = new System.Drawing.Size(222, 69);
            this.trkBlue.TabIndex = 6;
            this.trkBlue.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(301, 133);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(73, 76);
            this.update.TabIndex = 7;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(13, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(13, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "B";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 531);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.grpMode);
            this.Controls.Add(this.grpConnection);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "LED 控制器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.grpConnection.ResumeLayout(false);
            this.grpMode.ResumeLayout(false);
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBlue)).EndInit();
            this.ResumeLayout(false);

            }

            #endregion

            private GroupBox grpConnection;
            private Button btnRefresh;
            private ComboBox cmbPort;
            private Button btnConnect;
            private GroupBox grpMode;
            private GroupBox grpColor;
            private Panel pnlColor;
        private RichTextBox richTextBox1;
        private ComboBox cmbMode;
        private TrackBar trkRed;
        private TrackBar trkGreen;
        private TrackBar trkBlue;
        private Button update;
        private Label label3;
        private Label label2;
        private Label label1;
    }
    }