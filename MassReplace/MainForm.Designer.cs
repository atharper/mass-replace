namespace MassReplace
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.outputTextBox = new System.Windows.Forms.TextBox();
      this.pnfoPanel = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.fileLabel = new System.Windows.Forms.Label();
      this.pnfoPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // outputTextBox
      // 
      this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.outputTextBox.Location = new System.Drawing.Point(3, 36);
      this.outputTextBox.Multiline = true;
      this.outputTextBox.Name = "outputTextBox";
      this.outputTextBox.ReadOnly = true;
      this.outputTextBox.Size = new System.Drawing.Size(421, 299);
      this.outputTextBox.TabIndex = 0;
      // 
      // pnfoPanel
      // 
      this.pnfoPanel.BackColor = System.Drawing.SystemColors.Window;
      this.pnfoPanel.Controls.Add(this.fileLabel);
      this.pnfoPanel.Controls.Add(this.label1);
      this.pnfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnfoPanel.Location = new System.Drawing.Point(3, 3);
      this.pnfoPanel.Name = "pnfoPanel";
      this.pnfoPanel.Padding = new System.Windows.Forms.Padding(12);
      this.pnfoPanel.Size = new System.Drawing.Size(421, 33);
      this.pnfoPanel.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.label1.Location = new System.Drawing.Point(15, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(78, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Processing file:";
      // 
      // fileLabel
      // 
      this.fileLabel.AutoSize = true;
      this.fileLabel.Location = new System.Drawing.Point(99, 12);
      this.fileLabel.Name = "fileLabel";
      this.fileLabel.Size = new System.Drawing.Size(0, 13);
      this.fileLabel.TabIndex = 3;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(427, 338);
      this.Controls.Add(this.outputTextBox);
      this.Controls.Add(this.pnfoPanel);
      this.Name = "Form1";
      this.Padding = new System.Windows.Forms.Padding(3);
      this.Text = "Results";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.pnfoPanel.ResumeLayout(false);
      this.pnfoPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox outputTextBox;
    private System.Windows.Forms.Panel pnfoPanel;
    private System.Windows.Forms.Label fileLabel;
    private System.Windows.Forms.Label label1;
  }
}

