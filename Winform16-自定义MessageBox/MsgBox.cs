using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Winform16_自定义MessageBox
{
    public partial class MyMsgBox : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        [DllImport("Shell32.dll")]
        public static extern int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, int nIcons);

        private static IntPtr[] largeIcon;
        private static IntPtr[] smallIcon;

        private static MyMsgBox newMessageBox;
        private static Label frmTitle;
        private static Label frmMessage;
        private static PictureBox pIcon;
        private static FlowLayoutPanel flpButtons;
        private static Icon frmIcon;

        private static Button btnOK;
        private static Button btnAbort;
        private static Button btnRetry;
        private static Button btnIgnore;
        private static Button btnCancel;
        private static Button btnYes;
        private static Button btnNo;

        private static DialogResult CYReturnButton;

        public enum MyIcon
        {
            Error,
            Explorer,
            Find,
            Information,
            Mail,
            Media,
            Print,
            Question,
            RecycleBinEmpty,
            RecycleBinFull,
            Stop,
            User,
            Warning
        }

        public enum MyButtons
        {
            AbortRetryIgnore,
            OK,
            OKCancel,
            RetryCancel,
            YesNo,
            YesNoCancel
        }

        private static void BuildMessageBox(string title)
        {
            newMessageBox = new MyMsgBox
            {
                Text = title,
                Size = new System.Drawing.Size(400, 200),
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            };
            newMessageBox.Paint += new PaintEventHandler(newMessageBox_Paint);
            newMessageBox.BackColor = System.Drawing.Color.White;

            TableLayoutPanel tlp = new TableLayoutPanel
            {
                RowCount = 3,
                ColumnCount = 0,
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50));
            tlp.BackColor = System.Drawing.Color.Transparent;
            tlp.Padding = new Padding(2, 5, 2, 2);

            frmTitle = new Label
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.White,
                Font = new Font("Tahoma", 9, FontStyle.Bold)
            };

            frmMessage = new Label
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                BackColor = System.Drawing.Color.White,
                Font = new Font("Tahoma", 15, FontStyle.Regular),
                Text = "hiii"
            };

            largeIcon = new IntPtr[250];
            smallIcon = new IntPtr[250];
            pIcon = new PictureBox();
            ExtractIconEx("shell32.dll", 0, largeIcon, smallIcon, 250);

            flpButtons = new FlowLayoutPanel
            {
                FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
                Padding = new Padding(0, 5, 5, 0),
                Dock = System.Windows.Forms.DockStyle.Fill,
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            };

            TableLayoutPanel tlpMessagePanel = new TableLayoutPanel
            {
                BackColor = System.Drawing.Color.White,
                Dock = System.Windows.Forms.DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 0,
                Padding = new Padding(4, 5, 4, 4)
            };
            tlpMessagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50));
            tlpMessagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpMessagePanel.Controls.Add(pIcon);
            tlpMessagePanel.Controls.Add(frmMessage);

            tlp.Controls.Add(frmTitle);
            tlp.Controls.Add(tlpMessagePanel);
            tlp.Controls.Add(flpButtons);
            newMessageBox.Controls.Add(tlp);
        }

        /// <summary>
        /// Message: Text to display in the message box.
        /// </summary>
        public static DialogResult Show(string Message)
        {
            BuildMessageBox("");
            frmMessage.Text = Message;
            ShowOKButton();
            newMessageBox.ShowDialog();
            return CYReturnButton;
        }

        /// <summary>
        /// Title: Text to display in the title bar of the messagebox.
        /// </summary>
        public static DialogResult Show(string Message, string Title)
        {
            BuildMessageBox(Title);
            frmTitle.Text = Title;
            frmMessage.Text = Message;
            ShowOKButton();
            newMessageBox.ShowDialog();
            return CYReturnButton;
        }

        /// <summary>
        /// MButtons: Display MyButtons on the message box.
        /// </summary>
        public static DialogResult Show(string Message, string Title, MyButtons MButtons)
        {
            BuildMessageBox(Title); // BuildMessageBox method, responsible for creating the MessageBox
            frmTitle.Text = Title; // Set the title of the MessageBox
            frmMessage.Text = Message; //Set the text of the MessageBox
            ButtonStatements(MButtons); // ButtonStatements method is responsible for showing the appropreiate buttons
            newMessageBox.ShowDialog(); // Show the MessageBox as a Dialog.
            return CYReturnButton; // Return the button click as an Enumerator
        }

        /// <summary>
        /// MIcon: Display MyIcon on the message box.
        /// </summary>
        public static DialogResult Show(string Message, string Title, MyButtons MButtons, MyIcon MIcon)
        {
            BuildMessageBox(Title);
            frmTitle.Text = Title;
            frmMessage.Text = Message;
            ButtonStatements(MButtons);
            IconStatements(MIcon);
            Image imageIcon = new Bitmap(frmIcon.ToBitmap(), 38, 38);
            pIcon.Image = imageIcon;
            newMessageBox.ShowDialog();
            return CYReturnButton;
        }

        private static void btnOK_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.OK;
            newMessageBox.Dispose();
        }

        private static void btnAbort_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.Abort;
            newMessageBox.Dispose();
        }

        private static void btnRetry_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.Retry;
            newMessageBox.Dispose();
        }

        private static void btnIgnore_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.Ignore;
            newMessageBox.Dispose();
        }

        private static void btnCancel_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.Cancel;
            newMessageBox.Dispose();
        }

        private static void btnYes_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.Yes;
            newMessageBox.Dispose();
        }

        private static void btnNo_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.No;
            newMessageBox.Dispose();
        }

        private static void ShowOKButton()
        {
            btnOK = new Button
            {
                Text = "OK",
                Size = new System.Drawing.Size(80, 25),
                BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                Font = new Font("Tahoma", 8, FontStyle.Regular)
            };
            btnOK.Click += new EventHandler(btnOK_Click);
            flpButtons.Controls.Add(btnOK);
        }

        private static void ShowAbortButton()
        {
            btnAbort = new Button
            {
                Text = "Abort",
                Size = new System.Drawing.Size(80, 25),
                BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                Font = new Font("Tahoma", 8, FontStyle.Regular)
            };
            btnAbort.Click += new EventHandler(btnAbort_Click);
            flpButtons.Controls.Add(btnAbort);
        }

        private static void ShowRetryButton()
        {
            btnRetry = new Button
            {
                Text = "Retry",
                Size = new System.Drawing.Size(80, 25),
                BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                Font = new Font("Tahoma", 8, FontStyle.Regular)
            };
            btnRetry.Click += new EventHandler(btnRetry_Click);
            flpButtons.Controls.Add(btnRetry);
        }

        private static void ShowIgnoreButton()
        {
            btnIgnore = new Button
            {
                Text = "Ignore",
                Size = new System.Drawing.Size(80, 25),
                BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                Font = new Font("Tahoma", 8, FontStyle.Regular)
            };
            btnIgnore.Click += new EventHandler(btnIgnore_Click);
            flpButtons.Controls.Add(btnIgnore);
        }

        private static void ShowCancelButton()
        {
            btnCancel = new Button
            {
                Text = "Cancel",
                Size = new System.Drawing.Size(80, 25),
                BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                Font = new Font("Tahoma", 8, FontStyle.Regular)
            };
            btnCancel.Click += new EventHandler(btnCancel_Click);
            flpButtons.Controls.Add(btnCancel);
        }

        private static void ShowYesButton()
        {
            btnYes = new Button
            {
                Text = "确认",
                Size = new System.Drawing.Size(80, 25),
                BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                Font = new Font("Tahoma", 8, FontStyle.Regular)
            };
            btnYes.Click += new EventHandler(btnYes_Click);
            flpButtons.Controls.Add(btnYes);
        }

        private static void ShowNoButton()
        {
            btnNo = new Button
            {
                Text = "取消",
                Size = new System.Drawing.Size(80, 25),
                BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                Font = new Font("Tahoma", 8, FontStyle.Regular)
            };
            btnNo.Click += new EventHandler(btnNo_Click);
            flpButtons.Controls.Add(btnNo);
        }

        private static void ButtonStatements(MyButtons MButtons)
        {
            if (MButtons == MyButtons.AbortRetryIgnore)
            {
                ShowIgnoreButton();
                ShowRetryButton();
                ShowAbortButton();
            }

            if (MButtons == MyButtons.OK)
            {
                ShowOKButton();
            }

            if (MButtons == MyButtons.OKCancel)
            {
                ShowCancelButton();
                ShowOKButton();
            }

            if (MButtons == MyButtons.RetryCancel)
            {
                ShowCancelButton();
                ShowRetryButton();
            }

            if (MButtons == MyButtons.YesNo)
            {
                ShowNoButton();
                ShowYesButton();
            }

            if (MButtons == MyButtons.YesNoCancel)
            {
                ShowCancelButton();
                ShowNoButton();
                ShowYesButton();
            }
        }

        private static void IconStatements(MyIcon MIcon)
        {
            if (MIcon == MyIcon.Error)
            {
                MessageBeep(0);
                if (largeIcon[109] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[109]);
                }
            }

            if (MIcon == MyIcon.Explorer)
            {
                MessageBeep(0);
                if (largeIcon[220] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[220]);
                }
            }

            if (MIcon == MyIcon.Find)
            {
                MessageBeep(0);
                if (largeIcon[22] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[22]);
                }
            }

            if (MIcon == MyIcon.Information)
            {
                MessageBeep(0);
                if (largeIcon[221] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[221]);
                }
            }

            if (MIcon == MyIcon.Mail)
            {
                MessageBeep(0);
                if (largeIcon[156] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[156]);
                }
            }

            if (MIcon == MyIcon.Media)
            {
                MessageBeep(0);
                if (largeIcon[116] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[116]);
                }
            }

            if (MIcon == MyIcon.Print)
            {
                MessageBeep(0);
                if (largeIcon[136] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[136]);
                }
            }

            if (MIcon == MyIcon.Question)
            {
                MessageBeep(0);
                //Icon icon = Icon.FromHandle(largeIcon[23]);
                if (largeIcon[23] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[23]);
                }

            }

            if (MIcon == MyIcon.RecycleBinEmpty)
            {
                MessageBeep(0);
                if (largeIcon[31] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[31]);
                }
            }

            if (MIcon == MyIcon.RecycleBinFull)
            {
                MessageBeep(0);
                if (largeIcon[32] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[32]);
                }
            }

            if (MIcon == MyIcon.Stop)
            {
                MessageBeep(0);
                if (largeIcon[27] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[27]);
                }
            }

            if (MIcon == MyIcon.User)
            {
                MessageBeep(0);
                if (largeIcon[170] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[170]);
                }
            }

            if (MIcon == MyIcon.Warning)
            {
                MessageBeep(30);
                if (largeIcon[217] != IntPtr.Zero)
                {
                    frmIcon = Icon.FromHandle(largeIcon[217]);
                }
            }
        }

        private static void newMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle frmTitleL = new Rectangle(0, 0, (newMessageBox.Width / 2), 22);
            Rectangle frmTitleR = new Rectangle((newMessageBox.Width / 2), 0, (newMessageBox.Width / 2), 22);
            Rectangle frmMessageBox = new Rectangle(0, 0, (newMessageBox.Width - 1), (newMessageBox.Height - 1));
            LinearGradientBrush frmLGBL = new LinearGradientBrush(frmTitleL, Color.FromArgb(87, 148, 160), Color.FromArgb(209, 230, 243), LinearGradientMode.Horizontal);
            LinearGradientBrush frmLGBR = new LinearGradientBrush(frmTitleR, Color.FromArgb(209, 230, 243), Color.FromArgb(87, 148, 160), LinearGradientMode.Horizontal);
            Pen frmPen = new Pen(Color.FromArgb(63, 119, 143), 1);
            g.FillRectangle(frmLGBL, frmTitleL);
            g.FillRectangle(frmLGBR, frmTitleR);
            g.DrawRectangle(frmPen, frmMessageBox);
        }
    }
}
