using System;
using System.Windows.Forms;
using Auxiliary.Raytracing;

namespace SceneEditor
{
	/// <summary> ���������� ���� ��� ������� ���������� �����. </summary>
	public partial class SphereDialog : Form
	{
		#region Private Fields

		/// <summary> ������ '�����'. </summary>
		private Sphere sphere = new Sphere(1.0f);
		
		#endregion
		
		#region Constructor
		
		/// <summary> ������� ��������� ���� ��� ������� ���������� �����. </summary>
		public SphereDialog()
		{
			InitializeComponent();
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary> ���������� �������� ����� � ��������� ����������. </summary>
		private void OutputOptions()
		{
			// ������� ��� �������
			textBoxName.Text = sphere.Name;
			
			// ������� ������ �����
			numericUpDownRadius.Value = Convert.ToDecimal(sphere.Radius);
		}
		
		/// <summary> ��������� �������� ����� �� ��������� ����������. </summary>
		private void InputOptions()
		{
			// ��������� ��� �������
			sphere.Name = textBoxName.Text;
			
			// ��������� ������ �����
			sphere.Radius = Convert.ToSingle(numericUpDownRadius.Value);
		}
		
		#endregion		
		
		#region Event Handlers
		
		private void ButtonTransformClick(object sender, EventArgs e)
		{
			TransformDialog dialog = new TransformDialog();
			
			dialog.Transform = sphere.Transform;
			
			if (dialog.ShowDialog() == DialogResult.OK)
				sphere.Transform = dialog.Transform;
		}
		
		private void ButtonMaterialClick(object sender, EventArgs e)
		{
			MaterialDialog dialog = new MaterialDialog();
			
			dialog.Material = sphere.Material;
			
			if (dialog.ShowDialog() == DialogResult.OK)
				sphere.Material = dialog.Material;
		}

		private void SphereDialogLoad(object sender, EventArgs e)
		{
			OutputOptions();
		}
		
		private void SphereDialogFormClosed(object sender, FormClosedEventArgs e)
		{
			if (DialogResult == DialogResult.OK) InputOptions();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary> ������ '�����'. </summary>
		public Sphere Sphere
		{
			get
			{
				return sphere;
			}
			
			set
			{
				sphere = (Sphere) Replicator.Copy(value);
			}
		}
		
		#endregion
	}
}
