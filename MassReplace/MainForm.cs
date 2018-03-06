using System;
using System.Windows.Forms;

namespace MassReplace
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Controller.Create()
        .SetOutput(s => outputTextBox.Invoke(new Action<string>(s1 => outputTextBox.AppendText(s1 + Environment.NewLine)), s))
        .SetUpdatePath(s => fileLabel.Invoke(new Action<string>(s1 => fileLabel.Text = s1), s))
        .Go();
    }
  }
}
