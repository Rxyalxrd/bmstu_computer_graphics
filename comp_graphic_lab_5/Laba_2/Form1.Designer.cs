
namespace Laba_2
{
    partial class Form1
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
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.btnA = new System.Windows.Forms.Button();
            this.btnFIO = new System.Windows.Forms.Button();
            this.btnAni = new System.Windows.Forms.Button();
            this.trbW = new System.Windows.Forms.TrackBar();
            this.trbH = new System.Windows.Forms.TrackBar();
            this.trbY = new System.Windows.Forms.TrackBar();
            this.trbX = new System.Windows.Forms.TrackBar();
            this.lblW = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.trbR = new System.Windows.Forms.TrackBar();
            this.trbG = new System.Windows.Forms.TrackBar();
            this.trbB = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbDefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbB)).BeginInit();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(21, 12);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(589, 374);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            // 
            // btnA
            // 
            this.btnA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnA.Location = new System.Drawing.Point(700, 20);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(200, 100);
            this.btnA.TabIndex = 1;
            this.btnA.Text = "drow \"A\"";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // btnFIO
            // 
            this.btnFIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFIO.Location = new System.Drawing.Point(700, 160);
            this.btnFIO.Name = "btnFIO";
            this.btnFIO.Size = new System.Drawing.Size(200, 100);
            this.btnFIO.TabIndex = 2;
            this.btnFIO.Text = "drow FIO";
            this.btnFIO.UseVisualStyleBackColor = true;
            this.btnFIO.Click += new System.EventHandler(this.btnFIO_Click);
            // 
            // btnAni
            // 
            this.btnAni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAni.Location = new System.Drawing.Point(700, 300);
            this.btnAni.Name = "btnAni";
            this.btnAni.Size = new System.Drawing.Size(200, 100);
            this.btnAni.TabIndex = 3;
            this.btnAni.Text = "drow animal";
            this.btnAni.UseVisualStyleBackColor = true;
            this.btnAni.Click += new System.EventHandler(this.btnAni_Click);
            // 
            // trbW
            // 
            this.trbW.Location = new System.Drawing.Point(12, 475);
            this.trbW.Maximum = 50;
            this.trbW.Minimum = 1;
            this.trbW.Name = "trbW";
            this.trbW.Size = new System.Drawing.Size(150, 56);
            this.trbW.TabIndex = 4;
            this.trbW.Value = 8;
            // 
            // trbH
            // 
            this.trbH.Location = new System.Drawing.Point(168, 475);
            this.trbH.Maximum = 50;
            this.trbH.Minimum = 1;
            this.trbH.Name = "trbH";
            this.trbH.Size = new System.Drawing.Size(150, 56);
            this.trbH.TabIndex = 5;
            this.trbH.Value = 12;
            // 
            // trbY
            // 
            this.trbY.Location = new System.Drawing.Point(480, 475);
            this.trbY.Maximum = 25;
            this.trbY.Minimum = -25;
            this.trbY.Name = "trbY";
            this.trbY.Size = new System.Drawing.Size(150, 56);
            this.trbY.TabIndex = 6;
            this.trbY.Value = 5;
            // 
            // trbX
            // 
            this.trbX.Location = new System.Drawing.Point(324, 475);
            this.trbX.Maximum = 25;
            this.trbX.Minimum = -25;
            this.trbX.Name = "trbX";
            this.trbX.Size = new System.Drawing.Size(150, 56);
            this.trbX.TabIndex = 7;
            this.trbX.Value = 5;
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Location = new System.Drawing.Point(20, 440);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(59, 17);
            this.lblW.TabIndex = 8;
            this.lblW.Text = "Ширина";
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Location = new System.Drawing.Point(176, 440);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(57, 17);
            this.lblH.TabIndex = 9;
            this.lblH.Text = "Высота";
            this.lblH.Click += new System.EventHandler(this.lblH_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(332, 440);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 17);
            this.lblX.TabIndex = 10;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(488, 440);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 17);
            this.lblY.TabIndex = 11;
            this.lblY.Text = "Y";
            // 
            // trbR
            // 
            this.trbR.Location = new System.Drawing.Point(12, 600);
            this.trbR.Maximum = 255;
            this.trbR.Name = "trbR";
            this.trbR.Size = new System.Drawing.Size(150, 56);
            this.trbR.TabIndex = 12;
            this.trbR.Value = 255;
            // 
            // trbG
            // 
            this.trbG.Location = new System.Drawing.Point(179, 600);
            this.trbG.Maximum = 255;
            this.trbG.Name = "trbG";
            this.trbG.Size = new System.Drawing.Size(150, 56);
            this.trbG.TabIndex = 13;
            // 
            // trbB
            // 
            this.trbB.Location = new System.Drawing.Point(335, 600);
            this.trbB.Maximum = 255;
            this.trbB.Name = "trbB";
            this.trbB.Size = new System.Drawing.Size(150, 56);
            this.trbB.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Красный";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Зеленый";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 565);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Синий";
            // 
            // chbDefault
            // 
            this.chbDefault.AutoSize = true;
            this.chbDefault.Checked = true;
            this.chbDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbDefault.Location = new System.Drawing.Point(588, 600);
            this.chbDefault.Name = "chbDefault";
            this.chbDefault.Size = new System.Drawing.Size(328, 22);
            this.chbDefault.TabIndex = 18;
            this.chbDefault.Text = "Отображать с настройками по умолчанию";
            this.chbDefault.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 692);
            this.Controls.Add(this.chbDefault);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbB);
            this.Controls.Add(this.trbG);
            this.Controls.Add(this.trbR);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.lblW);
            this.Controls.Add(this.trbX);
            this.Controls.Add(this.trbY);
            this.Controls.Add(this.trbH);
            this.Controls.Add(this.trbW);
            this.Controls.Add(this.btnAni);
            this.Controls.Add(this.btnFIO);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.AnT);
            this.Name = "Form1";
            this.Text = "Laba2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnFIO;
        private System.Windows.Forms.Button btnAni;
        private System.Windows.Forms.TrackBar trbW;
        private System.Windows.Forms.TrackBar trbH;
        private System.Windows.Forms.TrackBar trbY;
        private System.Windows.Forms.TrackBar trbX;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TrackBar trbR;
        private System.Windows.Forms.TrackBar trbG;
        private System.Windows.Forms.TrackBar trbB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbDefault;
    }
}

