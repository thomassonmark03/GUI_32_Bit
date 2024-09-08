

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

        private void generate_message_button_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
            }


        }


        //Textbox error handling
        private void label_textbox_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (!(string.IsNullOrEmpty(label_textbox.Text)))
                {
                    if (label_textbox.Text.All(Char.IsDigit))
                    {
                        Int32 label_oct = Convert.ToInt32(label_textbox.Text, 8);
                        if (label_oct >= 256)
                        {
                            label_error_label.Text = "Overflow detected(past 8 bits)";
                            label_error_label.Visible = true;
                        }
                        else
                        {
                            label_error_label.Text = "No Error";
                            label_error_label.Visible = false;

                        }
                    }
                    else
                    {
                        label_error_label.Text = "Invalid character detected";
                        label_error_label.Visible = true;
                    }
                }
                else
                {
                    label_error_label.Text = "Label is empty";
                    label_error_label.Visible = false;
                }

            }
            catch (ArgumentOutOfRangeException err)
            {
                label_error_label.Text = "Label is empty";
            }
            catch (FormatException err)
            {
                label_error_label.Text = "Invalid character detected";
                label_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                label_error_label.Text = "Overflow detected(outside int 32 range)";
                label_error_label.Visible = true;
            }

        }

        private void value_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(value_textbox.Text)))
                {
                    Decimal value = Convert.ToDecimal(value_textbox.Text);
                    Int32 startBit = 0;

                    if (String.Equals(start_bit_error_label.Text, "No Error"))
                    {
                        startBit = Convert.ToInt32(startbit_textbox.Text) - 14;
                    }
                    Int32 bitSpace = 19 - startBit;
                    Int32 valueCeiling = 1 << (bitSpace);

                    if (value >= valueCeiling)//Only 19 bits given
                    {
                        value_error_label.Text = $"Overflow detected(past {bitSpace} bits)";
                        value_error_label.Visible = true;
                    }
                    else if (value < 0)
                    {
                        value_error_label.Text = "Value cannot be negative";
                        value_error_label.Visible = true;
                    }
                    else
                    {
                        value_error_label.Text = "No Error";
                        value_error_label.Visible = false;
                    }
                }
                else
                {
                    value_error_label.Text = "Value is empty";
                    value_error_label.Visible = false;
                }
            }
            catch (ArgumentOutOfRangeException err)
            {
                value_error_label.Text = "Value is empty";
            }
            catch (FormatException err)
            {
                value_error_label.Text = "Invalid character detected";
                value_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                value_error_label.Text = "Overflow detected(outside decimal range)";
                value_error_label.Visible = true;
            }
        }

        private void startbit_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(startbit_textbox.Text)))
                {
                    Int32 startBit = Convert.ToInt32(startbit_textbox.Text);
                    if (!(startBit >= 14 && startBit <= 29))
                    {
                        start_bit_error_label.Text = "Start bit must be between 14 to 29";
                        start_bit_error_label.Visible = true;
                    }
                    else
                    {
                        start_bit_error_label.Text = "No Error";
                        start_bit_error_label.Visible = false;
                    }
                }
                else
                {
                    start_bit_error_label.Text = "Start bit is empty";
                    start_bit_error_label.Visible = false;
                }

            }
            catch (ArgumentOutOfRangeException err)
            {
                start_bit_error_label.Text = "Start bit is empty";
            }
            catch (FormatException err)
            {
                start_bit_error_label.Text = "Invalid character detected";
                start_bit_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                start_bit_error_label.Text = "Overflow detected(outside int 32 range)";
                start_bit_error_label.Visible = true;
            }
        }

        private void scale_factor_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(scale_factor_textbox.Text)))
                {
                    Decimal scaleFactor = Convert.ToDecimal(scale_factor_textbox.Text);
                    if (scaleFactor < 0)
                    {
                        scale_factor_error_label.Text = "Value cannot be negative";
                        scale_factor_error_label.Visible = true;
                    }
                    else
                    {
                        scale_factor_error_label.Text = "No Error";
                        scale_factor_error_label.Visible = false;
                    }
                }
            }
            catch (ArgumentOutOfRangeException err)
            {
                scale_factor_error_label.Text = "Value is empty";

            }
            catch (FormatException err)
            {
                scale_factor_error_label.Text = "Invalid character detected";
                scale_factor_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                scale_factor_error_label.Text = "Overflow detected(outside decimal range)";
                scale_factor_error_label.Visible = true;
            }
        }


    }
}
