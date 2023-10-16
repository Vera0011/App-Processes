using System.Diagnostics;

namespace ex3
{
    partial class Main
    {
        private System.Windows.Forms.Button Open_process;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Button Kill_process;
        private System.Windows.Forms.TextBox text;
        private Process_Manager process_Manager = new Process_Manager();

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            Log_System.Start();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support_do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Open_process = this.createButton("Open process", 48, 16, 0, Color.Green);
            this.Input = new System.Windows.Forms.TextBox();
            this.Kill_process = this.createButton("Kill process", 156, 16, 5, Color.Red);
            this.text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            /* INPUT*/
            this.Input.Text = "Path del proceso";
            this.Input.Modified = true;
            this.Input.SelectionStart = 5;
            this.Input.Location = new System.Drawing.Point(260, 12);
            this.Input.Size = new System.Drawing.Size(196, 23);
            this.Input.TabIndex = 4;

            /* TEXTBOX*/
            this.text.Enabled = false;
            this.text.Multiline = true;
            this.text.WordWrap = true;
            this.text.Size = new System.Drawing.Size(this.Width + 70, 100);
            this.text.Location = new System.Drawing.Point(48, 200);

            /* FORM (Window)*/
            this.Size = new System.Drawing.Size(480, 400);
            this.Text = "Main";
            this.Icon = new Icon("icon.ico");
            this.Controls.Add(this.Open_process);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.Kill_process);
            this.Controls.Add(this.text);
            this.ResumeLayout(false);
        }

        private Button createButton(string text, int positionX, int positionY, int tabIndex, Color buttonColor)
        {
            Button button = new System.Windows.Forms.Button();

            button.Text = text;
            button.Location = new System.Drawing.Point(positionX, positionY);
            button.TabIndex = tabIndex;
            button.Click += new System.EventHandler(clickEvent);
            button.BackColor = buttonColor;

            return button;
        }

        private void clickEvent(System.Object? sender, System.EventArgs e)
        {
            ProcessStartInfo processStart = null;
            Button button = (Button)sender;

            if (button.BackColor == Color.Green)
            {
                try
                {
                    processStart = new ProcessStartInfo(this.Input.Text);
                    Process ps = Process.Start(processStart);

                    process_Manager.addProcess(ps);
                    Log_System.writeFile("\nProceso creado correctamente");
                    this.text.Text = "Proceso abierto correctamente";
                }
                catch (Exception error)
                {
                    this.text.Text = "Error al abrir el proceso";
                    Log_System.writeFile("\nError al abrir un proceso: -------- " + error.Message);
                }
            }
            else
            {
                try
                {
                    int result = process_Manager.killProcessByPath(this.Input.Text);
                    
                    if(result == 0)
                    {
                        this.text.Text = "No se ha cerrado ningún proceso";
                        Log_System.writeFile("\nNo se ha cerrado ningún proceso");
                    }
                    else
                    {
                        this.text.Text = "Proceso cerrado correctamente";
                        Log_System.writeFile("\nProceso eliminado correctamente");
                    }
                }
                catch (Exception error)
                {
                    this.text.Text = "Error al cerrar un proceso";
                    Log_System.writeFile("\nError al cerrar un proceso: -------- " + error.Message + error.StackTrace);
                }
            }
        }

        #endregion
    }
}

