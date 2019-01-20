namespace KanbanChart
{
    partial class WF
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
            this.kanbanBoard1 = new DevExpress.XtraGrid.Demos.KanbanBoard();
            this.SuspendLayout();
            // 
            // kanbanBoard1
            // 
            this.kanbanBoard1.Location = new System.Drawing.Point(123, 12);
            this.kanbanBoard1.Name = "kanbanBoard1";
            this.kanbanBoard1.Size = new System.Drawing.Size(577, 421);
            this.kanbanBoard1.TabIndex = 0;
            // 
            // WF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kanbanBoard1);
            this.Name = "WF";
            this.Text = "WF";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Demos.KanbanBoard kanbanBoard1;
    }
}