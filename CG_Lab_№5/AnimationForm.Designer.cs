namespace CG_Lab__5
{
    partial class AnimationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.startGB = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.startGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 40;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 30;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // startGB
            // 
            this.startGB.Controls.Add(this.label1);
            this.startGB.Controls.Add(this.startButton);
            this.startGB.Location = new System.Drawing.Point(280, 167);
            this.startGB.Name = "startGB";
            this.startGB.Size = new System.Drawing.Size(200, 100);
            this.startGB.TabIndex = 0;
            this.startGB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(79, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Привет";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(63, 61);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "НАЧАТЬ";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // AnimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startGB);
            this.DoubleBuffered = true;
            this.Name = "AnimationForm";
            this.Text = "Не убейся";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimationForm_Paint);
            this.startGB.ResumeLayout(false);
            this.startGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer drawTimer;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.GroupBox startGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
    }
}

