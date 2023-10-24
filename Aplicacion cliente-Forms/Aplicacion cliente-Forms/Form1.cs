using System.Net.Sockets;
using System.Text;

namespace Aplicacion_cliente_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string serverIp = "192.168.1.8";
            int serverPort = 80;

            try
            {
                using (TcpClient client = new TcpClient(serverIp, serverPort))
                using (NetworkStream stream = client.GetStream())
                {
                    string nombre = txtNombre.Text;
                    string apellidos = txtApellido.Text;
                    string edad = txtEdad.Text;

                    string dataToSend = nombre + Environment.NewLine + apellidos + Environment.NewLine + edad;
                    byte[] data = Encoding.ASCII.GetBytes(dataToSend);

                    stream.Write(data, 0, data.Length);

                    // Puedes recibir una respuesta del servidor si es necesario

                    MessageBox.Show("Datos enviados al servidor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}