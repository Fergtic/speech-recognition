using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Media;

namespace rego_speech_recognition
{ 


    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //port.Open();
            //port.Write("B");
            Choices commands = new Choices();
            commands.Add(new string[] { "no", "crap", "damn" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            richTextBox1.Text += "\nyeet";

        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "no":
                    //port.Write("A");
                    //System.Threading.Thread.Sleep(1000);
                    //port.Write("B");
                    richTextBox1.Text += "\nyeet";
                    break;

                case "crap":
                    SoundPlayer fog_siren = new SoundPlayer(@"C:\Users\Fergu\Downloads\foghorn-daniel_simon.wav");
                    fog_siren.Play();
                    //port.Write("A");
                    //System.Threading.Thread.Sleep(1000);
                    //port.Write("B");
                    richTextBox1.Text += "\nyeet";
                    break;

                case "damn":
                    //port.Write("A");
                    //System.Threading.Thread.Sleep(1000);
                    //port.Write("B");
                    richTextBox1.Text += "\ndamn";
                    break;

                
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnDisable.Enabled = true;
            btnEnable.Enabled = false;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
            btnEnable.Enabled = true;
        }
    }
}
