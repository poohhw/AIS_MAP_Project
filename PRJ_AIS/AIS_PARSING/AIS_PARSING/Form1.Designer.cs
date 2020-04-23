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
            this.btnAIS = new System.Windows.Forms.Button();
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
            this.label3 = new System.Windows.Forms.Label();
            this.shapeMapView1 = new MapView.ShapeMapView();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAIS
            // 
            this.btnAIS.Location = new System.Drawing.Point(12, 12);
            this.btnAIS.Name = "btnAIS";
            this.btnAIS.Size = new System.Drawing.Size(75, 23);
            this.btnAIS.TabIndex = 0;
            this.btnAIS.Text = "AIS 수신";
            this.btnAIS.UseVisualStyleBackColor = true;
            this.btnAIS.Click += new System.EventHandler(this.btnAIS_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(12, 41);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(319, 90);
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
            this.Grid1.Location = new System.Drawing.Point(12, 147);
            this.Grid1.Name = "Grid1";
            this.Grid1.RowTemplate.Height = 23;
            this.Grid1.Size = new System.Drawing.Size(319, 315);
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
            this.button1.Location = new System.Drawing.Point(256, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "입력";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(256, 596);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "파싱";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "AIS 수신종료";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 601);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // shapeMapView1
            // 
            this.shapeMapView1.BackColor = System.Drawing.SystemColors.Info;
            this.shapeMapView1.Location = new System.Drawing.Point(353, 41);
            this.shapeMapView1.Name = "shapeMapView1";
            this.shapeMapView1.Size = new System.Drawing.Size(697, 549);
            this.shapeMapView1.TabIndex = 5;
            this.shapeMapView1.Paint += new System.Windows.Forms.PaintEventHandler(this.shapeMapView1_Paint);
            this.shapeMapView1.DoubleClick += new System.EventHandler(this.shapeMapView1_DoubleClick);
            this.shapeMapView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.shapeMapView1_MouseClick);
            this.shapeMapView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.shapeMapView1_MouseDoubleClick);
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(1056, 66);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(318, 131);
            this.txtDetail.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1057, 41);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 625);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shapeMapView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAIS);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

