
namespace CS031MereniAlgoritmuProhozeni
{
    partial class MereniAlgoritmuProhozeniForm
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
            this.testButton = new System.Windows.Forms.Button();
            this.vystupTextBox = new System.Windows.Forms.TextBox();
            this.meritProhozeniButton = new System.Windows.Forms.Button();
            this.meritRazeniButton = new System.Windows.Forms.Button();
            this.akceProgressBar = new System.Windows.Forms.ProgressBar();
            this.akceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // testButton
            // 
            this.testButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.testButton.Location = new System.Drawing.Point(12, 12);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(241, 107);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "Spustit Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // vystupTextBox
            // 
            this.vystupTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vystupTextBox.Location = new System.Drawing.Point(12, 222);
            this.vystupTextBox.Multiline = true;
            this.vystupTextBox.Name = "vystupTextBox";
            this.vystupTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.vystupTextBox.Size = new System.Drawing.Size(776, 216);
            this.vystupTextBox.TabIndex = 1;
            // 
            // meritProhozeniButton
            // 
            this.meritProhozeniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.meritProhozeniButton.Location = new System.Drawing.Point(281, 12);
            this.meritProhozeniButton.Name = "meritProhozeniButton";
            this.meritProhozeniButton.Size = new System.Drawing.Size(241, 107);
            this.meritProhozeniButton.TabIndex = 2;
            this.meritProhozeniButton.Text = "Měřit prohození";
            this.meritProhozeniButton.UseVisualStyleBackColor = true;
            this.meritProhozeniButton.Click += new System.EventHandler(this.meritProhozeniButton_Click);
            // 
            // meritRazeniButton
            // 
            this.meritRazeniButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.meritRazeniButton.Location = new System.Drawing.Point(547, 12);
            this.meritRazeniButton.Name = "meritRazeniButton";
            this.meritRazeniButton.Size = new System.Drawing.Size(241, 107);
            this.meritRazeniButton.TabIndex = 3;
            this.meritRazeniButton.Text = "Měřit řazení";
            this.meritRazeniButton.UseVisualStyleBackColor = true;
            this.meritRazeniButton.Click += new System.EventHandler(this.meritRazeniButton_Click);
            // 
            // akceProgressBar
            // 
            this.akceProgressBar.Location = new System.Drawing.Point(12, 181);
            this.akceProgressBar.MarqueeAnimationSpeed = 1;
            this.akceProgressBar.Name = "akceProgressBar";
            this.akceProgressBar.Size = new System.Drawing.Size(776, 35);
            this.akceProgressBar.Step = 1;
            this.akceProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.akceProgressBar.TabIndex = 4;
            // 
            // akceLabel
            // 
            this.akceLabel.AutoSize = true;
            this.akceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.akceLabel.Location = new System.Drawing.Point(12, 154);
            this.akceLabel.Name = "akceLabel";
            this.akceLabel.Size = new System.Drawing.Size(20, 24);
            this.akceLabel.TabIndex = 5;
            this.akceLabel.Text = "?";
            // 
            // MereniAlgoritmuProhozeniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.akceLabel);
            this.Controls.Add(this.akceProgressBar);
            this.Controls.Add(this.meritRazeniButton);
            this.Controls.Add(this.meritProhozeniButton);
            this.Controls.Add(this.vystupTextBox);
            this.Controls.Add(this.testButton);
            this.Name = "MereniAlgoritmuProhozeniForm";
            this.Text = "CS044 Meření Algoritmu Řazení - František Krejný";
            this.Load += new System.EventHandler(this.MereniAlgoritmuProhozeniForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TextBox vystupTextBox;
        private System.Windows.Forms.Button meritProhozeniButton;
        private System.Windows.Forms.Button meritRazeniButton;
        private System.Windows.Forms.ProgressBar akceProgressBar;
        private System.Windows.Forms.Label akceLabel;
    }
}

