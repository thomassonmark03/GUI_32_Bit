

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

            //Combobox error handling, only error that can be generated is if none is selected.
            bool sdi_no_select = sdi_combobox.SelectedItem == null;
            bool ssm_no_select = ssm_combobox.SelectedItem == null;
            bool parity_no_select = parity_combobox.SelectedItem == null;

            //Textbox error handling, there is an error if the text in the error label is not No Error
            bool label_error = !String.Equals(label_error_label.Text, "No Error");
            bool value_error = !String.Equals(value_error_label.Text, "No Error");
            bool startBit_error = !String.Equals(start_bit_error_label.Text, "No Error");
            bool scaleFactor_error = !String.Equals(scale_factor_error_label.Text, "No Error");



            //Generate a pop up error message, if there are no errors, it will be empty.
            string generate_message_error_string = "";


            //If there is a label error, tell the user, and add the error text.
            if(label_error)
            {
                generate_message_error_string += "Label Error: " + label_error_label.Text + "\n";
            }

            //If there a SDI error, tell the user they need to select a SDI.
            if (sdi_no_select)
            {
                generate_message_error_string += "SDI Error: No Selection\n";
            }

            //If there is a value error, tell the user, and add the error text.
            if (value_error)
            {
                generate_message_error_string += "Value Error: " + value_error_label.Text + "\n";
            }

            //If there is an SSM error, tell the user they need to select a SSM.
            if (ssm_no_select)
            {
                generate_message_error_string += "SSM Error: No Selection\n";
            }

            //If there is a parity error, tell the user they need to select a parity.
            if (parity_no_select)
            {
                generate_message_error_string += "Parity Error: No Selection\n";
            }


            //If there is a start bit error, tell the user, and add the error text.
            if (startBit_error)
            {
                generate_message_error_string += "Start bit error:" + start_bit_error_label.Text + "\n";
            }

            //If there is a scale factor error, tell the user, and add the error text.
            if (scaleFactor_error)
            {
                generate_message_error_string += "Scale factor error:" + scale_factor_error_label.Text + "\n";
            }


            //Out of bounds for scale factor and value factor multiplied
            if( !(value_error || scaleFactor_error || startBit_error) )
            {
                Decimal scaleFactor = Convert.ToDecimal(scale_factor_textbox.Text);
                Decimal value = Convert.ToDecimal(value_textbox.Text);
                Int32 startBit = Convert.ToInt32(startbit_textbox.Text) - 11;


                //Find how many bits is available for the data to fit in. 
                //This will determine how big data can get before it overflows, thus the value ceiling.
                Int32 bitSpace = 19 - startBit;
                Int32 valueCeiling = 1 << (bitSpace);

                Int32 totalValue = (Int32)(value / scaleFactor);

                //If the value and scale factor overflow, tell the user the value generated by the two.
                //As well as what bit constraints and value constraints they are working under.
                if(totalValue >= valueCeiling)
                {
                    generate_message_error_string += $"Error, value divided by scale factor is: {totalValue}\n";
                    generate_message_error_string += $"Value bit space is {bitSpace} bits\n";
                    generate_message_error_string += $"Thus value must be under {valueCeiling}\n";
                }




            }

            //If the generate message error is not empty, there was an error, and it should be displayed instead of generating the hex and decimal.
            if ( !( String.IsNullOrEmpty( generate_message_error_string) ) )
            {
                MessageBox.Show(generate_message_error_string);
            }
            else
            {
                    //Get all the values out of the textboxes and combo boxes.
                    Int32 label = Convert.ToInt32(label_textbox.Text, 8);
                    Decimal value = Convert.ToDecimal(value_textbox.Text);
                    Int32 startBit = Convert.ToInt32(startbit_textbox.Text);
                    Decimal scaleFactor = Convert.ToDecimal(scale_factor_textbox.Text);

                    Int32 sdi = sdi_combobox.SelectedIndex;
                    Int32 ssm = ssm_combobox.SelectedIndex;
                    Int32 parity = parity_combobox.SelectedIndex;





                    //Debug, you can see the values gotten in the output terminal.
                    System.Diagnostics.Debug.WriteLine($"Label Value: {label}");
                    System.Diagnostics.Debug.WriteLine($"Sdi Value: {sdi}");
                    System.Diagnostics.Debug.WriteLine($"Decimal Value: {value}");
                    System.Diagnostics.Debug.WriteLine($"Ssm Value: {ssm}");
                    System.Diagnostics.Debug.WriteLine($"Parity Value: {parity}");
                    System.Diagnostics.Debug.WriteLine($"Start Bit Value: {startBit}");
                    System.Diagnostics.Debug.WriteLine($"Scale Factor Value: {scaleFactor}");



                    //Determines data value
                    Int32 data = (Int32)(value / scaleFactor);

                    //Construct the 32 bit message.
                    //Label will be in bits 0 to 7
                    //SDI will be in bits 8 to 9
                    //Data will be in bits 10 to 28, bit shifted up by start bit -1 (1 indexing)
                    //SSM will be in bits 29 to 30
                    //Parity will be in bits 31.
                    Int32 message = label;
                    message = message | (sdi << 8); //Sets sdi to be at the 8th bit.
                    message = message | (data << (startBit - 1)); //Minus 1 to account for bits starting at 1 instead of 0.
                    message = message | (ssm << 29);
                    message = message | (parity << 31);

                    //Construct the decimal and hex messages to be displayed.
                    string messageDec = "Message(dec): " + message.ToString() + "\n\n";
                    string messageHex = "Message(hex): " + message.ToString("X") + "\n\n";

                    //Debug
                    System.Diagnostics.Debug.Write(messageDec);
                    System.Diagnostics.Debug.Write(messageHex);

                    //Show the decimal and hex messages.
                    MessageBox.Show(messageHex + messageDec);
            
            }


        }


        //Textbox error handling

        //Handles the errors that occur when the label in the label textbox changes.
        private void label_textbox_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //Checks to see if there is nothing in the textbox.
                if (!(string.IsNullOrEmpty(label_textbox.Text)))
                {
                    //Checks to see if the all the values in octal are characters.
                    //This helps detect alphabetical characters and negative signs.
                    if (label_textbox.Text.All(Char.IsDigit))
                    {
                        Int32 label_oct = Convert.ToInt32(label_textbox.Text, 8);

                        //If the label value exceeds 8 bits, set the error, otherwise, the value is valid.
                        //If the value is valid, set the error to no error.
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
                    //If the label is empty, set the error. Do not show.
                    label_error_label.Text = "Label is empty";
                    label_error_label.Visible = false;
                }

            }
            catch (ArgumentOutOfRangeException err)
            {
                //Should never happen, but if an exception is thrown cause the label is empty, this will be caught here. Should be handled
                //above.
                label_error_label.Text = "Label is empty";
            }
            catch (FormatException err)
            {
                //Format errors typically result in invalid characters.
                //For octal, this is values higher than 8.
                //It could also be negatives.
                //It could also be alphabetical characters.
                label_error_label.Text = "Invalid character detected";
                label_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                //Overflow exceptions happen when the value exceeds an int 32, which is accounted for here.
                label_error_label.Text = "Overflow detected(outside int 32 range)";
                label_error_label.Visible = true;
            }

        }

        //Handles the errors that occur when value in the value textbox changes.
        private void value_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Checks to see if the value is empty.
                if (!(string.IsNullOrEmpty(value_textbox.Text)))
                {
                    Decimal value = Convert.ToDecimal(value_textbox.Text);
                    
                    //Calculate how many bits value has to fit inside using start bit.
                    //This determines the maximum value, value can be.
                    Int32 startBit = 0;
                    if (String.Equals(start_bit_error_label.Text, "No Error"))
                    {
                        startBit = Convert.ToInt32(startbit_textbox.Text) - 11;
                    }
                    Int32 bitSpace = 19 - startBit;
                    Int32 valueCeiling = 1 << (bitSpace);

                    //If value exceeds the bits it is given, tell the user how many bits they have and what value they should be under.
                    if (value >= valueCeiling)
                    {
                        value_error_label.Text = $"Overflow detected(past {bitSpace} bits,\nvalue must not exceed {valueCeiling})";
                        value_error_label.Visible = true;
                    }
                    //If the value is negative, set the error text and tell the user.
                    else if (value < 0)
                    {
                        value_error_label.Text = "Value cannot be negative";
                        value_error_label.Visible = true;
                    }
                    //Otherwise, value is okay! Set the error to no error.
                    else
                    {
                        value_error_label.Text = "No Error";
                        value_error_label.Visible = false;
                    }
                }
                else
                {
                    //If it is empty, set the error. Do not show.
                    value_error_label.Text = "Value is empty";
                    value_error_label.Visible = false;
                }
            }
            catch (ArgumentOutOfRangeException err)
            {
                //Should never happen, but if an exception is thrown cause the value is empty, this will be caught here. Should be handled
                //above.
                value_error_label.Text = "Value is empty";
            }
            catch (FormatException err)
            {
                //Format errors typically result in invalid characters.
                //For decimal, this could be negatives.
                //It could also be alphabetical characters.
                value_error_label.Text = "Invalid character detected";
                value_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                //This error only occurs if the huge decimal range is exceeded, this will be caught here.
                value_error_label.Text = "Overflow detected(outside decimal range)";
                value_error_label.Visible = true;
            }
        }

        //Handles the errors that occur when start bit in the start bit textbox changes.
        private void startbit_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Checks to see if the startbit textbox is empty.
                if (!(string.IsNullOrEmpty(startbit_textbox.Text)))
                {
                    Int32 startBit = Convert.ToInt32(startbit_textbox.Text);

                    //If the start bit value is not between 11 and 29, set the error and tell the user.
                    //Otherwise, the startbit value is okay! Set the error to no error.
                    if (!(startBit >= 11 && startBit <= 29))
                    {
                        start_bit_error_label.Text = "Start bit must be between 11 to 29";
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
                    //If it is empty, set the error to empty. Do not show.
                    start_bit_error_label.Text = "Start bit is empty";
                    start_bit_error_label.Visible = false;
                }

            }
            catch (ArgumentOutOfRangeException err)
            {
                //Should never occur, but this exception could be thrown if start bit is empty.
                start_bit_error_label.Text = "Start bit is empty";
            }
            catch (FormatException err)
            {
                //This catches all the errors given when a user types an invalid character for start bit.
                //An invalid character is any character other than numbers.
                start_bit_error_label.Text = "Invalid character detected";
                start_bit_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                //This catches errors that occur when converting an int32 that exceeds the range of an int32.
                start_bit_error_label.Text = "Overflow detected(outside int 32 range)";
                start_bit_error_label.Visible = true;
            }
        }

        //Handles the errors that occur when scale factor in the scale factor textbox changes.
        private void scale_factor_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Checks to see if scale factor is empty.
                if (!(string.IsNullOrEmpty(scale_factor_textbox.Text)))
                {
                    Decimal scaleFactor = Convert.ToDecimal(scale_factor_textbox.Text);

                    //Checks to see if the scale factor is negative.
                    //If it is tell the user.
                    //Otherwise, it is a valid scale factor! Set the error to no error.
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
                else
                {
                    //If it is empty, set the error to empty. Do not show.
                    scale_factor_error_label.Text = "Scale factor is empty";
                    scale_factor_error_label.Visible = false;
                }
            }
            catch (ArgumentOutOfRangeException err)
            {
                //Should not occur, this handles the error that occurs when the scale factor is empty.
                scale_factor_error_label.Text = "Value is empty";

            }
            catch (FormatException err)
            {
                //Handles the errors that occur when a non-numeric character is entered for the scale factor.
                scale_factor_error_label.Text = "Invalid character detected";
                scale_factor_error_label.Visible = true;
            }
            catch (OverflowException err)
            {
                //This handles the error that occurs when the value put into scale factor exceeds the decimal value.
                scale_factor_error_label.Text = "Overflow detected(outside decimal range)";
                scale_factor_error_label.Visible = true;
            }
        }


    }
}
