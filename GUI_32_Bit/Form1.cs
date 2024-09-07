

namespace GUI_32_Bit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Textboxes

        private void label_textbox_TextChanged(object sender, EventArgs e)
        {
            Convert.ToInt32(label_textbox.Text, 8);
        }


        private void value_textbox_TextChanged(object sender, EventArgs e)
        {
            Convert.ToDecimal(value_textbox.Text);
        }

        private void startbit_textbox_TextChanged(object sender, EventArgs e)
        {
            Convert.ToInt32(startbit_textbox.Text, 10);
        }

        private void scale_factor_textbox_TextChanged(object sender, EventArgs e)
        {
            Convert.ToDecimal(scale_factor_textbox.Text);
        }



        //Comboboxes

        private void sdi_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Convert.ToInt32(sdi_combobox.SelectedItem);
        }

        private void ssm_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Convert.ToInt32(ssm_combobox.SelectedItem);
        }

        private void parity_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Convert.ToInt32(ssm_combobox.SelectedItem);
        }

        private void generate_message_button_Click(object sender, EventArgs e)
        {
            Int32 label = Convert.ToInt32(label_textbox.Text, 8);
            Int32 sdi = sdi_combobox.SelectedIndex;
            Decimal value = Convert.ToDecimal(value_textbox.Text);
            Int32 ssm = ssm_combobox.SelectedIndex;
            Int32 parity = parity_combobox.SelectedIndex;
            Int32 startBit = Convert.ToInt32(startbit_textbox.Text);
            Decimal scaleFactor = Convert.ToDecimal(scale_factor_textbox.Text);

            //Debug
            System.Diagnostics.Debug.WriteLine($"Label Value: {label}");
            System.Diagnostics.Debug.WriteLine($"Sdi Value: {sdi}");
            System.Diagnostics.Debug.WriteLine($"Decimal Value: {value}");
            System.Diagnostics.Debug.WriteLine($"Ssm Value: {ssm}");
            System.Diagnostics.Debug.WriteLine($"Parity Value: {parity}");
            System.Diagnostics.Debug.WriteLine($"Start Bit Value: {startBit}");
            System.Diagnostics.Debug.WriteLine($"Scale Factor Value: {scaleFactor}");



            //Determines data value
            Int32 data = (Int32)(value / scaleFactor);

            Int32 message = label;
            message = message | (sdi << 8); //Sets sdi to be at the 8th bit.
            message = message | (data << (startBit - 1)); //Minus 1 to account for bits starting at 1 instead of 0.
            message = message | (ssm << 29);
            message = message | (parity << 31);

            //Debug
            string messageDec = "Message(dec): " + message.ToString() + "\n\n";
            string messageHex = "Message(hex): " + message.ToString("X") + "\n\n";
            System.Diagnostics.Debug.Write(messageDec);
            System.Diagnostics.Debug.Write(messageHex);

            MessageBox.Show(messageHex + messageDec);


        }
    }
}
