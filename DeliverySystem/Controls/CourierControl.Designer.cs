namespace DeliverySystem.Controls
{
    partial class CourierControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Courier = new Label();
            Status = new Label();
            SuspendLayout();
            // 
            // Courier
            // 
            Courier.AutoSize = true;
            Courier.Font = new Font("Segoe UI", 9F);
            Courier.Location = new Point(10, 10);
            Courier.Name = "Courier";
            Courier.Size = new Size(50, 20);
            Courier.TabIndex = 0;
            Courier.Text = "label1";
            // 
            // Status
            // 
            Status.AutoSize = true;
            Status.Font = new Font("Segoe UI", 7F);
            Status.Location = new Point(10, 35);
            Status.Name = "Status";
            Status.Size = new Size(38, 15);
            Status.TabIndex = 1;
            Status.Text = "label2";
            // 
            // CourierControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LawnGreen;
            Controls.Add(Status);
            Controls.Add(Courier);
            Name = "CourierControl";
            Size = new Size(164, 64);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Courier;
        private Label Status;
    }
}
