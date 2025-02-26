using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;


namespace ArduinoLEDControl
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private byte currentMode = 0;
        private Color currentColor = Color.White;
        private CancellationTokenSource cancelTokenSource;

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // 初始化串口相關控制項
            cmbPort.Items.AddRange(SerialPort.GetPortNames());
            if (cmbPort.Items.Count > 0) cmbPort.SelectedIndex = 0;

            // 初始化模式選擇 (使用 ComboBox)
            cmbMode.Items.AddRange(new string[] { "關閉", "彩虹模式", "跑馬燈", "隨機閃爍","靜態","呼吸燈"});

            // 初始化顏色顯示
            pnlColor.BackColor = currentColor;
        }

        // 串口連接/斷開按鈕
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                ConnectSerial();
            }
            else
            {
                DisconnectSerial();
            }
        }

        private void ConnectSerial()
        {
            try
            {
                serialPort = new SerialPort(
                    portName: cmbPort.Text,
                    baudRate: 9600,
                    parity: Parity.None,
                    dataBits: 8,
                    stopBits: StopBits.One);

                serialPort.DataReceived -= SerialPort_DataReceived;
                serialPort.DataReceived += SerialPort_DataReceived;

                serialPort.Open();
                UpdateConnectionState(true);

                // 連接後發送 GET_MODE 指令，由 DataReceived 處理回應
                serialPort.DiscardInBuffer();
                serialPort.WriteLine("GET_MODE");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"連接失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AppendLog(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new Action(() => richTextBox1.AppendText(text + Environment.NewLine)));
            }
            else
            {
                richTextBox1.AppendText(text + Environment.NewLine);
            }
        }


        // 讀取 Arduino 回傳的 Log
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string response = serialPort.ReadLine()?.Trim();
                AppendLog("Arduino 回傳: " + response);

                // 處理 GET_MODE 回應或其他 Log 資料
                if (response.StartsWith("MODE:"))
                {
                    string modeStr = response.Substring(5).Trim();
                    if (int.TryParse(modeStr, out int modeIndex))
                    {
                        if (modeIndex >= 0 && modeIndex < cmbMode.Items.Count)
                        {
                            BeginInvoke(new Action(() => cmbMode.SelectedIndex = modeIndex));
                        }
                        else
                        {
                            Console.WriteLine($"⚠️ 收到無效模式: {modeStr}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"⚠️ 模式解析失敗: {modeStr}");
                    }
                }
                // 如果有其他 Log，也可在這裡處理
            }
            catch (IOException ex)
            {
                Console.WriteLine("讀取模式失敗 (IO 錯誤): " + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("讀取模式失敗 (未知錯誤): " + ex.ToString());
            }
        }



        private void DisconnectSerial()
        {
            if (cancelTokenSource != null)
            {
                cancelTokenSource.Cancel();
                cancelTokenSource.Dispose();
                cancelTokenSource = null;
            }

            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.DataReceived -= SerialPort_DataReceived;
                serialPort.DiscardInBuffer();
                serialPort.Close();
            }

            UpdateConnectionState(false);
        }




        private void UpdateConnectionState(bool connected)
        {
            btnConnect.Text = connected ? "斷開連接" : "連接";
            cmbPort.Enabled = !connected;
            btnRefresh.Enabled = !connected;
        }


        // 顏色選擇處理
        int red, green, blue;
        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            // 取得 TrackBar 的值
            red = trkRed.Value;
            green = trkGreen.Value;
            blue = trkBlue.Value;

            // 設定面板顏色
            pnlColor.BackColor = Color.FromArgb(
                (int)(red * 2.55),   // 轉換 0-100 到 0-255
                (int)(green * 2.55),
                (int)(blue * 2.55)
            );

            
        }



        // 發送控制資料
        private void SendControlData()
        {
            if (serialPort == null || !serialPort.IsOpen) return;

            byte[] data = new byte[4];
            data[0] = (byte)cmbMode.SelectedIndex; // 直接使用 int
            data[1] = (byte)red;
            data[2] = (byte)green;
            data[3] = (byte)blue;

            try
            {
                serialPort.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"資料傳送失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 刷新串口列表
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(SerialPort.GetPortNames());
            if (cmbPort.Items.Count > 0) cmbPort.SelectedIndex = 0;
        }

        // 視窗關閉時處理
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectSerial();
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMode = (byte)(cmbMode.SelectedIndex); // 轉換為 '0', '1', '2'
            Console.WriteLine($"選擇模式: {currentMode}");
            SendControlData();
        }


        private void update_Click(object sender, EventArgs e)
        {
            SendControlData();
        }
    }
}