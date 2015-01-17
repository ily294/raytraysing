using System;
using System.Windows.Forms;
using Auxiliary.MathTools;
using Auxiliary.Raytracing;

namespace SceneEditor
{
	/// <summary> ���������� ���� ��� ������� ���������� ��������������. </summary>
	public partial class SquareDialog : Form
	{
		#region Private Fields
		
		/// <summary> ������ '�������������'. </summary>
		private Square square = new Square(new Vector2D(1.0f, 1.0f));
		
		#endregion
		
		#region Constructor
		
		/// <summary> ������� ���������� ���� ��� ������� ���������� ��������������. </summary>
		public SquareDialog()
		{
			InitializeComponent();
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary> ���������� �������� �������������� � ��������� ����������. </summary>
		private void OutputOptions()
		{
			// ������� ��� �������
			textBoxName.Text = square.Name;
			
			// ������� ������� ��������������
			numericUpDownSizeX.Value = Convert.ToDecimal(square.Size.X);
			numericUpDownSizeY.Value = Convert.ToDecimal(square.Size.Y);
		}
		
		/// <summary> ��������� �������� �������������� �� ��������� ����������. </summary>
		private void InputOptions()
		{
			// ��������� ��� �������
			square.Name = textBoxName.Text;
			
			// ��������� ������� ��������������
			square.Size = new Vector2D(Convert.ToSingle(numericUpDownSizeX.Value),
			                           Convert.ToSingle(numericUpDownSizeY.Value));
		}
		
		#endregion
		
		#region Event Handlers
		
		private void ButtonTransformClick(object sender, EventArgs e)
		{
			TransformDialog dialog = new TransformDialog();
			
			dialog.Transform = square.Transform;
			
			if (dialog.ShowDialog() == DialogResult.OK)
				square.Transform = dialog.Transform;
		}
		
		private void ButtonMaterialClick(object sender, EventArgs e)
		{
			MaterialDialog dialog = new MaterialDialog();
			
			dialog.Material = square.Material;
			
			if (dialog.ShowDialog() == DialogResult.OK)
				square.Material = dialog.Material;			
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
		
		/// <summary> ������ '�������������'. </summary>
		public Square Square
		{
			get
			{
				return square;
			}
			
			set
			{
				square = (Square) Replicator.Copy(value);
			}
		}
		
		#endregion
	}
}
