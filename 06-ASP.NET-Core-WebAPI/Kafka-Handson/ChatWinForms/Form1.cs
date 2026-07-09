using Confluent.Kafka;

namespace ChatWinForms
{
    public partial class Form1 : Form
    {
        ProducerConfig config =
            new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            using var producer =
                new ProducerBuilder<Null, string>(config).Build();

            await producer.ProduceAsync(
                "chat-message",
                new Message<Null, string>
                {
                    Value = txtMessage.Text
                });

            MessageBox.Show("Message Sent");
        }
    }
}
