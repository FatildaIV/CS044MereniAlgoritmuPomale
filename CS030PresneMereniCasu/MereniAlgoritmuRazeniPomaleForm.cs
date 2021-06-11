using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace CS031MereniAlgoritmuProhozeni
{
    public partial class MereniAlgoritmuProhozeniForm : Form
    {
        public MereniAlgoritmuProhozeniForm()
        {
            InitializeComponent();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            StopkyTestDateTime();
            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(Environment.NewLine);
            StopkyTestHighResolutionDateTime();
            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(Environment.NewLine);
            StopkyTestStopwatchHashSet();
            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(Environment.NewLine);
            StopkyTestStopwatch();
            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(Environment.NewLine);
            StopkyTestStopwatchDrift();
            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(Environment.NewLine);
        }

        private void StopkyTestDateTime()
        {

            vystupTextBox.AppendText("Testing DateTime for 1 seconds...");

            var distinctValues = new HashSet<DateTime>();
            var sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < 1)
            {
                distinctValues.Add(DateTime.UtcNow);
            }

            sw.Stop();

            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(
                string.Format(
                    "Precision: {0:0.000000} ms ({1} samples)",
                    sw.Elapsed.TotalMilliseconds / distinctValues.Count,
                    distinctValues.Count));

        }

        private void StopkyTestHighResolutionDateTime()
        {

            vystupTextBox.AppendText("Testing High Resolution DateTime for 1 seconds...");

            var distinctValues = new HashSet<DateTime>();
            var sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < 1)
            {
                distinctValues.Add(HighResolutionDateTime.UtcNow);
            }

            sw.Stop();

            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(
                string.Format(
                    "Precision: {0:0.000000} ms ({1} samples)",
                    sw.Elapsed.TotalMilliseconds / distinctValues.Count,
                    distinctValues.Count));

        }

        private void StopkyTestStopwatchHashSet()
        {

            vystupTextBox.AppendText("Testing Stopwatch for 1 seconds...");

            var distinctValues = new HashSet<long>();
            var sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < 1)
            {
                distinctValues.Add(sw.ElapsedTicks);
            }

            sw.Stop();

            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(
                string.Format(
                    "Resolution: {0:0.000000} ms ({1} samples)",
                    sw.Elapsed.TotalMilliseconds / distinctValues.Count,
                    distinctValues.Count));

        }

        private void StopkyTestStopwatch()
        {

            vystupTextBox.AppendText("Testing Stopwatch for 1 seconds...");

            var sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < 1)
            {

            }

            sw.Stop();

            vystupTextBox.AppendText(Environment.NewLine);
            vystupTextBox.AppendText(
                string.Format(
                    "Resolution: {0:0.000000} ms ({1} samples)",
                    sw.Elapsed.TotalMilliseconds / sw.ElapsedTicks,
                    sw.ElapsedTicks));

        }

        private void StopkyTestStopwatchDrift()
        {
            var start = HighResolutionDateTime.UtcNow;
            var sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < 10)
            {
                DateTime nowBasedOnStopwatch = start + sw.Elapsed;
                TimeSpan diff = HighResolutionDateTime.UtcNow - nowBasedOnStopwatch;

                vystupTextBox.AppendText(string.Format("Stopwatch to UTC drift: {0:0.000000} ms", diff.TotalMilliseconds));
                vystupTextBox.AppendText(Environment.NewLine);

                Thread.Sleep(1000);
            }
        }
        private void ProhoditPromenna<T>(ref T a, ref T b)
        {
            T pom = a;
            a = b;
            b = pom;
        }

        private static void StaticProhoditPromenna<T>(ref T a, ref T b)
        {
            T pom = a;
            a = b;
            b = pom;
        }
        private void ProhoditPromenna(ref int a, ref int b)
        {
            int pom = a;
            a = b;
            b = pom;
        }
        public delegate void ProceduraProhozeni(ref int a, ref int b);

        private long OpakovatProhozeni(ProceduraProhozeni proceduraProhozeni, int n)
        {
            var sw = Stopwatch.StartNew();
            int a = 1;
            int b = 2;
            for (int i = 0; i < n; i++)
            {
                proceduraProhozeni(ref a, ref b);
            }
            return sw.ElapsedMilliseconds;
        }
        private void MeritProhozeni(int max)
        {
            VytizitProcesor();
            string vypis = "Prohození s pomocnou proměnnou {1}x: {0:0.000000} ms";
            vypis = "{0};{1:0.000000};{2:0.000000};{3:0.000000}";
            for (int i = 1; i < max; i *= 10)
            {

                vystupTextBox.AppendText(
                    string.Format(
                        vypis,
                        i,
                         OpakovatProhozeni(ProhoditPromenna, i),
                         OpakovatProhozeni(ProhoditPromenna<int>, i),
                         OpakovatProhozeni(StaticProhoditPromenna<int>, i)));


                vystupTextBox.AppendText(Environment.NewLine);

            }
        }

        private void meritProhozeniButton_Click(object sender, EventArgs e)
        {
            MeritProhozeni(100000000);
        }
        private void VytizitProcesor()
        {
            OpakovatProhozeni(ProhoditPromenna, 100000000);
        }

        private void MereniAlgoritmuProhozeniForm_Load(object sender, EventArgs e)
        {

        }
        // metoda potvrdí zda pole je seřazeno zadaným způsobem, nebo neseřazeno

        static Razeni PoleRazeni<T>(T[] pole)
        {
            bool vzestupne = true, sestupne = true;

            for (int i = 0; i < pole.Length - 1; i++)
            {
                vzestupne = vzestupne && ((dynamic)pole[i] <= (dynamic)pole[i + 1]);
                sestupne = sestupne && ((dynamic)pole[i] >= (dynamic)pole[i + 1]);

            }
            return (vzestupne && sestupne) ? Razeni.Serazeno :
                   (!vzestupne && !sestupne) ? Razeni.Neserazeno :
                   (vzestupne) ? Razeni.Vzestupne :
                   Razeni.Sestupne;
        }

        public enum Razeni
        {
            Neserazeno,
            Serazeno,
            Sestupne,
            Vzestupne
        }
        static void BubbleSort<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            p.Minimum = 0;
            p.Maximum = 1000;
            p.Value = 0;

            for (int i = 0; i < pole.Length; i++)
            {
                for (int j = 0; j < pole.Length - 1; j++)
                {

                    bool podminka = ((dynamic)pole[j] < (dynamic)pole[j + 1]);

                    if (razeni == Razeni.Sestupne ? podminka : !podminka)
                    {
                        StaticProhoditPromenna<T>(ref pole[j], ref pole[j + 1]);

                    }

                }
                p.Value = (int)(i / (double)(pole.Length - 1) * p.Maximum);
                p.Refresh();
                // MessageBox.Show("Aktualizace");
            }
        }

        static void SelectionSort<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            for (int i = 0; i < pole.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i; j < pole.Length; j++)
                {
                    bool podminka = ((dynamic)pole[j] < (dynamic)pole[minIndex]);

                    if (razeni == Razeni.Sestupne ? podminka : !podminka)
                    {
                        minIndex = j;
                    }
                }
                StaticProhoditPromenna<T>(ref pole[i], ref pole[minIndex]);
            }
        }
        static void InsertionSort<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            for (int i = 0; i < pole.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    bool podminka = ((dynamic)pole[j - 1] > (dynamic)pole[j]);
                    bool prohodit = (razeni == Razeni.Sestupne ? podminka : !podminka);

                    if (prohodit)
                    {
                        StaticProhoditPromenna<T>(ref pole[j - 1], ref pole[j]);
                    }
                }
            }

        }

        static void InsertionSort2<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            for (int i = 0; i < pole.Length - 1; i++)
            {
                bool prohodit, podminka;
                int j = i + 1;

                podminka = ((dynamic)pole[j - 1] > (dynamic)pole[j]);
                prohodit = (razeni == Razeni.Sestupne ? podminka : !podminka) && j > 0;

                while (prohodit)
                {
                    StaticProhoditPromenna<T>(ref pole[j - 1], ref pole[j]);
                    j--;

                    if (j > 0)
                    {
                        podminka = ((dynamic)pole[j - 1] > (dynamic)pole[j]);
                        prohodit = (razeni == Razeni.Sestupne ? podminka : !podminka) && j > 0;
                    }
                    else
                    {
                        prohodit = false;
                    }

                }
            }

        }

        static void InsertionSort3<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            for (int i = 0; i < pole.Length - 1; i++)
            {
                bool prohodit, podminka;
                int j = i + 1;


                T vkladanaHodnota = pole[j];
                podminka = ((dynamic)vkladanaHodnota < (dynamic)pole[j - 1]);
                prohodit = (razeni == Razeni.Vzestupne ? podminka : !podminka) && j > 0;

                while (prohodit)
                {
                    //StaticProhoditPromenna<T>(ref pole[j - 1], ref pole[j]);

                    pole[j] = pole[j - 1];
                    j--;

                    if (j > 0)
                    {
                        podminka = ((dynamic)vkladanaHodnota < (dynamic)pole[j - 1]);
                        prohodit = (razeni == Razeni.Vzestupne ? podminka : !podminka) && j > 0;

                    }
                    else
                    {
                        prohodit = false;
                    }

                }

                pole[j] = vkladanaHodnota;
            }

        }

        static void InsertionSort4<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            bool prohodit;
            for (int i = 0; i < pole.Length - 1; i++)
            {
                int j = i + 1;


                T vkladanaHodnota = pole[j];
                prohodit = (razeni == Razeni.Sestupne ^ ((dynamic)vkladanaHodnota < (dynamic)pole[j - 1])) && j > 0;

                while (prohodit)
                {

                    pole[j] = pole[j - 1];
                    j--;

                    if (j > 0)
                    {
                        prohodit = (razeni == Razeni.Sestupne ^ ((dynamic)vkladanaHodnota < (dynamic)pole[j - 1])) && j > 0;

                    }
                    else
                    {
                        prohodit = false;
                    }

                }

                pole[j] = vkladanaHodnota;
            }

        }

        static void InsertionSort5<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            bool prohodit, podminka;
            for (int i = 0; i < pole.Length - 1; i++)
            {
                int j = i + 1;

                T vkladanaHodnota = pole[j];
                podminka = ((dynamic)vkladanaHodnota < (dynamic)pole[j - 1]);
                prohodit = (razeni == Razeni.Vzestupne ? podminka : !podminka);

                do
                {
                    pole[j] = pole[j - 1];
                    j--;

                    podminka = ((dynamic)vkladanaHodnota < (dynamic)pole[j - 1]);
                    prohodit = (razeni == Razeni.Vzestupne ? podminka : !podminka) && j > 1;

                    /*if (j > 0)
                    {
                        podminka = ((dynamic)vkladanaHodnota < (dynamic)pole[j - 1]);
                        prohodit = (razeni == Razeni.Vzestupne ? podminka : !podminka) && j > 0;

                    }
                    else
                    {
                        prohodit = false;
                    }
*/
                }
                while (prohodit);

                pole[j] = vkladanaHodnota;
            }

        }

        static void QuickSort<T>(ref T[] pole, Razeni razeni, ProgressBar p)
        {
            QuickSort<T>(ref pole, 0, pole.Length - 1, razeni);
        }

        static void QuickSort<T>(ref T[] pole, int minIndex, int maxIndex, Razeni razeni)
        {
            if (minIndex < maxIndex)
            {       // řazená část musí být velikosti > 1
                int pivotIndex = minIndex;              // 1. fáze - výběr pivota

                int pomIndex = pivotIndex;              // 2. fáze – umístění pivota
                for (int i = minIndex + 1; i <= maxIndex; i++)
                {
                    bool podminka = ((dynamic)pole[i] > (dynamic)pole[pivotIndex]);

                    if (razeni == Razeni.Sestupne ? podminka : !podminka)
                    {
                        pomIndex++;
                        StaticProhoditPromenna<T>(ref pole[i], ref pole[pomIndex]);
                    }
                }
                StaticProhoditPromenna<T>(ref pole[pivotIndex], ref pole[pomIndex]);
                pivotIndex = pomIndex;

                QuickSort<T>(ref pole, minIndex, pivotIndex - 1, razeni);    // 3. fáze – rekurze
                QuickSort<T>(ref pole, pivotIndex + 1, maxIndex, razeni);
            }
        }


        private void MeritRazeni(int maxPocet, int min, int max)
        {
            Merit(BubbleSort, 1000, min, max);

            //VytizitProcesor();
            WriteLine("Počet položek;Bubble Sort;Selection Sort;Insertion Sort;Insertion Sort2;Insertion Sort3;Insertion Sort4;Quick Sort");
            for (int i = 10; i < maxPocet; i *= 2)
            {
                WriteLine(
                    string.Format(
                        "{0};{1:0.000000};{2:0.000000};{3:0.000000};{4:0.000000};{5:0.000000};{6:0.000000};{7:0.000000}",
                        i,
                        Merit(BubbleSort, i, min, max),
                        Merit(SelectionSort, i, min, max),
                        Merit(InsertionSort, i, min, max),
                        Merit(InsertionSort2, i, min, max),
                        Merit(InsertionSort3, i, min, max),
                        Merit(InsertionSort4, i, min, max),
                        Merit(QuickSort, i, min, max)));



            }
        }


        public delegate void AlgoritmusRazeni<T>(ref T[] pole, Razeni razeni, ProgressBar p);
        private double Merit(AlgoritmusRazeni<int> algoritmus, int pocetPolozek, int min, int max)
        {
            int[] cisla = NewRandomArray(pocetPolozek, min, max);
            akceLabel.Text =
                string.Format(
                    "Řazení {0} {1}, počet položek: {2}, minimum: {3}, maximum {4}",
                    algoritmus.Method.Name, "Vzestupně", pocetPolozek, min, max);
            akceLabel.Refresh();
            var sw = Stopwatch.StartNew();
            algoritmus(ref cisla, Razeni.Vzestupne, akceProgressBar);
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;

        }

        private void meritRazeniButton_Click(object sender, EventArgs e)
        {
            //int[] cisla = NewRandomArray(20, -20, 20);
            int[] cisla = NewRandomArray(20, -20, 20, 0.1, Razeni.Vzestupne);


            WriteLine(string.Format("{0}, {1}", ToString(cisla), PoleRazeni(cisla)));
            QuickSort(ref cisla, Razeni.Vzestupne, akceProgressBar);
            WriteLine(string.Format("{0}, {1}", ToString(cisla), PoleRazeni(cisla)));
            QuickSort(ref cisla, Razeni.Sestupne, akceProgressBar);
            WriteLine(string.Format("{0}, {1}", ToString(cisla), PoleRazeni(cisla)));
            WriteLine();
            //MeritRazeni(15000, -100, 100);
            WriteLine();
            //MeritRazeni(15000, 1, 5);
        }

        private Random generator = new Random();

        private int[] NewRandomArray(int length, int min, int max)
        {
            int[] numbers = new int[length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = generator.Next(min, max);
            }
            return numbers;
        }
        private int[] NewRandomArray(int length, int min, int max, double faktorPromichani, Razeni razeni)
        {
            int[] pole = NewRandomArray(length, min, max);
            QuickSort(ref pole, razeni, null);
            for (int i = 0; i < faktorPromichani * pole.Length; i++)
            {
                int indexA = generator.Next(0, pole.Length - 1);
                int indexB = generator.Next(0, pole.Length - 1);
                StaticProhoditPromenna(ref pole[indexA], ref pole[indexB]);
            }
            return pole;
        }

        private string ToString<T>(T[] arr)
        {
            return string.Format("{0}", string.Join(", ", arr));
        }

        private void WriteLine()
        {
            vystupTextBox.AppendText(Environment.NewLine);
        }

        private void WriteLine(string text)
        {
            vystupTextBox.AppendText(text);
            WriteLine();
        }

        
    }
    }
