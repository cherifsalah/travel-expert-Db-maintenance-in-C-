//Contain function that validate user entry before proceed to any operation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // any form controls

namespace ProjectWorkshop4CPRG200
{
    public static class Validator
    {
        // all methods in a static class are static

        /// <summary>
        /// tests if textbox has content
        /// </summary>
        /// <param name="tb">text box tested</param>
        /// <param name="name">name to use in error message</param>
        /// <returns>is it valid</returns>
        public static bool IsPresent(TextBox tb, string name)
        {
            bool valid = true; // "innocent until proven guilty"
            if (tb.Text == "")// empty
            {
                valid = false;
                MessageBox.Show(name + " has to be provided", "Error Detected in Input");
                tb.Focus();
            }
            return valid;
        }
        //Return true is user select an item in combobox
        public static bool IsSelected(ComboBox cb, string name)
        {
            bool valid = true; // "innocent until proven guilty"
            if (cb.Text == "")// empty
            {
                valid = false;
                MessageBox.Show(name + " has to be provided", "Error Detected in Input");
                cb.Focus();
            }
            return valid;
        }


        /// <summary>
        /// test if text box contains integer value
        /// </summary>
        /// <param name="tb">text box tested</param>
        /// <param name="name">name to use in error message</param>
        /// <returns>is it valid</returns>
        public static bool IsInteger(TextBox tb, string name)
        {
            bool valid = true;
            int value;
            if (!Int32.TryParse(tb.Text, out value)) // parse unsuccessful
            {
                valid = false;
                MessageBox.Show(name + " has to be a whole number", "Error Detected in Input");
                tb.SelectAll(); // select all content for replacement
                tb.Focus();
            }
            return valid;
        }

        /// <summary>
        /// test if text box contains double value
        /// </summary>
        /// <param name="tb">text box tested</param>
        /// <param name="name">name to use in error message</param>
        /// <returns>is it valid</returns>
        public static bool IsDouble(TextBox tb, string name)
        {
            bool valid = true;
            double value;
            if (!Double.TryParse(tb.Text, out value)) // parse unsuccessful
            {
                valid = false;
                MessageBox.Show(name + " has to be a decimal number", "Error Detected in Input");
                tb.SelectAll(); // select all content for replacement
                tb.Focus();
            }
            return valid;
        }

        /// <summary>
        /// test if text box contains non-negative integer value
        /// </summary>
        /// <param name="tb">text box tested</param>
        /// <param name="name">name to use in error message</param>
        /// <returns>is it valid</returns>
        public static bool IsNonNegativeInt(TextBox tb, string name)
        {
            bool valid = true;
            int value;
            if (!Int32.TryParse(tb.Text, out value)) // parse unsuccessful
            {
                valid = false;
                MessageBox.Show(name + " has to be a whole number", "Error Detected in Input");
                tb.SelectAll(); // select all content for replacement
                tb.Focus();
            }
            else // parsed correctly
            {
                if (value < 0)
                {
                    valid = false;
                    MessageBox.Show(name + " has to be positive or zero", "Error Detected in Input");
                    tb.SelectAll(); // select all content for replacement
                    tb.Focus();
                }
            }
            return valid;
        }

        /// <summary>
        /// test if text box contains non-negative double value
        /// </summary>
        /// <param name="tb">text box tested</param>
        /// <param name="name">name to use in error message</param>
        /// <returns>is it valid</returns>
        public static bool IsNonNegativeDouble(TextBox tb, string name)
        {
            bool valid = true;
            double value;
            if (!Double.TryParse(tb.Text, out value)) // parse unsuccessful
            {
                valid = false;

                MessageBox.Show(name + " has to be a decimal number", "Error Detected in Input");
                tb.SelectAll(); // select all content for replacement
                tb.Focus();
            }
            else // parsed correctly
            {
                if (value < 0)
                {
                    valid = false;
                    MessageBox.Show(name + " has to be positive or zero", "Error Detected in Input");
                    tb.SelectAll(); // select all content for replacement
                    tb.Focus();
                }
            }
            return valid;
        }

        /// <summary>
        /// test if text box contains non-negative decimal value
        /// </summary>
        /// <param name="tb">text box tested</param>
        /// <param name="name">name to use in error message</param>
        /// <returns>is it valid</returns>
        public static bool IsNonNegativeDecimal(TextBox tb, string name)
        {
            bool valid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) // parse unsuccessful
            {
                valid = false;
                MessageBox.Show(name + " has to be a decimal number", "Error Detected in Input");
                tb.SelectAll(); // select all content for replacement
                tb.Focus();
            }
            else // parsed correctly
            {
                if (value < 0)
                {
                    valid = false;
                    MessageBox.Show(name + " has to be positive or zero", "Error Detected in Input");
                    tb.SelectAll(); // select all content for replacement
                    tb.Focus();
                }
            }
            return valid;
        }
        
       
    } // class
} // namespace
