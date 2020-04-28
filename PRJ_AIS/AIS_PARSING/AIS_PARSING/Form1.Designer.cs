using System.Drawing;

namespace AIS_PARSING
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtData = new System.Windows.Forms.TextBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mmsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accuracy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.second = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maneuver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.shapeMapView1 = new MapView.ShapeMapView();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAIS = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtData, 2);
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Location = new System.Drawing.Point(3, 163);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(294, 134);
            this.txtData.TabIndex = 1;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.repeat,
            this.mmsi,
            this.status,
            this.turn,
            this.speed,
            this.accuracy,
            this.lon,
            this.lat,
            this.course,
            this.heading,
            this.second,
            this.maneuver,
            this.spare,
            this.raim,
            this.radio});
            this.tableLayoutPanel1.SetColumnSpan(this.Grid1, 2);
            this.Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid1.Location = new System.Drawing.Point(3, 303);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 23;
            this.Grid1.Size = new System.Drawing.Size(294, 134);
            this.Grid1.TabIndex = 3;
            // 
            // type
            // 
            this.type.HeaderText = "MessageType";
            this.type.Name = "type";
            // 
            // repeat
            // 
            this.repeat.HeaderText = "RepeatIndicator";
            this.repeat.Name = "repeat";
            // 
            // mmsi
            // 
            this.mmsi.HeaderText = "MMSI";
            this.mmsi.Name = "mmsi";
            // 
            // status
            // 
            this.status.HeaderText = "NavigationStatus";
            this.status.Name = "status";
            // 
            // turn
            // 
            this.turn.HeaderText = "ROT";
            this.turn.Name = "turn";
            // 
            // speed
            // 
            this.speed.HeaderText = "SOG";
            this.speed.Name = "speed";
            // 
            // accuracy
            // 
            this.accuracy.HeaderText = "PositionAccuracy";
            this.accuracy.Name = "accuracy";
            // 
            // lon
            // 
            this.lon.HeaderText = "Longitude";
            this.lon.Name = "lon";
            // 
            // lat
            // 
            this.lat.HeaderText = "Latitude";
            this.lat.Name = "lat";
            // 
            // course
            // 
            this.course.HeaderText = "COG";
            this.course.Name = "course";
            // 
            // heading
            // 
            this.heading.HeaderText = "HDG";
            this.heading.Name = "heading";
            // 
            // second
            // 
            this.second.HeaderText = "TimeStamp";
            this.second.Name = "second";
            // 
            // maneuver
            // 
            this.maneuver.HeaderText = "ManeuverIndicator";
            this.maneuver.Name = "maneuver";
            // 
            // spare
            // 
            this.spare.HeaderText = "Spare";
            this.spare.Name = "spare";
            // 
            // raim
            // 
            this.raim.HeaderText = "RAIM flag";
            this.raim.Name = "raim";
            // 
            // radio
            // 
            this.radio.HeaderText = "RadioStatus";
            this.radio.Name = "radio";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "입력";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(153, 583);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "파싱";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(181)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::AIS_PARSING.Properties.Resources.disconnect;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(153, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 114);
            this.button3.TabIndex = 0;
            this.button3.Text = "AIS 수신종료";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1363, 784);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "맵초기화";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // shapeMapView1
            // 
            this.shapeMapView1.BackColor = System.Drawing.SystemColors.Info;
            this.shapeMapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shapeMapView1.Location = new System.Drawing.Point(303, 43);
            this.shapeMapView1.Name = "shapeMapView1";
            this.tableLayoutPanel1.SetRowSpan(this.shapeMapView1, 4);
            this.shapeMapView1.Size = new System.Drawing.Size(1131, 534);
            this.shapeMapView1.TabIndex = 5;
            this.shapeMapView1.Paint += new System.Windows.Forms.PaintEventHandler(this.shapeMapView1_Paint);
            this.shapeMapView1.DoubleClick += new System.EventHandler(this.shapeMapView1_DoubleClick);
            this.shapeMapView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.shapeMapView1_MouseClick);
            this.shapeMapView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.shapeMapView1_MouseDoubleClick);
            this.shapeMapView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.shapeMapView1_MouseMove);
            this.shapeMapView1.Resize += new System.EventHandler(this.shapeMapView1_Resize);
            // 
            // txtDetail
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDetail, 2);
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Location = new System.Drawing.Point(3, 443);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(294, 134);
            this.txtDetail.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1059, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "선박 정보";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnAIS, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Grid1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDetail, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.shapeMapView1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1437, 621);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnAIS
            // 
            this.btnAIS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAIS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.btnAIS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.btnAIS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(181)))));
            this.btnAIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIS.Image = global::AIS_PARSING.Properties.Resources.ais;
            this.btnAIS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAIS.Location = new System.Drawing.Point(3, 43);
            this.btnAIS.Name = "btnAIS";
            this.btnAIS.Size = new System.Drawing.Size(144, 114);
            this.btnAIS.TabIndex = 0;
            this.btnAIS.Text = "AIS 수신";
            this.btnAIS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAIS.UseVisualStyleBackColor = true;
            this.btnAIS.Click += new System.EventHandler(this.btnAIS_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1437, 40);
            this.panel1.TabIndex = 9;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1362, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 40);
            this.label6.TabIndex = 3;
            this.label6.Text = "─";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.label6.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(92, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "AIS MAP";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1387, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 40);
            this.label5.TabIndex = 1;
            this.label5.Text = "▣";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            this.label5.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.label5.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1412, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ｘ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(303, 580);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1131, 41);
            this.label2.TabIndex = 8;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.ClientSize = new System.Drawing.Size(1441, 625);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAIS;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn repeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn mmsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn turn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn accuracy;
        private System.Windows.Forms.DataGridViewTextBoxColumn lon;
        private System.Windows.Forms.DataGridViewTextBoxColumn lat;
        private System.Windows.Forms.DataGridViewTextBoxColumn course;
        private System.Windows.Forms.DataGridViewTextBoxColumn heading;
        private System.Windows.Forms.DataGridViewTextBoxColumn second;
        private System.Windows.Forms.DataGridViewTextBoxColumn maneuver;
        private System.Windows.Forms.DataGridViewTextBoxColumn spare;
        private System.Windows.Forms.DataGridViewTextBoxColumn raim;
        private System.Windows.Forms.DataGridViewTextBoxColumn radio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private MapView.ShapeMapView shapeMapView1;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}

