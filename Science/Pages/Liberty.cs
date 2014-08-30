using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Science
{
    public partial class Liberty : Page
    {
        public Liberty()
        {
            InitializeComponent();
        }

        public void Animate()
        {
                System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    try
                    {
                        sleep(1000);
                        Show(label16, 7);

                        sleep(900);
                        Show(label1, 10);
                        sleep(1000);
                        Show(label2, 10);
                        sleep(1000);
                        Show(label3, 5);
                        sleep(800);
                        Show(label4, 5);
                        sleep(1100);
                        Show(label5, 10);

                        sleep(1200);
                        Show(label6, 10);
                        sleep(1000);
                        Show(label7, 10);
                        sleep(1000);
                        Show(label8, 5);
                        sleep(800);
                        Show(label9, 5);
                        sleep(1100);
                        Show(label10, 10);

                        sleep(1200);
                        Show(label11, 10);
                        sleep(1000);
                        Show(label12, 10);
                        sleep(1000);
                        Show(label13, 5);
                        sleep(800);
                        Show(label14, 5);
                        sleep(1100);
                        Show(label15, 10);
                        sleep(1000);
                        Show(label17, 10);

                        PullIn(button1, new Point(49, 488));
                        PullIn(button2, new Point(145, 488));
                        PullIn(button3, new Point(241, 488));
                    }
                    catch { }
                }));
                T.Start();
        }

        private void sleep(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        private void Show(Label target, int delay)
        {
            Color C = target.ForeColor;
            while (C.R != 0 || C.G != 0 || C.B != 0)
            {
                int R = C.R > 1 ? C.R - 2 : 0;
                int G = C.G > 1 ? C.G - 2 : 0;
                int B = C.B > 1 ? C.B - 2 : 0;

                C = Color.FromArgb(R, G, B);
                target.Invoke(new Action(() =>
                {
                    target.ForeColor = C;
                }));
                System.Threading.Thread.Sleep(delay);
            }
        }

        private void PullIn(ArbitraryButton target, Point p)
        {
            Color BackColor = target.BackColor;
            Color ForeColor = target.ForeColor;
            Color BorderColor = target.BorderColor;

            target.Invoke(new Action(() =>
            {
                target.ForeColor = SystemColors.Control;
                target.BackColor = SystemColors.Control;
                target.BorderColor = SystemColors.Control;

                target.Update();
                target.Location = p;
            }));

            while (target.ForeColor.R != ForeColor.R || target.BackColor.R != BackColor.R || target.BorderColor.R != BorderColor.R)
            {
                target.Invoke(new Action(() =>
                {
                    if (target.ForeColor.R > ForeColor.R)
                    {
                        target.ForeColor = Color.FromArgb(target.ForeColor.R - 1, target.ForeColor.G - 1, target.ForeColor.B - 1);
                    }
                    else if (target.ForeColor.R < ForeColor.R)
                    {
                        target.ForeColor = Color.FromArgb(target.ForeColor.R + 1, target.ForeColor.G + 1, target.ForeColor.B + 1);
                    }

                    if (target.BackColor.R > BackColor.R)
                    {
                        target.BackColor = Color.FromArgb(target.BackColor.R - 1, target.BackColor.G - 1, target.BackColor.B - 1);
                    }
                    else if (target.BackColor.R < BackColor.R)
                    {
                        target.BackColor = Color.FromArgb(target.BackColor.R + 1, target.BackColor.G + 1, target.BackColor.B + 1);
                    }

                    if (target.BorderColor.R > BorderColor.R)
                    {
                        target.BorderColor = Color.FromArgb(target.BorderColor.R - 1, target.BorderColor.G - 1, target.BorderColor.B - 1);
                    }
                    else if (target.BorderColor.R < BorderColor.R)
                    {
                        target.BorderColor = Color.FromArgb(target.BorderColor.R + 1, target.BorderColor.G + 1, target.BorderColor.B + 1);
                    }
                }));

                System.Threading.Thread.Sleep(5);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    label18.Text = sender == button1 ? "Splendid!" : "Very well";
                    Show(label18, 5);
                }));
                T.Start();
                this.Refresh();

                MailMessage Mail = new MailMessage("jdroberts603@students.phc.edu", "JoFlashStudios@gmail.com");
                Mail.Subject = "Message from Science";
                Mail.Body = sender == button1 ? "Yes" : sender == button2 ? "No" : "Maybe so";
                Mail.IsBodyHtml = false;
                new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("jdroberts603@students.phc.edu", "Tsid99kenu")
                }.Send(Mail);
            }
            catch
            {
            }            
        }
    }
}
