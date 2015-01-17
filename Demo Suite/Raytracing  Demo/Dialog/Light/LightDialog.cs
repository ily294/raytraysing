using System;
using System.Drawing;
using System.Windows.Forms;

using Auxiliary.MathTools;
using Auxiliary.Raytracing;

namespace SceneEditor
{
	/// <summary> ���������� ���� ��� ������� ������� ��������� �����. </summary>
	public partial class LightDialog : Form
	{
		#region Private Fields
		
		/// <summary> �������� �����. </summary>
		private Light light = new Light(0);
		
		#endregion
		
		#region Constructor
		
		/// <summary> ������� ���������� ���� ��� ������� ������� ��������� �����. </summary>
		public LightDialog()
		{
			InitializeComponent();
		}
		
		#endregion
		
		#region Private Methods
		
		/// <summary> ���������� ��������� ��������� ����� � ��������� ����������. </summary>
		private void OutputOptions()
		{
			// ������� ������������� �������� �����
			trackBarAmbiantR.Value = Convert.ToInt32(light.AmbiantIntensity.X * trackBarAmbiantR.Maximum);
			trackBarAmbiantG.Value = Convert.ToInt32(light.AmbiantIntensity.Y * trackBarAmbiantG.Maximum);
			trackBarAmbiantB.Value = Convert.ToInt32(light.AmbiantIntensity.Z * trackBarAmbiantB.Maximum);
			
			// ������� ������������� ���������� �����
			trackBarDiffuseR.Value = Convert.ToInt32(light.DiffuseIntensity.X * trackBarDiffuseR.Maximum);
			trackBarDiffuseG.Value = Convert.ToInt32(light.DiffuseIntensity.Y * trackBarDiffuseG.Maximum);
			trackBarDiffuseB.Value = Convert.ToInt32(light.DiffuseIntensity.Z * trackBarDiffuseB.Maximum);
			
			// ������� ������������� ����������� �����
			trackBarSpecularR.Value = Convert.ToInt32(light.SpecularIntensity.X * trackBarSpecularR.Maximum);
			trackBarSpecularG.Value = Convert.ToInt32(light.SpecularIntensity.Y * trackBarSpecularG.Maximum);
			trackBarSpecularB.Value = Convert.ToInt32(light.SpecularIntensity.Z * trackBarSpecularB.Maximum);
			
			// ������� ��������� ��������� �����
			numericUpDownPositionX.Value = Convert.ToDecimal(light.Position.X);
			numericUpDownPositionY.Value = Convert.ToDecimal(light.Position.Y);
			numericUpDownPositionZ.Value = Convert.ToDecimal(light.Position.Z);
			
			// ������� ����� ��������� �����
			if (0 == light.Number)
				labelFirst.BackColor = Color.White;
			else
				if (1 == light.Number)
					labelSecond.BackColor = Color.White;
				else
					if (2 == light.Number)
						labelThird.BackColor = Color.White;
					else
						if (3 == light.Number)
							labelFourth.BackColor = Color.White;
						else
							if (4 == light.Number)
								labelFifth.BackColor = Color.White;
							else
								if (5 == light.Number)
									labelSixth.BackColor = Color.White;
								else
									if (6 == light.Number)
										labelSeventh.BackColor = Color.White;	
									else
										if (7 == light.Number)
											labelEighth.BackColor = Color.White;
		}
		
		/// <summary> ��������� ��������� ��������� ����� �� ��������� ����������. </summary>
		private void InputOptions()
		{
			// ��������� ������������� �������� �����
			light.AmbiantIntensity = new Vector3D(trackBarAmbiantR.Value / (float)trackBarAmbiantR.Maximum,
			                                      trackBarAmbiantG.Value / (float)trackBarAmbiantG.Maximum,
			                                      trackBarAmbiantB.Value / (float)trackBarAmbiantB.Maximum);
			
			// ��������� ������������� ���������� �����
			light.DiffuseIntensity = new Vector3D(trackBarDiffuseR.Value / (float)trackBarDiffuseR.Maximum,
			                                      trackBarDiffuseG.Value / (float)trackBarDiffuseG.Maximum,
			                                      trackBarDiffuseB.Value / (float)trackBarDiffuseB.Maximum);
			
			// ��������� ������������� ����������� �����
			light.SpecularIntensity = new Vector3D(trackBarSpecularR.Value / (float)trackBarSpecularR.Maximum,
			                                       trackBarSpecularG.Value / (float)trackBarSpecularG.Maximum,
			                                       trackBarSpecularB.Value / (float)trackBarSpecularB.Maximum);
			
			// ��������� ��������� ��������� �����
			light.Position = new Vector3D(Convert.ToSingle(numericUpDownPositionX.Value),
			                              Convert.ToSingle(numericUpDownPositionY.Value),
			                              Convert.ToSingle(numericUpDownPositionZ.Value));
		}
		
		#endregion
		
		#region Event Handlers
				
		private void LightDialogLoad(object sender, EventArgs e)
		{
			OutputOptions();
		}
		
		private void LightDialogFormClosed(object sender, FormClosedEventArgs e)
		{
			if (DialogResult == DialogResult.OK) InputOptions();
		}
		
		#endregion
	
		#region Properties
		
		/// <summary> �������� �����. </summary>
		public Light Light
		{
			get
			{
				return light;
			}
			
			set
			{
				light = (Light)Replicator.Copy(value);
			}
		}
		
		#endregion
	}
}
