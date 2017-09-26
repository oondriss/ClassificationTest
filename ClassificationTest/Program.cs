using AForge.Neuro;
using AForge.Neuro.Learning;
using ClassificationTest.DTO;
using ClassificationTest.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassificationTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //vybrat excel s hodnotami
            //vyparsovat ho, ulozit si hodnoty

            //rozbehat neuronku
            //naucit neuronku
            //testovat neuronku
            //skusit pustit data on-the-fly

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Multiselect = false
            };

            string excelFileName;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                excelFileName = ofd.FileName;
            }
            else
            {
                throw new Exception("Je nutne vybrat subor");
            }

            var excelManager = new ExcelParser(excelFileName);
            excelManager.ParseSourceData();
            

            double[][] input = NeuronData.GetInputMatrix();
            double[][] output = NeuronData.GetOutputMatrix();

            // create neural network
            ActivationNetwork network = new ActivationNetwork(
                new SigmoidFunction(3),
                3, // two inputs in the network
                3, // two neurons in the first layer
                2); // one neuron in the second layer
                    // create teacher
            BackPropagationLearning teacher =
                new BackPropagationLearning(network);
            bool needToStop = false;
            // loop
            while (!needToStop)
            {
                // run epoch of learning procedure
                System.Threading.Thread.Sleep(1000);
                double error = teacher.RunEpoch(input, output);
                Console.WriteLine(error);
                // check error value to see if we need to stop
                // ...
            }






        }
    }
}
