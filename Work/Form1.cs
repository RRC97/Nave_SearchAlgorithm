using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work
{
    public partial class Form1 : Form
    {
        private int total;
        private int[] elements;
        public Form1()
        {
            InitializeComponent();

            total = 1000;

            elements = CreateElements();
            SelectionSort(ref elements);
            SetOnListBox();
        }

        int[] CreateElements()
        {
            Random rand = new Random();
            List<int> listElement = new List<int>();
            for (int i = 0; i < total; i++)
            {
                listElement.Add(rand.Next(total * 2));
            }

            return listElement.ToArray();
        }

        void SelectionSort(ref int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        void SetOnListBox()
        {
            foreach(int element in elements)
            {
                listBoxElements.Items.Add(element);
            }
        }

        void repart(out int[] left, out int[] right, int[] array)
        {
            left = new int[array.Length / 2];
            right = new int[array.Length - left.Length];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = array[i + left.Length];
            }
        }

        void BinarySearch(int[] array, int value)
        {
            int[] leftPart, rightPart;
            int[] part = array;
            repart(out leftPart, out rightPart, part);
            int pointer = array.Length / 2;
            int pointerPart = pointer;
            while (part[pointerPart] != value)
            {
                Console.WriteLine("Pointer global: " + pointer + ", Pointer local: " + pointerPart);
                
                if (part[pointerPart] > value)
                {
                    pointerPart = leftPart.Length / 2;
                    part = leftPart;
                    repart(out leftPart, out rightPart, part);
                }
                else if (part[pointerPart] < value)
                {
                    pointerPart = rightPart.Length / 2;
                    part = rightPart;
                    repart(out leftPart, out rightPart, part);
                }
                pointer = array.ToList<int>().IndexOf(part[pointerPart]);
            }
            Console.WriteLine("Pointer global: " + pointer + ", Pointer local: " + pointerPart);

            MessageBox.Show("A posição do elemento é em " + (pointer + 1) + "º lugar", "Resultado");
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            int value = -1;
            if (int.TryParse(textBoxFind.Text, out value))
                if (elements.Contains<int>(value))
                    BinarySearch(elements, value);
                else 
                    MessageBox.Show("Este número não contém na lista", "Erro");
            else 
                MessageBox.Show("Por favor, digite somente números", "Erro");
        }
    }
}
