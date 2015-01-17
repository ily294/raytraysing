using System;
using System.Windows.Forms;
using Auxiliary.MathTools;
using Auxiliary.Raytracing;

namespace SceneEditor
{
	/// <summary> ���������� ���� ��� ������� �������������� �������. </summary>
	public partial class TransformDialog : Form
	{
		#region Private Fields
		
		/// <summary> �������������� �������. </summary>
		private Transform transform;
		
		#endregion
		
		#region Constructor
		
		/// <summary> ������� ���������� ���� ��� ������� �������������� �������. </summary>
		public TransformDialog()
		{
			InitializeComponent();
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary> ���������� ��������� ������������� ������� � ��������� ����������. </summary>
		private void OutputOptions()
		{
			// ������� ��������� �������
			numericUpDownPositionX.Value = Convert.ToDecimal(transform.Position.X);
			numericUpDownPositionY.Value = Convert.ToDecimal(transform.Position.Y);
			numericUpDownPositionZ.Value = Convert.ToDecimal(transform.Position.Z);		
			
			// ������� ���������� �������
			numericUpDownAngleX.Value = Convert.ToDecimal(180f * transform.Orientation.X / Math.PI);
			numericUpDownAngleY.Value = Convert.ToDecimal(180f * transform.Orientation.Y / Math.PI);
			numericUpDownAngleZ.Value = Convert.ToDecimal(180f * transform.Orientation.Z / Math.PI);
			
			// ������� ��������������� �������
			numericUpDownScalingX.Value = Convert.ToDecimal(transform.Scale.X);
			numericUpDownScalingY.Value = Convert.ToDecimal(transform.Scale.Y);
			numericUpDownScalingZ.Value = Convert.ToDecimal(transform.Scale.Z);
		}
		
		/// <summary> ��������� ��������� ������������� ������� �� ��������� ����������. </summary>
		private void InputOptions()
		{
			// ��������� ��������� �������
			transform.Position = new Vector3D(Convert.ToSingle(numericUpDownPositionX.Value),
			                                  Convert.ToSingle(numericUpDownPositionY.Value),
			                                  Convert.ToSingle(numericUpDownPositionZ.Value));
			
			// ��������� ���������� �������
			transform.Orientation = new Vector3D(Util.PI * Convert.ToSingle(numericUpDownAngleX.Value) / 180f,
			                                     Util.PI * Convert.ToSingle(numericUpDownAngleY.Value) / 180f,
			                                     Util.PI * Convert.ToSingle(numericUpDownAngleZ.Value) / 180f);
			
			// ��������� ��������������� �������
			transform.Scale = new Vector3D(Convert.ToSingle(numericUpDownScalingX.Value),
			                               Convert.ToSingle(numericUpDownScalingY.Value),
			                               Convert.ToSingle(numericUpDownScalingZ.Value));
		}		
		
		#endregion
		
		#region Event Handlers
				
		private void TransformDialogLoad(object sender, EventArgs e)
		{
			OutputOptions();
		}
		
		private void TransformDialogFormClosed(object sender, FormClosedEventArgs e)
		{
			if (DialogResult == DialogResult.OK) InputOptions();
		}		
			
		#endregion		
	
		#region Properties
		
		/// <summary> ������������� �������. </summary>
		public Transform Transform
		{
			get
			{
				return transform;
			}
			
			set
			{
				transform = (Transform) Replicator.Copy(value);
			}			
		}
	
		#endregion
	}
}
