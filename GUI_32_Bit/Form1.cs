

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

            //Combobox error handling
            bool sdi_no_select = sdi_combobox.SelectedItem == null;
            bool ssm_no_select = ssm_combobox.SelectedItem == null;
            bool parity_no_select = parity_combobox.SelectedItem == null;

            //Textbox error handling
            bool label_error = !String.Equals(label_error_label.Text, "No Error");
            bool value_error = !String.Equals(value_error_label.Text, "No Error");
            bool startBit_error = !String.Equals(start_bit_error_label.Text, "No Error");
            bool scaleFactor_error = !String.Equals(scale_factor_error_label.Text, "No Error");



            //Generate a pop up error message
            string generate_message_error_string = "";

            if(label_error)
            {
                generate_message_error_string += "Label Error: " + label_error_label.Text + "\n";
            }

            if (sdi_no_select)
            {
                generate_message_error_string += "SDI Error: No Selection\n";
            }

            if(value_error)
            {
                generate_message_error_string += "Value Error: " + value_error_label.Text + "\n";
            }

            if (ssm_no_select)
            {
                generate_message_error_string += "SSM Error: No Selection\n";
            }

            if (parity_no_select)
            {
                generate_message_error_string += "Parity Error: No Selection\n";
            }

            if (startBit_error)
            {
                generate_message_error_string += "Start bit error:" + start_bit_error_label.Text + "\n";
            }

            if (scaleFactor_error)
            {
                generate_message_error_string += "Scale factor error:" + scale_factor_error_label.Text + "\n";
            }


            //Out of bounds for scale factor and value factor multiplied
            if( !(value_error && scaleFactor_error && startBit_error) )
            {
                Decimal scaleFactor = Convert.ToDecimal(scale_factor_textbox.Text);
                Decimal value = Convert.ToDecimal(value_textbox.Text);
                Int32 startBit = Convert.ToInt32(startbit_textbox.Text) - 14;

                Int32 bitSpace = 19 - startBit;
                Int32 valueCeiling = 1 << (bitSpace);

                Int32 totalValue = (Int32)(value / scaleFactor);

                if(totalValue >= valueCeiling)
                {
                    generate_message_error_string += $"Error, value divided by scale factor is: {totalValue}\n";
                    generate_message_error_string += $"Value bit space is {bitSpace} bits\n";
                    generate_message_error_string += $"Thus value must be under {valueCeiling}\n";
                }




            }


            if ( !( String.IsNullOrEmpty( generate_message_error_string) ) )
            {
                MessageBox.Show(generate_message_error_string);
            }
            else
            {
                    Int32 label = Convert.ToInt32(label_textbox.Text, 8);
                    Decimal value = Convert.ToDecimal(value_textbox.Text);
                    Int32 startBit = Convert.ToInt32(startbit_textbox.Text);
                    Decimal scaleFactor = Convert.ToDecimal(scale_factor_textbox.Text);

                    Int32 sdi = sdi_combobox.SelectedIndex;
                    Int32 ssm = ssm_combobox.SelectedIndex;
                    Int32 parity = parity_combobox.SelectedIndex;





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
