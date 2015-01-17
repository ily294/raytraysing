using System;
using System.Windows.Forms;
using Libraries.MathTools;

namespace SceneEditor
{
	/// <summary> ��������� ���� ��� ��������� ���������� ������������. </summary>
	public partial class RenderDialog : Form
	{
		#region Private Fields

		/// <summary> ���������� ������ �������� ������. </summary>
		private Vector3D volumeSize = new Vector3D(5.0f, 5.0f, 5.0f);
		
		#endregion
	
		#region Public Fields
		
		/// <summary> �������� ����. </summary>
		public float MouseSpeed = 0.005f;
		
		/// <summary> �������� ����������. </summary>
		public float KeyboardSpeed = 0.1f;
		
        /// <summary> ������� �����������. </summary>
        public int TraceDepth = 5;        
        
        /// <summary> ����� ������� ����������. </summary>
        public int ThreadsCount = 2;
        
        /// <summary> ������ �����������. </summary>
        public int ImageWidth = 512;        
        
        /// <summary> ������ �����������. </summary>
        public int ImageHeight = 512;        
		
        /// <summary> ���� �������� ������. </summary>
        public float FieldOfView = Util.PI / 6.0f;
        
		#endregion
				
		#region Constructor
		
		/// <summary> ������� ����� ���������� ���� ��� ��������� ���������� ������������. </summary>
		public RenderDialog()
		{
			InitializeComponent();
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary> ���������� ��������� ������������ � ��������� ����������. </summary>
		private void OutputOptions()
		{
			// ������� �������� ����
			trackBarMouse.Value = Convert.ToInt32(10000f * MouseSpeed);
			
			// ������� �������� ����������
			trackBarKeyboard.Value = Convert.ToInt32(100f * KeyboardSpeed);
			
			// ������� ���������� ������ �������� ������
			numericUpDownSizeX.Value = Convert.ToDecimal(volumeSize.X);
			numericUpDownSizeY.Value = Convert.ToDecimal(volumeSize.Y);
			numericUpDownSizeZ.Value = Convert.ToDecimal(volumeSize.Z);
			
			// ������� ������� �����������
			numericUpDownTraceDepth.Value = TraceDepth;
			
			// ������� ����� ������� ��� ��������
			numericUpDownThreadsCount.Value = ThreadsCount;
			
			// ������� ������� �����������
			numericUpDownWidth.Value = ImageWidth;
			numericUpDownHeight.Value = ImageHeight;
			
			// ������� ���� �������� ������
			numericUpDownFieldOfView.Value = Convert.ToDecimal(Util.ToDegree(FieldOfView));
		}
		
		/// <summary> ��������� ��������� ������������ �� ��������� ����������. </summary>
		private void InputOptions()
		{
			// ��������� �������� ����
			MouseSpeed = trackBarMouse.Value / 10000f;
			
			// ��������� �������� ����������
			KeyboardSpeed = trackBarKeyboard.Value / 100f;
			
			// ��������� ���������� ������ �������� ������
			volumeSize = new Vector3D(Convert.ToSingle(numericUpDownSizeX.Value),
			                          Convert.ToSingle(numericUpDownSizeY.Value),
			                          Convert.ToSingle(numericUpDownSizeZ.Value));
			
			// ��������� ������� �����������
			TraceDepth = Convert.ToInt32(numericUpDownTraceDepth.Value);
			
			// ��������� ����� ������� ��� ��������
			ThreadsCount = Convert.ToInt32(numericUpDownThreadsCount.Value);
			
			// ��������� ������� �����������
			ImageWidth = Convert.ToInt32(numericUpDownWidth.Value);
			ImageHeight = Convert.ToInt32(numericUpDownHeight.Value);
			
			// ��������� ���� �������� ������
			FieldOfView = Util.ToRadian(Convert.ToSingle(numericUpDownFieldOfView.Value));
		}		
		
		#endregion
		
		#region Event Handlers
				
		private void RenderDialogLoad(object sender, EventArgs e)
		{
			OutputOptions();
		}
		
		private void RenderDialogFormClosed(object sender, FormClosedEventArgs e)
		{
			if (DialogResult == DialogResult.OK) InputOptions();
		}		
			
		#endregion
		
		#region Properties
		
		/// <summary> ���������� (!) ������ �������� ������. </summary>
		public Vector3D VolumeSize
		{
			get
			{
				return volumeSize;
			}
			
			set
			{
				volumeSize = (Vector3D) Replicator.Copy(value);
			}
		}
		
		#endregion
	}
}
