using System;
using System.Windows.Forms;
using Libraries.MathTools;
using Libraries.Raytracing;

namespace SceneEditor
{
	/// <summary> ���������� ���� ��� ������� ���������� ���������������. </summary>
	public partial class BoxDialog : Form
	{
		#region Private Fields
		
		/// <summary> ������ '��������������'. </summary>
		private Box box = new Box(new Vector3D(1.0f, 1.0f, 1.0f));
		
		#endregion
		
		#region Constructor
		
		/// <summary> ������� ���������� ���� ��� ������� ���������� ���������������. </summary>
		public BoxDialog()
		{
			InitializeComponent();
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary> ���������� �������� ��������������� � ��������� ����������. </summary>
		private void OutputOptions()
		{
			// ������� ��� �������
			textBoxName.Text = box.Name;
			
			// ������� ������� ���������������
			numericUpDownSizeX.Value = Convert.ToDecimal(box.Size.X);
			numericUpDownSizeY.Value = Convert.ToDecimal(box.Size.Y);
			numericUpDownSizeZ.Value = Convert.ToDecimal(box.Size.Z);
		}
		
		/// <summary> ��������� �������� ��������������� �� ��������� ����������. </summary>
		private void InputOptions()
		{
			// ��������� ��� �������
			box.Name = textBoxName.Text;
			
			// ��������� ������� ���������������
			box.Size = new Vector3D(Convert.ToSingle(numericUpDownSizeX.Value),
			                        Convert.ToSingle(numericUpDownSizeY.Value),
			                        Convert.ToSingle(numericUpDownSizeZ.Value));
		}
		
		#endregion
		
		#region Event Handlers
		
		private void ButtonTransformClick(object sender, EventArgs e)
		{
			TransformDialog dialog = new TransformDialog();
			
			dialog.Transform = box.Transform;
			
			if (dialog.ShowDialog() == DialogResult.OK)
				box.Transform = dialog.Transform;
		}
		
		private void ButtonMaterialClick(object sender, EventArgs e)
		{
			MaterialDialog dialog = new MaterialDialog();
			
			dialog.Material = box.Material;

			if (dialog.ShowDialog() == DialogResult.OK)
				box.Material = dialog.Material;			
		}		

		private void SquareDialogLoad(object sender, EventArgs e)
		{
			OutputOptions();
		}
		
		private void SquareDialogFormClosed(object sender, FormClosedEventArgs e)
		{
			if (DialogResult == DialogResult.OK) InputOptions();
		}		
		
		#endregion
	
		#region Properties
		
		/// <summary> ������ '��������������'. </summary>
		public Box Box
		{
			get
			{
				return box;
			}
			
			set
			{
				box = (Box) Replicator.Copy(value);
			}
		}
		
		#endregion
	}
}
