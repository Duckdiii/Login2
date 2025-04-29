using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Day2
{
    public partial class AddContactForm : Form
    {
        Contact contact = new Contact();
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void AddContact_btn_Click(object sender, EventArgs e)
        {
            string ContactFname = ContactFirstName_textBox.Text;
            string ContactLname = ContactLastName_textBox.Text;
            string ContactPhone = ContactPhone_textBox.Text;
            string ContactEmail = ContactEmail_textBox.Text;
            string ContactAddress = ContactAddress_richTextBox.Text;
            string ContactGroup = ContactGroup_comboBox.Text;
            int ContactID = Convert.ToInt32(ContactID_textBox.Text);

            Contact_pictureBox.Image = Contact_pictureBox.Image;
            contact.insertContact(ContactID, ContactFname, ContactLname, ContactGroup, ContactPhone, ContactEmail, ContactAddress, Contact_pictureBox.Image);
        }
    }
}
