using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_calculator_attempt_2
{
    public partial class Form1 : Form
    {
        Double FirstNumber = 0;//inputan pertama
        Double result = 0;//hasil
        String Operation = "";//penanda jika ada isi atau belum
        bool OpClicked = false;//boolean sebagai penanda jika operator sudah di klik atau belum

        public Form1()
        {
            InitializeComponent();//void component designer
        }

        #region Numbers
        private void Numbers_ClickEvent(object sender, EventArgs e)//void jika salah sati tombol 0-9 ditekan
        {
            if (OpClicked)//jika OpClicked== true maka textbox akan ke clear dan OpClicked menjadi false lagi
            {
                ClearButton.PerformClick();//melakukan clickevent clearbutton
                OpClicked = false;//opclicked menjaid false
            }
            Button button = (Button)sender;//mengirim data Button yang di klik ke variable button
            if (button.Text == "," )//jika desimal
            {

                if (TextBoxInput.Text.Contains(","))//jika di textbox sudah ada desimal maka akan tidak bisa menambah desimal
                {

                }
                else if (TextBoxInput.Text == "")// jika user menginputkan dana ",2" di texbox akan muncul"0,2" 
                    TextBoxInput.Text = "0" + button.Text;//akan menampilkan 0,xxxx
                else
                    TextBoxInput.Text += button.Text;//TextBoxInput.Text += button.Text sama aja TextBoxInput.Text =TextBoxInput.Text + button.Text "+" fungsinya aja inputan sebelumnya tidak terhapus

            }
            else
                TextBoxInput.Text += button.Text;//TextBoxInput.Text += button.Text sama aja TextBoxInput.Text =TextBoxInput.Text + button.Text "+" fungsinya aja inputan sebelumnya tidak terhapus



        }
        private void EConstant(object sender, EventArgs e)//void jika tombol e ditekan
        {
            if (OpClicked)//jika OpClicked== true maka textbox akan ke clear dan OpClicked menjadi false lagi
            {
                ClearButton.PerformClick();//melakukan clickevent clearbutton
                OpClicked = false;//opclicked menjaid false
            }
            TextBoxInput.Text = "2,71828182846";// e=2,71828182846 maka ditextbox akan ditampilkan angka tersebut
        }

        private void PiConstant(object sender, EventArgs e)//void jika tombol e ditekan
        {
            if (OpClicked)//jika OpClicked== true maka textbox akan ke clear dan OpClicked menjadi false lagi
            {
                ClearButton.PerformClick();//melakukan clickevent clearbutton
                OpClicked = false;//opclicked menjaid false
            }
            TextBoxInput.Text = "3,14159265";// pi=3,14159265 maka ditextbox akan ditampilkan angka tersebut
        }

        #endregion

        #region Operators

        private void AddButton_Click(object sender, EventArgs e)//click event untuk operator tambah
        {
            MultipleOps();//jika operatornya berulang contoh ...+...+...-...*
            if (TextBoxInput.Text != "")//if ini fungsi nya operator tidak datang sebelum angka contoh nya "+2"
            {
                FirstNumber = Convert.ToDouble(TextBoxInput.Text);//angka pertama adalah angka yang pertama kali dimasukin textbox
                Operation = "add";//ditambahkan ini untuk tahu operasi apa yang digunakan
                OpClicked = true;//menandakan operator sudah di klik
            }
        }

        private void MinusButton_Click(object sender, EventArgs e)//click event untuk operator kurang
        {
            MultipleOps();// jika operatornya berulang contoh...+...+...-...*
            if (TextBoxInput.Text != "")//if ini fungsi nya operator tidak datang sebelum angka contoh nya "+2"
            {
                FirstNumber = Convert.ToDouble(TextBoxInput.Text);//angka pertama adalah angka yang pertama kali dimasukin textbox
                Operation = "min";//ditambahkan ini untuk tahu operasi apa yang digunakan
                OpClicked = true;//menandakan operator sudah di klik
            }
        }

        private void MultButton_Click(object sender, EventArgs e)//click event untuk operator kali
        {
            MultipleOps();// jika operatornya berulang contoh...+...+...-...*
            if (TextBoxInput.Text != "")//if ini fungsi nya operator tidak datang sebelum angka contoh nya "+2"
            {
                FirstNumber = Convert.ToDouble(TextBoxInput.Text);//angka pertama adalah angka yang pertama kali dimasukin textbox
                Operation = "mul";//ditambahkan ini untuk tahu operasi apa yang digunakan
                OpClicked = true;//menandakan operator sudah di klik
            }
        }

        private void DivButton_Click(object sender, EventArgs e)//click event untuk operator bagi
        {
            MultipleOps();// jika operatornya berulang contoh...+...+...-...*
            if (TextBoxInput.Text != "")//if ini fungsi nya operator tidak datang sebelum angka contoh nya "+2"
            {
                FirstNumber = Convert.ToDouble(TextBoxInput.Text);//angka pertama adalah angka yang pertama kali dimasukin textbox
                Operation = "div";//ditambahkan ini untuk tahu operasi apa yang digunakan
                OpClicked = true;//menandakan operator sudah di klik
            }
        }
        private void NegativeButton_Click(object sender, EventArgs e)//click event untuk operator bagi
        {
            if (TextBoxInput.Text != "")//if ini artinya jika textbox kosong maka tidak akan keluar tanda -
            {
                if (TextBoxInput.Text.Contains("-"))//jika sudah ada tanda maka tidak akan keluar tanda lagi (untuk mencega --2)
                { }
                else
                TextBoxInput.Text = "-" + TextBoxInput.Text;//jika tidak ada tanda maka akan keluar -x
                OpClicked = true;//menandakan operator ini sudah di klik
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)//click event untuk samadengan =
        {
            if (Operation != "")//jika textbox kosong maka clickevent ini dilewati
            {
                equals();//memanggil void equals
            }
        }


        #endregion

        #region Clearing

        private void ClearEntryButton_Click(object sender, EventArgs e)
        {
            TextBoxInput.Clear();
            result = 0;
            Operation = "";
            OpClicked = false;
            LabelOutput.Text = "";
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            TextBoxInput.Clear();
        }

        #endregion

        #region random voids
        void equals()//void untuk sama dengan
        {
            Double SecondNumber;//secondnumber adalah untuk inputan angka kedua 
            SecondNumber = Convert.ToDouble(TextBoxInput.Text);//convert fungsinya untuk merubah tipe data 
            TextBoxInput.Clear();//mengclearkan textbox
            LabelOutput.Text = "";//mengclearkan label
            switch (Operation)
            {
                case "add"://jika Operation=="add"
                    {
                        result = FirstNumber + SecondNumber;//rumus tambah
                        TextBoxInput.Text = Convert.ToString(result);//menapilkan di textbox
                        LabelOutput.Text = Convert.ToString(FirstNumber) + " + " + Convert.ToString(SecondNumber) + " = " + Convert.ToString(result);//menampilkan di label
                        break;//break aritnya switch case ini selesai
                    }
                case "min":
                    {
                        result = FirstNumber - SecondNumber;//rumus kurang
                        TextBoxInput.Text = Convert.ToString(result);//menampilkan di textbox
                        LabelOutput.Text = Convert.ToString(FirstNumber) + " - " + Convert.ToString(SecondNumber) + " = " + Convert.ToString(result);//menampilkan di label
                        break;//break artinya switch case ini selesai
                    }
                case "div":
                    {
                        result = FirstNumber / SecondNumber;//rumus kali
                        TextBoxInput.Text = Convert.ToString(result);//menampilkan di textbox
                        LabelOutput.Text = Convert.ToString(FirstNumber) + " / " + Convert.ToString(SecondNumber) + " = " + Convert.ToString(result);//menampilkan di label
                        break;//break artinya switch case ini selesai
                    }
                case "mul":
                    {
                        result = FirstNumber * SecondNumber;//rumus kali
                        TextBoxInput.Text = Convert.ToString(result);
                        LabelOutput.Text = Convert.ToString(FirstNumber) + " * " + Convert.ToString(SecondNumber) + " = " + Convert.ToString(result);//menampilkan di label
                        break;//break artinya switch case ini selesai
                    }
            }
        }
        void MultipleOps()//voud untuk banyak operasi
        {
            if (Operation != "")//untuk mencegah operasi duluan dari angka
            {
                equals();//memanggil void equals
            }
        }




        #endregion

       #test
    }
}
