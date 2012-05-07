using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Hugate.Camera
{
	/// <summary>
	/// Summary description for Multiplexer.
	/// </summary>
	public class Multiplexer : System.Windows.Forms.Panel
	{
		private const int		MaxRows = 5;
		private const int		MaxCols = 5;
		private CameraWindow[,]	camWindows;

		private bool	fitToWindow = false;
		private bool	singleCameraMode = true;
		private bool	camerasVisible = false;

		private int		rows = 1;
		private int		cols = 1;
		private int		cellWidth = 320;
		private int		cellHeight = 240;

		private CameraWindow	lastClicked;

        private CameraWindow cameraWindow1;
        private CameraWindow cameraWindow2;
        private CameraWindow cameraWindow3;
        private CameraWindow cameraWindow4;
        private CameraWindow cameraWindow5;
        private CameraWindow cameraWindow6;
        private CameraWindow cameraWindow7;
        private CameraWindow cameraWindow8;
        private CameraWindow cameraWindow9;
        private CameraWindow cameraWindow10;
        private CameraWindow cameraWindow11;
        private CameraWindow cameraWindow12;
        private CameraWindow cameraWindow13;
        private CameraWindow cameraWindow14;
        private CameraWindow cameraWindow15;
        private CameraWindow cameraWindow16;
        private CameraWindow cameraWindow17;
        private CameraWindow cameraWindow18;
        private CameraWindow cameraWindow19;
        private CameraWindow cameraWindow20;
        private CameraWindow cameraWindow21;
        private CameraWindow cameraWindow22;
        private CameraWindow cameraWindow23;
        private CameraWindow cameraWindow24;
        private CameraWindow cameraWindow25;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// FitToWindow property
		[DefaultValue(false)]
		public bool FitToWindow
		{
			get { return fitToWindow; }
			set
			{
				fitToWindow = value;

				if ((camWindows[0, 0].AutoSize = (!fitToWindow && singleCameraMode)) == true)
				{
					camWindows[0, 0].UpdatePosition();
				}
				else
				{
					UpdateSize();
				}
			}
		}
		// SingleCameraMode property
		[DefaultValue(true)]
		public bool SingleCameraMode
		{
			get { return singleCameraMode; }
			set
			{
				singleCameraMode = value;
				if (!fitToWindow)
					camWindows[0, 0].AutoSize = value;
			}
		}
		// CamerasVisible property
		[DefaultValue(false)]
		public bool CamerasVisible
		{
			get { return camerasVisible; }
			set
			{
				camerasVisible = value;

				// show/hide all cameras
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cols; j++)
					{
						camWindows[i, j].Visible = value;
					}
				}
			}
		}
		// Rows property
		[DefaultValue(1)]
		public int Rows
		{
			get { return rows; }
			set
			{
				rows = Math.Max(1, Math.Min(MaxRows, value));
				UpdateVisiblity();
				UpdateSize();
			}
		}
		// Cols property
		[DefaultValue(1)]
		public int Cols
		{
			get { return cols; }
			set
			{
				cols = Math.Max(1, Math.Min(MaxCols, value));
				UpdateVisiblity();
				UpdateSize();
			}
		}
		// CellWidth
		[DefaultValue(320)]
		public int CellWidth
		{
			get { return cellWidth; }
			set
			{
				cellWidth = Math.Max(50, Math.Min(800, value));
				UpdateSize();
			}
		}
		// CellHeight
		[DefaultValue(240)]
		public int CellHeight
		{
			get { return cellHeight; }
			set
			{
				cellHeight = Math.Max(50, Math.Min(800, value));
				UpdateSize();
			}
		}
		// Context menu for cameras windows
		[DefaultValue(null)]
		public ContextMenu CamerasContextMenu
		{
			get { return camWindows[0, 0].ContextMenu; }
			set
			{
				for (int i = 0; i < MaxRows; i++)
				{
					for (int j = 0; j < MaxCols; j++)
					{
						camWindows[i, j].ContextMenu = value;
					}
				}
			}
		}
		// Camera of the last click
		[Browsable(false)]
		public Camera ContextCamera
		{
			get { return (lastClicked == null) ? null : lastClicked.Camera; }
		}

		// Constructor
		public Multiplexer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			camWindows = new CameraWindow[MaxRows, MaxCols];

			// row 1
			camWindows[0, 0] = cameraWindow1;
            camWindows[0, 1] = cameraWindow2;
            camWindows[0, 2] = cameraWindow3;
            camWindows[0, 3] = cameraWindow4;
            camWindows[0, 4] = cameraWindow5;
            // row 2
            camWindows[1, 0] = cameraWindow6;
            camWindows[1, 1] = cameraWindow7;
            camWindows[1, 2] = cameraWindow8;
            camWindows[1, 3] = cameraWindow9;
            camWindows[1, 4] = cameraWindow10;
            // row 3
            camWindows[2, 0] = cameraWindow11;
            camWindows[2, 1] = cameraWindow12;
            camWindows[2, 2] = cameraWindow13;
            camWindows[2, 3] = cameraWindow14;
            camWindows[2, 4] = cameraWindow15;
            // row 4
            camWindows[3, 0] = cameraWindow16;
            camWindows[3, 1] = cameraWindow17;
            camWindows[3, 2] = cameraWindow18;
            camWindows[3, 3] = cameraWindow19;
            camWindows[3, 4] = cameraWindow20;
            // row 5
            camWindows[4, 0] = cameraWindow21;
            camWindows[4, 1] = cameraWindow22;
            camWindows[4, 2] = cameraWindow23;
            camWindows[4, 3] = cameraWindow24;
            camWindows[4, 4] = cameraWindow25;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.cameraWindow1 = new Hugate.Camera.CameraWindow();
            this.cameraWindow2 = new Hugate.Camera.CameraWindow();
            this.cameraWindow3 = new Hugate.Camera.CameraWindow();
            this.cameraWindow4 = new Hugate.Camera.CameraWindow();
            this.cameraWindow5 = new Hugate.Camera.CameraWindow();
            this.cameraWindow6 = new Hugate.Camera.CameraWindow();
            this.cameraWindow7 = new Hugate.Camera.CameraWindow();
            this.cameraWindow8 = new Hugate.Camera.CameraWindow();
            this.cameraWindow9 = new Hugate.Camera.CameraWindow();
            this.cameraWindow10 = new Hugate.Camera.CameraWindow();
            this.cameraWindow11 = new Hugate.Camera.CameraWindow();
            this.cameraWindow12 = new Hugate.Camera.CameraWindow();
            this.cameraWindow13 = new Hugate.Camera.CameraWindow();
            this.cameraWindow14 = new Hugate.Camera.CameraWindow();
            this.cameraWindow15 = new Hugate.Camera.CameraWindow();
            this.cameraWindow16 = new Hugate.Camera.CameraWindow();
            this.cameraWindow17 = new Hugate.Camera.CameraWindow();
            this.cameraWindow18 = new Hugate.Camera.CameraWindow();
            this.cameraWindow19 = new Hugate.Camera.CameraWindow();
            this.cameraWindow20 = new Hugate.Camera.CameraWindow();
            this.cameraWindow21 = new Hugate.Camera.CameraWindow();
            this.cameraWindow22 = new Hugate.Camera.CameraWindow();
            this.cameraWindow23 = new Hugate.Camera.CameraWindow();
            this.cameraWindow24 = new Hugate.Camera.CameraWindow();
            this.cameraWindow25 = new Hugate.Camera.CameraWindow();
            this.SuspendLayout();
            // 
            // cameraWindow1
            // 
            this.cameraWindow1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow1.Camera = null;
            this.cameraWindow1.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow1.Name = "cameraWindow1";
            this.cameraWindow1.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow1.TabIndex = 0;
            this.cameraWindow1.Text = "cameraWindow1";
            this.cameraWindow1.Visible = false;
            this.cameraWindow1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cameraWindow_MouseDown);
            // 
            // cameraWindow2
            // 
            this.cameraWindow2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow2.Camera = null;
            this.cameraWindow2.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow2.Name = "cameraWindow2";
            this.cameraWindow2.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow2.TabIndex = 0;
            this.cameraWindow2.Text = "cameraWindow2";
            this.cameraWindow2.Visible = false;
            // 
            // cameraWindow3
            // 
            this.cameraWindow3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow3.Camera = null;
            this.cameraWindow3.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow3.Name = "cameraWindow3";
            this.cameraWindow3.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow3.TabIndex = 0;
            this.cameraWindow3.Text = "cameraWindow3";
            this.cameraWindow3.Visible = false;
            // 
            // cameraWindow4
            // 
            this.cameraWindow4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow4.Camera = null;
            this.cameraWindow4.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow4.Name = "cameraWindow4";
            this.cameraWindow4.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow4.TabIndex = 0;
            this.cameraWindow4.Text = "cameraWindow4";
            this.cameraWindow4.Visible = false;
            // 
            // cameraWindow5
            // 
            this.cameraWindow5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow5.Camera = null;
            this.cameraWindow5.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow5.Name = "cameraWindow5";
            this.cameraWindow5.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow5.TabIndex = 0;
            this.cameraWindow5.Text = "cameraWindow5";
            this.cameraWindow5.Visible = false;
            // 
            // cameraWindow6
            // 
            this.cameraWindow6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow6.Camera = null;
            this.cameraWindow6.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow6.Name = "cameraWindow6";
            this.cameraWindow6.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow6.TabIndex = 0;
            this.cameraWindow6.Text = "cameraWindow6";
            this.cameraWindow6.Visible = false;
            // 
            // cameraWindow7
            // 
            this.cameraWindow7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow7.Camera = null;
            this.cameraWindow7.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow7.Name = "cameraWindow7";
            this.cameraWindow7.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow7.TabIndex = 0;
            this.cameraWindow7.Text = "cameraWindow7";
            this.cameraWindow7.Visible = false;
            // 
            // cameraWindow8
            // 
            this.cameraWindow8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow8.Camera = null;
            this.cameraWindow8.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow8.Name = "cameraWindow8";
            this.cameraWindow8.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow8.TabIndex = 0;
            this.cameraWindow8.Text = "cameraWindow8";
            this.cameraWindow8.Visible = false;
            // 
            // cameraWindow9
            // 
            this.cameraWindow9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow9.Camera = null;
            this.cameraWindow9.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow9.Name = "cameraWindow9";
            this.cameraWindow9.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow9.TabIndex = 0;
            this.cameraWindow9.Text = "cameraWindow9";
            this.cameraWindow9.Visible = false;
            // 
            // cameraWindow10
            // 
            this.cameraWindow10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow10.Camera = null;
            this.cameraWindow10.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow10.Name = "cameraWindow10";
            this.cameraWindow10.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow10.TabIndex = 0;
            this.cameraWindow10.Text = "cameraWindow10";
            this.cameraWindow10.Visible = false;
            // 
            // cameraWindow11
            // 
            this.cameraWindow11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow11.Camera = null;
            this.cameraWindow11.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow11.Name = "cameraWindow11";
            this.cameraWindow11.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow11.TabIndex = 0;
            this.cameraWindow11.Text = "cameraWindow11";
            this.cameraWindow11.Visible = false;
            // 
            // cameraWindow12
            // 
            this.cameraWindow12.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow12.Camera = null;
            this.cameraWindow12.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow12.Name = "cameraWindow12";
            this.cameraWindow12.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow12.TabIndex = 0;
            this.cameraWindow12.Text = "cameraWindow12";
            this.cameraWindow12.Visible = false;
            // 
            // cameraWindow13
            // 
            this.cameraWindow13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow13.Camera = null;
            this.cameraWindow13.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow13.Name = "cameraWindow13";
            this.cameraWindow13.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow13.TabIndex = 0;
            this.cameraWindow13.Text = "cameraWindow13";
            this.cameraWindow13.Visible = false;
            // 
            // cameraWindow14
            // 
            this.cameraWindow14.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow14.Camera = null;
            this.cameraWindow14.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow14.Name = "cameraWindow14";
            this.cameraWindow14.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow14.TabIndex = 0;
            this.cameraWindow14.Text = "cameraWindow14";
            this.cameraWindow14.Visible = false;
            // 
            // cameraWindow15
            // 
            this.cameraWindow15.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow15.Camera = null;
            this.cameraWindow15.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow15.Name = "cameraWindow15";
            this.cameraWindow15.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow15.TabIndex = 0;
            this.cameraWindow15.Text = "cameraWindow15";
            this.cameraWindow15.Visible = false;
            // 
            // cameraWindow16
            // 
            this.cameraWindow16.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow16.Camera = null;
            this.cameraWindow16.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow16.Name = "cameraWindow16";
            this.cameraWindow16.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow16.TabIndex = 0;
            this.cameraWindow16.Text = "cameraWindow16";
            this.cameraWindow16.Visible = false;
            // 
            // cameraWindow17
            // 
            this.cameraWindow17.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow17.Camera = null;
            this.cameraWindow17.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow17.Name = "cameraWindow17";
            this.cameraWindow17.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow17.TabIndex = 0;
            this.cameraWindow17.Text = "cameraWindow17";
            this.cameraWindow17.Visible = false;
            // 
            // cameraWindow18
            // 
            this.cameraWindow18.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow18.Camera = null;
            this.cameraWindow18.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow18.Name = "cameraWindow18";
            this.cameraWindow18.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow18.TabIndex = 0;
            this.cameraWindow18.Text = "cameraWindow18";
            this.cameraWindow18.Visible = false;
            // 
            // cameraWindow19
            // 
            this.cameraWindow19.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow19.Camera = null;
            this.cameraWindow19.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow19.Name = "cameraWindow19";
            this.cameraWindow19.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow19.TabIndex = 0;
            this.cameraWindow19.Text = "cameraWindow19";
            this.cameraWindow19.Visible = false;
            // 
            // cameraWindow20
            // 
            this.cameraWindow20.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow20.Camera = null;
            this.cameraWindow20.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow20.Name = "cameraWindow20";
            this.cameraWindow20.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow20.TabIndex = 0;
            this.cameraWindow20.Text = "cameraWindow20";
            this.cameraWindow20.Visible = false;
            // 
            // cameraWindow21
            // 
            this.cameraWindow21.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow21.Camera = null;
            this.cameraWindow21.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow21.Name = "cameraWindow21";
            this.cameraWindow21.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow21.TabIndex = 0;
            this.cameraWindow21.Text = "cameraWindow21";
            this.cameraWindow21.Visible = false;
            // 
            // cameraWindow22
            // 
            this.cameraWindow22.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow22.Camera = null;
            this.cameraWindow22.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow22.Name = "cameraWindow22";
            this.cameraWindow22.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow22.TabIndex = 0;
            this.cameraWindow22.Text = "cameraWindow22";
            this.cameraWindow22.Visible = false;
            // 
            // cameraWindow23
            // 
            this.cameraWindow23.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow23.Camera = null;
            this.cameraWindow23.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow23.Name = "cameraWindow23";
            this.cameraWindow23.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow23.TabIndex = 0;
            this.cameraWindow23.Text = "cameraWindow23";
            this.cameraWindow23.Visible = false;
            // 
            // cameraWindow24
            // 
            this.cameraWindow24.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow24.Camera = null;
            this.cameraWindow24.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow24.Name = "cameraWindow24";
            this.cameraWindow24.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow24.TabIndex = 0;
            this.cameraWindow24.Text = "cameraWindow24";
            this.cameraWindow24.Visible = false;
            // 
            // cameraWindow25
            // 
            this.cameraWindow25.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cameraWindow25.Camera = null;
            this.cameraWindow25.Location = new System.Drawing.Point(285, 17);
            this.cameraWindow25.Name = "cameraWindow25";
            this.cameraWindow25.Size = new System.Drawing.Size(75, 64);
            this.cameraWindow25.TabIndex = 0;
            this.cameraWindow25.Text = "cameraWindow25";
            this.cameraWindow25.Visible = false;
            // 
            // Multiplexer
            // 
            this.Controls.Add(this.cameraWindow1);
            this.Size = new System.Drawing.Size(424, 376);
            this.Resize += new System.EventHandler(this.Multiplexer_Resize);
            this.ResumeLayout(false);

		}
		#endregion

		
		// Close all cameras
		public void CloseAll()
		{
			for (int i = 0; i < MaxRows; i++)
			{
				for (int j = 0; j < MaxCols; j++)
				{
					camWindows[i, j].Camera = null;
				}
			}
		}

		// Set camera to the specified position of the multiplexer
		public void SetCamera(int row, int col, Camera camera)
		{
			if ((row >= 0) && (col >= 0) && (row < MaxRows) && (col < MaxCols))
			{
				camWindows[row, col].Camera = camera;
			}
		}

		// Set multiplexer size
		public void SetSize(int rows, int cols, int cellWidth, int cellHeight)
		{
			this.rows = rows;
			this.cols = cols;
			this.cellWidth = cellWidth;
			this.cellHeight = cellHeight;
			UpdateSize();
		}

		// Update cameras visibility
		private void UpdateVisiblity()
		{
			if (camerasVisible)
			{
				for (int i = 0; i < MaxRows; i++)
				{
					for (int j = 0; j < MaxCols; j++)
					{
						camWindows[i, j].Visible = ((i < rows) && (j < cols));
					}
				}
			}
		}

		// Update cameras size and position
		private void UpdateSize()
		{
			int width, height;

			if (!fitToWindow)
			{
				// original width & height
				width = cellWidth;
				height = cellHeight;
			}
			else
			{
				// calculate width & height of cameras to fit the view to the window
				width = (ClientRectangle.Width / cols) - 4;
				height = (ClientRectangle.Height / rows) - 4;
			}

			// starting position of the view
			int startX = (ClientRectangle.Width - cols * (width + 4)) / 2;
			int startY = (ClientRectangle.Height - rows * (height + 4)) / 2;

			this.SuspendLayout();

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					camWindows[i, j].Location = new Point(startX + (width + 4) * j + 1, startY + (height + 4) * i + 1);
					camWindows[i, j].Size = new Size(width + 2, height + 2);
				}
			}

			this.ResumeLayout(false);
		}

		// On size changed
		private void Multiplexer_Resize(object sender, System.EventArgs e)
		{
			UpdateSize();
		}

		// On mouse down in camera window
		private void cameraWindow_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			lastClicked = (CameraWindow) sender;
		}
	}
}
